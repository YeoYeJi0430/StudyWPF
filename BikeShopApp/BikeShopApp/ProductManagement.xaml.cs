using BikeShop;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// ProductManagement.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 
    
    public partial class ProductManagement : Page
    {
        ProductsFactory factory;

        public ProductManagement()
        {
            InitializeComponent();
            factory = new ProductsFactory();
        }

        
        
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            GrdProducts.ItemsSource = factory.FindProducts(TxtSearch.Text);//TxtSearch.Text 가져올거임
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == System.Windows.Input.Key.Enter)
            {
                GrdProducts.ItemsSource = factory.FindProducts(TxtSearch.Text);
            }
        }

        private void GrdProducts_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("TEST"); // 더블클릭이 오류원인인지 확인
        }
    }
}
