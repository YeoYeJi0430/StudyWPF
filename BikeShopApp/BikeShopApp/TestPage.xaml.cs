using BusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BikeShopApp
{
    /// <summary>
    /// TestPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class TestPage : Page
    {
        public TestPage()
        {
            InitializeComponent();
            InitListBox();
        }

        private void InitListBox()
        {
            Random rand = new Random();
            string[] names = { "yeji", "yeo", "a", "b", "c", "d" };
            List<Car> lists = new List<Car>();
            for (int i = 0; i < 10; i++)
            {
                byte red = (byte)(i % 3 == 0 ? 255 : (i * 50) % 255);
                byte green = 0;
                byte blue = (byte)(i % 3 == 0 ? (i * 90) % 255 : 255);
                int index = rand.Next(names.Length); // Length : 0~5, 랜덤(class)의 인덱스
                lists.Add(new Car
                {
                    Speed = i * 30,
                    Color = Color.FromRgb(red,green,blue),
                    Driver = new Human { Name = names[index], HasDrivingLicense = true}
                }); //car를 10개 담고있는 lists가 생김
            }
            //LstCar.DataContext = lists; //주석풀기!!!
            //LstCar에 할당했음
        }

        private void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            /*
            Human h = new Human();
            h.Name = "YeDi";
            h.HasDrivingLicense = true;
            Car car2 = new Car();
            car2.Speed = 100;
            car2.Color = Colors.BlueViolet;
            //car1이랑 car2는 별개
            car2.Driver = h;
            */

            Car car = new Car();
            car.Speed = 100;
            car.Color = Colors.Blue;

            car.Driver = new Human { Name = "Yed2", HasDrivingLicense = true };

            //this.DataContext = car;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
