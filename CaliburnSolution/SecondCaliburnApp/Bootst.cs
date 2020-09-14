using Caliburn.Micro;
using SecondCaliburnApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SecondCaliburnApp
{
    class Bootst : BootstrapperBase
    {
        public Bootst()
        {
            Initialize(); //초기화
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<ShellViewModel>();//최초화면지정 : DisplayRootViewFor<ShellViewModel>() : object에 viewmodel연결해줘야함
        }
    }
}
