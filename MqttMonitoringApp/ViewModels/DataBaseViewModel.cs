﻿using Caliburn.Micro;
using MqttMonitoringApp.Helpers;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Esf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
//토글버튼 : DataBaseView에 Connect버튼

namespace MqttMonitoringApp.ViewModels
{
    public class DataBaseViewModel : Conductor<object>
    {
        private string brokerUrl;
        public string BrokerUrl
        {
            get => brokerUrl;
            set
            {
                brokerUrl = value;
                NotifyOfPropertyChange(() => BrokerUrl);
            }
        }

        private string topic;
        public string Topic
        {
            get => topic;
            set
            {
                topic = value;
                NotifyOfPropertyChange(() => Topic);
            }
        }

        private string connString;
        public string ConnString
        {
            get => connString;
            set
            {
                connString = value;
                NotifyOfPropertyChange(() => ConnString);
            }
        }

        private string dbLog;
        public string DbLog
        {
            get => dbLog;
            set
            {
                dbLog = value;
                NotifyOfPropertyChange(() => DbLog);
            }
        }

        private bool isConnected;
        public bool IsConnected
        {
            get => isConnected;
            set
            {
                isConnected = value;
                NotifyOfPropertyChange(() => IsConnected);
            }
        }

        public DataBaseViewModel()
        {
            BrokerUrl = Commons.BROKERHOST;
            Topic = Commons.PUB_TOPIC;
            Commons.CONNSTRING = ConnString = "Server=localhost;Port=3306;" +
                "Database=iot_sensordata;Uid=root;Pwd=mysql_p@ssw0rd";

            //토글버튼 온
            if(Commons.ISCONNECT)
            {
                IsConnected = true;
                Connect();
            }
        }
        

        public void Connect()
        {
            if (IsConnected) //토글버튼 온
            {
                Commons.BROKERCLIENT = new MqttClient(BrokerUrl);
                try
                {
                    if (Commons.BROKERCLIENT.IsConnected != true)
                    {
                        Commons.BROKERCLIENT.MqttMsgPublishReceived += BROKERCLIENT_MqttMsgPublishReceived; //메세지 받을때마다 이벤트 시작
                        Commons.BROKERCLIENT.Connect("MqttMonitor"); //연결
                        Commons.BROKERCLIENT.Subscribe(new string[] { Commons.PUB_TOPIC }
                        , new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
                        UpdateText(">>> Message : Boroker Connected");
                        Commons.ISCONNECT = true;//다른화면 갔다와도 연결유지
                    }
                }
                catch (Exception)
                {
                }
            }
            else //토글버튼 오프
            {
                try
                {
                    if (Commons.BROKERCLIENT.IsConnected)
                    {
                        Commons.BROKERCLIENT.MqttMsgPublishReceived -= BROKERCLIENT_MqttMsgPublishReceived; //메세지 받을때마다 이벤트 시작
                        Commons.BROKERCLIENT.Disconnect();//연결 끊기
                        UpdateText(">>> Message : Boroker Disconnected...");
                        Commons.ISCONNECT = false;//다른화면일때 연결보류
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void BROKERCLIENT_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Message);
            UpdateText($">>> Message : {message}");
            InsertDataBase(message);
        }

        private void InsertDataBase(string message)
        {
            //TODO
            //mysql접속
            var currDatas = JsonConvert.DeserializeObject<Dictionary<string, string>>(message);//message가 json이기 때문에 바꿔줌
            using (var conn = new MySqlConnection(Commons.CONNSTRING))
            {
                string strInsQuery = @" INSERT INTO smarthometbl
                                        (
                                        Dev_Id,
                                        Curr_Time,
                                        Temp,
                                        Humid,
                                        Press)
                                        VALUES
                                        (
                                        @Dev_Id,
                                        @Curr_Time,
                                        @Temp,
                                        @Humid,
                                        @Press)
                                        " ;
                try
                {
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand(strInsQuery, conn);
                    MySqlParameter paramDevId = new MySqlParameter("@Dev_Id", MySqlDbType.VarChar);
                    paramDevId.Value = currDatas["Dev_Id"]; //컬럼명 ,json의 키 값
                    cmd.Parameters.Add(paramDevId);

                    MySqlParameter paramCurrTime = new MySqlParameter("@Curr_Time", MySqlDbType.DateTime);
                    paramCurrTime.Value = DateTime.Parse(currDatas["Curr_Time"]); //컬럼명 ,json의 키 값
                    cmd.Parameters.Add(paramCurrTime);

                    MySqlParameter paramTemp = new MySqlParameter("@Temp", MySqlDbType.Float);
                    paramTemp.Value = currDatas["Temp"]; //컬럼명 ,json의 키 값
                    cmd.Parameters.Add(paramTemp);

                    MySqlParameter paramHumid = new MySqlParameter("@Humid", MySqlDbType.Float);
                    paramHumid.Value = currDatas["Humid"]; //컬럼명 ,json의 키 값
                    cmd.Parameters.Add(paramHumid);

                    MySqlParameter paramPress = new MySqlParameter("@Press", MySqlDbType.Float);
                    paramPress.Value = currDatas["Press"]; //컬럼명 ,json의 키 값
                    cmd.Parameters.Add(paramPress);

                    if (cmd.ExecuteNonQuery()==1)
                    {
                        UpdateText("[DB] Inserted");
                    }
                    else
                    {
                        UpdateText("[DB] Failed");
                    }
                }
                catch (Exception ex)
                {
                    UpdateText($">>> Message : {ex.Message}");
                }
            }
        }

        private void UpdateText(string message)
        {
            DbLog += $"{message}\n";
        }

    }
}
