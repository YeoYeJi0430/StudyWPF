using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinformChartApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SeriesCollection piechartData = new SeriesCollection()    //Collection은 리스트
            {
                new PieSeries
                {
                    Title = "삼성전자",
                    Values = new ChartValues<double> { 75.5 },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "LG전자",
                    Values = new ChartValues<double> { 22.2 },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "대우전자",
                    Values = new ChartValues<double> { 6.7 },
                    DataLabels = true,
                },
                new PieSeries
                {
                    Title = "삼화전자",
                    Values = new ChartValues<double> { 1.2 },
                    DataLabels = true,
                }
            };

            pieChart1.Series = piechartData; //차트에 위의 데이터들 넣음

            pieChart1.LegendLocation = LegendLocation.Right;//오른쪽 범례
        }
    }
}
