using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MqttMonitoringApp.ViewModels
{
    public class ErrorPopupViewModel : Conductor<object>
    {
        private string errorMessage;
        public string ErrorMessage
        {
            get => errorMessage;
            set
            {
                errorMessage = value;
                NotifyOfPropertyChange(() => errorMessage);
            }
        }

        public void ConfirmClose()
        {
            TryClose(true);
        }

        public ErrorPopupViewModel(string param)
        {
            var tmp = param.Split('|');//param을 필요한만큼 잘라서 사용
            DisplayName = tmp[0];
            ErrorMessage = tmp[1];
        }
    }
}
