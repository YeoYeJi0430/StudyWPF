using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoMonitoringApp.Models
{
    public class SensorData
    {
        public DateTime Date { get; set; }
        public int Value { get; set; }

        public SensorData(DateTime date, int value)
        {
            Date = date;
            Value = value;
        }
    }
}
