using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// VctIndks.xaml etkileşim mantığı
    /// </summary>
    public partial class VctIndks : Window
    {
        public VctIndks()
        {
            InitializeComponent();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void HesaplaBtn_Click(object sender, RoutedEventArgs e)
        {
            float kg = float.Parse(kilo.Text);
            float by = float.Parse(boy.Text);

            float indks = kg / (by * by / 10000);

            sonuc.Content = indks.ToString("00.0");
        }

        private void TemizleBtn_Click(object sender, RoutedEventArgs e)
        {
            kilo.Text = "";
            boy.Text = "";
            sonuc.Content = "";
        }
    }
}
