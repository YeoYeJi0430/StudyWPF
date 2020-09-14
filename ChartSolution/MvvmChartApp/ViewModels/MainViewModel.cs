using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvvmChartApp.ViewModels
{
    internal class MainViewModel : Conductor<object>
    {
        public void LoadLineChart()
        {
            ActivateItem(new LineChartViewModel());//화면 활성화
        }

        public void LoadGaugeChart()
        {
            ActivateItem(new GaugeChartViewModel());
        }

        public void ExitProgram()
        {
            Environment.Exit(0); //0:오류없이 끝
        }
    }
}
