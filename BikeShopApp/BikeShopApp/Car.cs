using System.Windows.Media;

namespace BusinessLogic
{
    public class Car : Notifier
    {
        private double speed;

        public double Speed
        {
            get
            {
                return speed;
            }
            set
            {
                speed = value;
                OnPropertyChanged("Speed");
            }
        }

        private Color color;

        public Color Color
        {
            get
            {
                return color;
            }

            set
            {
                color = value;
                OnPropertyChanged("Color");
            }
        }

        public Human Driver { get; set; }
        //car에서 human 클래스를 가져다 씀
    }

    public class Human
    {
        public string Name { get; set; }
        public bool HasDrivingLicense { get; set; }
    }
}
