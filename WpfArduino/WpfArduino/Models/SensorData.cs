using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfArduino.Models
{
    class SensorData
    {
        public DateTime Date { get; set; }
        public short Value { get; set; }

        public SensorData(DateTime date, short value)
        {
            Date = date;
            Value = value;
        }
    }
}
