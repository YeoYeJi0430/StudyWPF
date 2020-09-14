using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMvvmApp.Helpers;

namespace WpfMvvmApp.Models
{
    public class Person
    {
        public string FirstName { get; set; }   //테이블상 필드, db에서 가져온값을 확인 할 필요없을때 get,set만씀

        public string LastName { get; set; }    //테이블상 필드

        string email;

        public string Email
        {
            get => email;
            //get { return email; }
            set
            {
                if (Commons.IsValidEmail(value)) //Helpers-Commons
                    email = value;
                else
                    throw new Exception("Invalid Email");
            }
            //email입력한걸 db에서 받아오는데 만약 naver.com 이런 주소 입력이 없으면 db에 들어가면 안되기 때문에
            //재차 확인을 위해 리턴값을 적어서 확인해줌
        }

        DateTime date; //테이블상 필드

        public DateTime Date
        {
            get { return date; }
            set
            {
                var result = Commons.CalcAge(value); //나이
                if (result > 150 || result < 0)
                    throw new Exception("Invalid Age");
                else
                    date = value;
            }
        }

        public Person(string firstName, string lastName, string email, DateTime date)
        {
            //속성들만 선택해서 생성자 만들었음
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Date = date;
        }

        public bool IsBirthDay  //db에 없음 추가속성임
        {
            get
            {
                return DateTime.Now.Month == Date.Month &&
                    DateTime.Now.Day == Date.Day; //생일이 같을때
            }
        }

        public bool IsAdult //추가속성,성인인가?
        {
            get
            {
                return Commons.CalcAge(Date) > 18;
            }
        }

        public string ChnZodiac
        {
            get
            {
                return Commons.GetChineseZodiac(Date);
            }
        }

        public string CalcZodiac
        {
            get
            {
                return Commons.GetCalcZodiac(Date);
            }
        }
    }
}
