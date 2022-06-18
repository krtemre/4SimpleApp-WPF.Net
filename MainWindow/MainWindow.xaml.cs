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

namespace SimBT_Deneme
{
    /// <summary>
    /// MainWindow.xaml etkileşim mantığı
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void HesapMakinesi_Click(object sender, RoutedEventArgs e)
        {
            HspMakWin makWin = new HspMakWin();
            makWin.Show();
            Close();
        }

        private void VctBtn_Click(object sender, RoutedEventArgs e)
        {
            VctIndks vct = new VctIndks();
            vct.Show();
            Close();
        }

        private void DbConect_Click(object sender, RoutedEventArgs e)
        {
            DbConnect db = new DbConnect();
            db.Show();
            Close();
        }
    }
}
