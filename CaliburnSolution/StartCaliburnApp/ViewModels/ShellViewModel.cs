using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace StartCaliburnApp.ViewModels
{
    class ShellViewModel : PropertyChangedBase, IHaveDisplayName //인터페이스 : IHaveDisplayName
    {
        string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyOfPropertyChange(() => Name); //string으로 보내는게 아니라 값 그대로 보냄,WpfMvvmApp에서 shellviewmodel<-멤버변수/속성영역에서 RaisePropertyChanged("InLastName"); <- string으로 보냄
                NotifyOfPropertyChange(() => CanSayHello);
            }

        }
        public bool CanSayHello
        {
            get => !string.IsNullOrEmpty(Name); //null(X) = true(버튼활성화), null = false(비활성화) : canexcute랑 비슷
                                                //텍스트칸에 뭔가 쓰여지면 버튼활성화시킴
        }
        public string DisplayName { get; set; /*=> throw new NotImplementedException(); set => throw new NotImplementedException();*/ }

        public ShellViewModel()
        {
            DisplayName = "Basic Caliburn App"; //  제목표시줄
        }

        public void SayHello()
        {
            MessageBox.Show($"Hello {Name}");
        }
        
    }
}
