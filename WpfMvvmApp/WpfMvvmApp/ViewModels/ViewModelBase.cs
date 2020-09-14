using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMvvmApp.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged(string propertyName) // propertyName == 앞서 만든 firstname,lastname,email,date :  값이 바뀌면 밖ㅆ다고 알려줌
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); //PropertyChanged(this,(firstname,lastname,emain,date)데이터넘겨줌 )
            //?. <- 뜻 : null이 아니면 뒤에 수행

            //if(PropertyChanged!=null)
            //{
            //    PropertyChanged(this), new PropertyChangedEventArgs(propertyName));
            //} 위에 한 문장과 같은뜻
        }
    }
}
