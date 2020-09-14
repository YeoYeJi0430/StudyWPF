using Caliburn.Micro;
using System;
using System.Threading;

namespace MvvmChartApp.ViewModels
{
    public class GaugeChartViewModel : Conductor<object>
    {
        double angValue;
        public double AngValue
        {
            get => angValue;
            set
            {
                angValue = value;
                NotifyOfPropertyChange(() => AngValue);
            }
        }

        public Timer CustomTimer { get; set; }
        public GaugeChartViewModel()
        {
            //AngValue = 225; //확인
            CustomTimer = new Timer(TickCallBack);
            CustomTimer.Change(1000, 1000); //1초이후에 1초의 간격으로 TickCallBack발생
        }

        private void TickCallBack(object state)
        {
            AngValue = new Random().Next(20, 300);
        }
    }
}