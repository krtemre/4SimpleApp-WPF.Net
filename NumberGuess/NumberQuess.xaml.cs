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
using System.Windows.Shapes;

namespace SimBT_Deneme
{
    /// <summary>
    /// NumberQuess.xaml etkileşim mantığı
    /// </summary>
    public partial class NumberQuess : Window
    {
        private int max = 1001, min = 0;
        public NumberQuess()
        {
            InitializeComponent();
            Begin();
        }

        private void Down_Click(object sender, RoutedEventArgs e)
        {
            string[] s = quees.Content.ToString().Split(' ');
            int que = int.Parse(s[1]);
            max = que;
            int v = min + (max - min) / 2;
            quees.Content = "Tahminim: " + v.ToString();
        }

        private void Correct_Click(object sender, RoutedEventArgs e)
        {
            CorrectLbl.Visibility = Visibility.Visible;
        }

        private void Up_Click(object sender, RoutedEventArgs e)
        {
            string[] s = quees.Content.ToString().Split(' ');
            int que = int.Parse(s[1]);
            min = que;
            int v = min + (max - min) / 2;
            quees.Content = "Tahminim: " + v.ToString();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            Begin();
        }

        private void Begin()
        {
            max = 1001;
            min = 0;
            int v = min + (max - min) / 2;
            quees.Content = "Tahminim: " + v.ToString();
            CorrectLbl.Visibility = Visibility.Hidden;
        }
    }
}
