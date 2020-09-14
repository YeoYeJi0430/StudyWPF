using Caliburn.Micro;
using MySql.Data.MySqlClient;
using SecondCaliburnApp.Helpers;
using SecondCaliburnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCaliburnApp.ViewModels
{
    class ShellViewModel: Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get; set; }

        string firstName;

        public string FirstName
        {
            get => firstName;
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName); //값바꿨으니 처리해달라고함
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        string lastName;

        public string LastName
        {
            get => lastName;
            set 
            { 
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        public string FullName
        {
            get => $"{FirstName} {LastName}"; // ==string.Format("{0} {1}", FirstName, LastName);
        }

        public ShellViewModel()
        {
            DisplayName = "Second Caliburn App";
            //FirstName = "yed2";

            
            People = new BindableCollection<PersonModel>();
            //People.Add(new PersonModel { LastName = "Gates", FirstName = "Bill" });
            //People.Add(new PersonModel { LastName = "Jobs", FirstName = "Steve" });
            //People.Add(new PersonModel { LastName = "Musk", FirstName = "Ellen" });

            InitCombobox();

        }

        private void InitCombobox()
        {
            People.Add(new PersonModel { LastName = "", FirstName = "--선택--" });
            using (MySqlConnection conn = new MySqlConnection(Commons.STRCONNSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECTPEOPLEQUERY, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var temp = new PersonModel
                    {
                        FirstName = reader["FirstName"].ToString(),//reader["FirstName"]에서 FirstName는 mysql에 있음
                        LastName = reader["LastName"].ToString()
                    }; //대소문자 구별x
                    People.Add(temp);
                }

            }
           SelectedPerson = People.Where(v => v.FirstName.Contains("선택")).First(); // 첫화면에 선택이라는 글자가 떠 있음
        }

        //콤보박스 사람 리스트
        public BindableCollection<PersonModel> People  //바인드할때 ui에 올리는 데이터들,BindableCollection대신 리스트써도 ㄱㅊ 비슷한개념?,(marshalling = 큐)
        {
            get;set;
        }
        
        PersonModel selectedPerson;

        public PersonModel SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                LastName = selectedPerson.LastName;              //LastName은 viewmodel에 있는 LastName
                FirstName = selectedPerson.FirstName;
                NotifyOfPropertyChange(() => SelectedPerson);   //값이 바꼈다는것을 시스템에 알려줌
                NotifyOfPropertyChange(() => CanClearName);     //속성발동

            }
        }
        
        public void ClearName()
        {
            this.FirstName = this.LastName = string.Empty;
        }
        public bool CanClearName
        {
            /*
            if(string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            {
                return false;
            }
            else
            {
                return true;
            }
            */
            get => !(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName));
        }

        public void LoadPageOne()
        {
            // UserControl FirstChildView load
            ActivateItem(new FirstChildViewModel());                                                                //class ShellViewModel: Conductor<object>, <-Conductor써야 ActivateItem사용가능
            
        }

        public void LoadPageTwo()
        {
            //UserControl SecondChildView load
            ActivateItem(new SecondChildViewModel());
        }
    }
}
