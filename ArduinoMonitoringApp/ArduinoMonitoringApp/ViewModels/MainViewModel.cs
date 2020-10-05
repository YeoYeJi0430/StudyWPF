using ArduinoMonitoringApp.Models;
using Caliburn.Micro;
using LiveCharts;
using LiveCharts.Wpf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Threading;

namespace ArduinoMonitoringApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {
        List<SensorData> photoDatas = new List<SensorData>(); //SensorData리스트
        DispatcherTimer timer;
        SerialPort serial;
        string strConnString = "Server=localhost;Port=3306;" +
            "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";
        public BindableCollection<string> CboSerialPort { get; set; }

        //차트
        private SeriesCollection chartval;
        public SeriesCollection ChartVal
        {
            get
            {
                return chartval;
            }
            set
            {
                chartval = value;
                NotifyOfPropertyChange();
            }
        }

        //프로그레스바값
        int pgbPhotoRegistor;
        public int PgbPhotoRegistor
        {
            get => pgbPhotoRegistor;
            set
            {
                pgbPhotoRegistor = value;
                NotifyOfPropertyChange(() => PgbPhotoRegistor);
            }
        }

        //연결횟수
        string sensorCount;
        public string SensorCount
        {
            get => sensorCount;
            set
            {
                sensorCount = value;
                NotifyOfPropertyChange(() => SensorCount);
            }
        }

        //현재값
        string lblPhotoRegistor;
        public string LblPhotoRegistor
        {
            get => lblPhotoRegistor;
            set
            {
                lblPhotoRegistor = pgbPhotoRegistor.ToString();
                NotifyOfPropertyChange(() => LblPhotoRegistor);
            }
        }

        //보드
        string board;
        public string Board
        {
            get => board;
            set
            {
                var item = new StringBuilder();
                item.Append(DateTime.Now.ToString("yyyy-MM-dd\t") + pgbPhotoRegistor.ToString() + "\n");
                board += item.ToString();
                NotifyOfPropertyChange(() => Board);
            }
        }

        //콤보박스 포트번호 확인
        string selectedPortName;
        public string SelectedPortName
        {
            get => selectedPortName;
            set
            {
                selectedPortName = value;
                SerialSetting();
                NotifyOfPropertyChange(() => SelectedPortName);
                NotifyOfPropertyChange(() => IsConnect);
                NotifyOfPropertyChange(() => CanConnect);
                NotifyOfPropertyChange(() => IsDisConnect);
                NotifyOfPropertyChange(() => CanDisConnect);
            }
        }

        //Connect버튼활성화
        bool isConnect = false;
        public bool IsConnect
        {
            get => isConnect;
            set
            {
                isConnect = value;
                NotifyOfPropertyChange(() => IsConnect);
                NotifyOfPropertyChange(() => CanConnect);
            }
        }

        public bool CanConnect
        {
            get
            {
                //콤보박스가 비어있지않고, Connect버튼이 활성화 되어있으면 true반환
                if (!string.IsNullOrEmpty(selectedPortName) && IsConnect)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Disconnect버튼 활성화
        bool isDisConnect = false;
        public bool IsDisConnect
        {
            get => isDisConnect;
            set
            {
                isDisConnect = value;
                NotifyOfPropertyChange(() => IsDisConnect);
                NotifyOfPropertyChange(() => CanDisConnect);
            }
        }

        public bool CanDisConnect
        {
            get
            {
                if (!string.IsNullOrEmpty(selectedPortName) && IsDisConnect)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //포트번호 할당 후 시리얼통신 셋팅
        public void SerialSetting()
        {
            //COM3확인
            serial = new SerialPort(selectedPortName);

            //시리얼통신 데이터
            serial.DataReceived += Serial_DataReceived;

            //Connect버튼 활성화
            IsConnect = true;
        }

        //시리얼통신을 통해 값 받아오기
        private void Serial_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string SVal = serial.ReadLine();
            int v = int.Parse(SVal);
            SensorData data = new SensorData(DateTime.Now, v);
            photoDatas.Add(data);
            InsertDataToDB(data);
            SensorCount = photoDatas.Count().ToString();
            PgbPhotoRegistor = v;
            LblPhotoRegistor = v.ToString();
            Board = photoDatas.ToString();
            ChartVal[0].Values.Add(v);
        }

        //Connect버튼
        public void Connect()
        {
            serial.Open();

            IsConnect = false;
            IsDisConnect = true;
        }

        //DisConnect버튼
        public void DisConnect()
        {
            serial.Close();

            IsConnect = true;
            IsDisConnect = false;
        }

        private void InsertDataToDB(SensorData data)
        {
            string strQuery = "INSERT INTO sensordatatbl " +
                " (Date, Value) " +
                " VALUES " +
                " (@Date, @Value) ";

            using (MySqlConnection conn = new MySqlConnection(strConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(strQuery, conn);
                MySqlParameter paramDate = new MySqlParameter("@Date", MySqlDbType.DateTime)
                {
                    Value = data.Date
                };
                cmd.Parameters.Add(paramDate);
                MySqlParameter paramValue = new MySqlParameter("@Value", MySqlDbType.Int32)
                {
                    Value = data.Value
                };
                cmd.Parameters.Add(paramValue);
                cmd.ExecuteNonQuery();
            }
        }

        //생성자
        public MainViewModel()
        {
            CboSerialPort = new BindableCollection<string>();
            foreach (var item in SerialPort.GetPortNames())
            {
                CboSerialPort.Add(item);
            }
            ChartVal = new SeriesCollection
                {
                    new LineSeries
                    {
                        Title = "PotoValue",
                        Values = new ChartValues<int>{ },
                        Fill = Brushes.Transparent,
                        Stroke = Brushes.Teal,
                        PointGeometrySize = 6
                    }
                };
        }

        #region Simulation
        public void Start()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += new EventHandler(Simulation);
            timer.Start();
        }

        public void Stop()
        {
            timer.Stop();
        }

        private void Simulation(object sender, EventArgs e)
        {
            Random random = new Random();
            int temp = random.Next(0, 1000);
            SensorData data = new SensorData(DateTime.Now, (int)temp);//SensorData-> data
            photoDatas.Add(data);//리스트추가

            PgbPhotoRegistor = (int)temp;
            LblPhotoRegistor = temp.ToString();
            SensorCount = photoDatas.Count().ToString();
            Board = photoDatas.ToString();
            ChartVal[0].Values.Add(temp);
        }
        #endregion

        //종료
        public void Exit()
        {
            (GetView() as Window).Close();
        }

        //도움말창
        public void Info()
        {
            IWindowManager info = new WindowManager();
            info.ShowDialog(new InfoViewModel(), null, null);
        }
    }
}
