using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace SimBT_Deneme
{
    public partial class DbConnect : Window
    {
        public DbConnect()
        {
            InitializeComponent();
        }

        private void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Kaydet_Click(object sender, RoutedEventArgs e)
        {
            string gen = "";
            bool flag = false;

            if ((bool)sex_Female.IsChecked)
                gen = sex_Female.Content.ToString();
            else if ((bool)sex_Male.IsChecked)
                gen = sex_Male.Content.ToString();
            else if ((bool)sex_Other.IsChecked)
                gen = sex_Other.Content.ToString();
            else
                flag = true;

            if (string.IsNullOrEmpty(name.Text))
                flag = true;
            if (string.IsNullOrEmpty(surname.Text))
                flag = true;
            if (string.IsNullOrEmpty(tel.Text))
                flag = true;

            if (flag)
                MessageBox.Show("Bütün Alanların Dolu Olduğundan Emin Olun!", "Alanları Doldurun", MessageBoxButton.OK, MessageBoxImage.Warning);
            else
            {
                try
                {
                    Employee emp = new Employee();
                    emp.Name = name.Text;
                    emp.Surname = surname.Text;
                    emp.Gender = gen;
                    emp.TelNo = tel.Text;

                    SaveXML.SaveData(emp, @"C:\Users\muham\Desktop\SimBT_Deneme\bin\Debug\Data.xml");

                    msgLabel.Content = "Veri Başarıyla Kaydedildi!";

                    Temizle();
                }
                catch (Exception ex)
                {
                    msgLabel.Content = "Veri Kaydedilemedi!";
                    MessageBox.Show(ex.Message);
                }
            }            
        }

        private void Temizle()
        {
            surname.Text = "";
            name.Text = "";
            tel.Text = "";
            sex_Female.IsChecked = false;
            sex_Male.IsChecked = false;
            sex_Other.IsChecked = false;            
        }

        private void Temizle_Click(object sender, RoutedEventArgs e)
        {
            Temizle();
            msgLabel.Content = "";
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DataSet dataSet = new DataSet();
                dataSet.ReadXml(@"C:\Users\muham\Desktop\SimBT_Deneme\bin\Debug\Data.xml");
                DataView view = new DataView(dataSet.Tables[0]);
                xmlData.ItemsSource = view;

                loadMsgLabel.Content = "Veriler Başarılı Bir Şekilde Yüklendi!";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadTemizle_Click(object sender, RoutedEventArgs e)
        {
            loadMsgLabel.Content = "";
            xmlData.ItemsSource = null;
        }
    }
}
