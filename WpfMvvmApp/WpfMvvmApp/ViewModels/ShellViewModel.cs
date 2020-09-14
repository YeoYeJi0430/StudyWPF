using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfMvvmApp.Models;

namespace WpfMvvmApp.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        #region 멤버변수/속성영역
        string inLastName;
        string inFirstName;
        string inEmail;
        DateTime? inDate; //? <- nullable..??

        string outLastName;
        string outFirstName;
        string outEmail;
        string outDate;
        string outAdult;
        string outBirthday;
        string outChnZodiac; //추가 200727 16:43 신규추가
        string outCalcZodiac;

        public string InLastName
        {
            get => inLastName;
            set
            {
                //바뀐값알려줘야함
                inLastName = value;
                RaisePropertyChanged("InLastName"); //속성명 그대로 넣기
            }
        }

        public string InFirstName
        {
            get => inFirstName;
            set
            {
                //바뀐값알려줘야함
                inFirstName = value;
                RaisePropertyChanged("InFirstName"); //속성명 그대로 넣기
            }
        }

        public string InEmail
        {
            get => inEmail;
            set
            {
                //바뀐값알려줘야함
                inEmail = value;
                RaisePropertyChanged("InEmail"); //속성명 그대로 넣기
            }
        }

        public DateTime? InDate
        {
            get => inDate;
            set
            {
                //바뀐값알려줘야함
                inDate = value;
                RaisePropertyChanged("InDate"); //속성명 그대로 넣기
            }
        }

        public string OutLastName
        {
            get => outLastName;
            set
            {
                //바뀐값알려줘야함
                outLastName = value;
                RaisePropertyChanged("OutLastName"); //속성명 그대로 넣기
            }
        }

        public string OutFirstName
        {
            get => outFirstName;
            set
            {
                //바뀐값알려줘야함
                outFirstName = value;
                RaisePropertyChanged("OutFirstName"); //속성명 그대로 넣기
            }
        }

        public string OutEmail
        {
            get => outEmail;
            set
            {
                //바뀐값알려줘야함
                outEmail = value;
                RaisePropertyChanged("OutEmail"); //속성명 그대로 넣기
            }
        }

        public string OutDate
        {
            get => outDate;
            set
            {
                //바뀐값알려줘야함
                outDate = value;
                RaisePropertyChanged("OutDate"); 
            }
        }

        public string OutAdult
        {
            get => outAdult;
            set
            {
                //바뀐값알려줘야함
                outAdult = value;
                RaisePropertyChanged("OutAdult"); //속성명 그대로 넣기
            }
        }

        public string OutBirthday
        {
            get => outBirthday;
            set
            {
                //바뀐값알려줘야함
                outBirthday = value;
                RaisePropertyChanged("OutBirthday"); //속성명 그대로 넣기
            }
        }

        public string OutChnZodiac
        {
            get => outChnZodiac;
            set
            {
                //바뀐값알려줘야함
                outChnZodiac = value;
                RaisePropertyChanged("OutChnZodiac"); //200727 16:44 신규추가 : 띠
            }
        }

        public string OutCalcZodiac
        {
            get => outCalcZodiac;
            set
            {
                //바뀐값알려줘야함
                outCalcZodiac = value;
                RaisePropertyChanged("OutCalcZodiac"); //200727 16:44 신규추가 : 00자리
            }
        }
        #endregion

        ICommand clickCommand;
        public ICommand ClickCommand => clickCommand ?? (clickCommand = new RelayCommand<object>(
            //action,predicate(실해할수있는지?)
            o => Click(),o => IsClick() //o = 템플릿변수명, 클릭했을때 처리하는
            ));

        //public ICommand Clickcommand => clickCommand ?? (clickCommand = new RelayCommand<object>(o => Click(), o => IsClick()));

        private bool IsClick()
        {
            //클릭했을때 데이터 돌려줄수있는지 true or false
            return (!string.IsNullOrEmpty(InLastName) &&
                !string.IsNullOrEmpty(InFirstName) &&
                !string.IsNullOrEmpty(inEmail) &&
                !string.IsNullOrEmpty(InDate.ToString()));
        }

        private void Click()
        {
            try
            {
                DateTime date = InDate ?? DateTime.Now; //date값이 null이면 오늘날짜넣기
                Person person = new Person(InFirstName, inLastName, inEmail, date);
                //person안에 (lastname, firstname, email, date,)데이터필요
                OutLastName = person.LastName;
                OutFirstName = person.FirstName;
                OutEmail = person.Email;
                OutDate = person.Date.ToShortDateString(); //Date는 DateTime형인데 outDate를 멤버변수/속성영역에서 string으로 선언해서 tostring으로 형변환 해줬음
                OutAdult = $"{person.IsAdult}"; // bool형이라서 형변환 해준것.
                OutBirthday = $"{person.IsBirthDay}";
                OutChnZodiac = person.ChnZodiac; // person.cs에서 return Commons.GetChineseZodiac(Date) 데이터가 OutChnZodiac들어감
                OutCalcZodiac = person.CalcZodiac;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error : {ex.Message}");
                throw;
            }
        }
    }
}
