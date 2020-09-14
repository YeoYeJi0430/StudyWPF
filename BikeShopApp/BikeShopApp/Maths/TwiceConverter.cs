﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace BikeShopApp.Maths
{
    public class TwiceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(value.ToString()) * 2;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return int.Parse(value.ToString()) * 3;
        }
        //많이 쓰이는 애들 따로 지정
    }
}