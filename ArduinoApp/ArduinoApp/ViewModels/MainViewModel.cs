using ArduinoApp.Helpers;
using ArduinoApp.Models;
using Caliburn.Micro;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Windows.Threading;
using Microsoft.TeamFoundation.Work.WebApi;
using LiveCharts;
using LiveCharts.Wpf;
using System.Windows.Media;
using DocumentFormat.OpenXml.Drawing.Charts;
using System.Windows;
using System.Windows.Input;
using ArduinoApp.Views;
using MahApps.Metro.Controls.Dialogs;
using System.Collections.ObjectModel;

namespace ArduinoApp.ViewModels
{
    public class MainViewModel : Conductor<object>
    {

        #region 시리얼

        private ObservableCollection<string> portNames;
        public ObservableCollection<string> PortNames
        {
            get => portNames;
            set
            {
                portNames = value;
            }
        }

        private ObservableCollection<SensorData> sensorDatas;
        public ObservableCollection<SensorData> SensorDatas
        {
            get => sensorDatas;
            set
            {
                sensorDatas = value;
            }
        }

        string port;
        public string Port
        {
            get => port;
            set
            {
                port = value;
                NotifyOfPropertyChange();
            }
        }

        public SerialPort Sport { get; set; }

        public void Connect()
        {
            Sport.Open();
        }
        private bool CanConnect(object obj)
        {
            return true;
        }



        public short sensorVal;
        public short SensorVal
        {
            get => sensorVal;
            set
            {
                sensorVal = value;
                NotifyOfPropertyChange();
            }
        }

        //Seval
        private string seval;
        public string Seval
        {
            get => seval;
            set
            {
                seval = value;
                NotifyOfPropertyChange();
            }
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string datas = Sport.ReadLine();
            short value = short.Parse(datas);
            SensorData data = new SensorData(DateTime.Now, value);
            photoDatas.Add(data);

            SensorVal = value;
            //Seval = $"{value}";
            LblPhotoRegistor = value.ToString();

        }

        private void AddPortNames(ObservableCollection<string> list)
        {
            foreach (var item in SerialPort.GetPortNames())
            {
                list.Add(item);
            }
        }

        public void Sfunc()
        {
            PortNames = new ObservableCollection<string>();
            AddPortNames(PortNames);

            SensorDatas = new ObservableCollection<SensorData>();

            Sport = new SerialPort();
            Sport.DataReceived += SerialDataReceived;
        }



        #endregion

        #region 창변환 모르겠음
        //private WindowManager windowManager;
        //public WindowManager WindowManager
        //{
        //    get
        //    {
        //        return windowManager;
        //    }
        //    set
        //    {
        //        windowManager = value;
        //        NotifyOfPropertyChange();
        //    }
        //}

        //public void OpenInfo(object obj)
        //{
        //    var Manager = new WindowManager();
        //    var FirstChild = new FirstChildViewModel();
        //    Manager.ShowDialog(FirstChild);
        //}
        #endregion


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

        //    //생성자
        public MainViewModel()
        {
            //Sfunc();
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
        public override string DisplayName { get; set; }

        List<SensorData> photoDatas = new List<SensorData>(); //SensorData리스트


        public bool IsSimulation { get; set; }

        DispatcherTimer timer;
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
            SensorData data = new SensorData(DateTime.Now, (short)temp);//SensorData-> data
            photoDatas.Add(data);//리스트추가

            PgbPhotoRegistor = (ushort)temp;
            LblPhotoRegistor = temp.ToString();
            SensorCount = photoDatas.Count().ToString();
            Board = photoDatas.ToString();
            ChartVal[0].Values.Add(temp);
        }

        ushort pgbPhotoRegistor;
        public ushort PgbPhotoRegistor
        {
            get => pgbPhotoRegistor;
            set
            {
                pgbPhotoRegistor = value;
                NotifyOfPropertyChange(() => PgbPhotoRegistor);
            }
        }


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

        private void InsertDataToDB(SensorData data)
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.strConnString))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.strQuery, conn);
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
    }
}
