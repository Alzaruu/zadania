using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
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

namespace Ежедн
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        
        public MainWindow()
        {
            InitializeComponent();
            DateTime dateTime= DateTime.Now;
            dat.Text = dateTime.ToString();
            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial serial in lll)
            {
                items?.Append(serial.name);
            }
            zametki.ItemsSource= items;
        }

        string[] items;
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial serial in lll) //Возможно ли перебирать это черех цикл фор? просто высылает ошибку, что у листа нет длины или что-то по типу того
            {
                if ((serial.name.Equals(nazv.Text) || serial.description.Equals(opis.Text))
                    && serial.data.Equals(dat.Text))
                {
                    lll.Remove(serial);
                }
            }
            serial.MySeriali<List<serial>>(lll);

        }

        private void Cre_Click(object sender, RoutedEventArgs e)
        {
            List<serial> lll = serial.MyDeser<List<serial>>();
            serial lala = new serial();
            lala.name = nazv.Text;
            lala.description = opis.Text;
            DateTime ddata = Convert.ToDateTime(dat.Text);
            lala.data = ddata.ToShortDateString();
            lll.Add(lala);
            serial.MySeriali<List<serial>>(lll);
        }

        private void Sohr_Click(object sender, RoutedEventArgs e)
        {
            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial serial in lll)
            {
                if ((serial.name.Equals(nazv.Text) || serial.description.Equals(opis.Text))
                    && serial.data.Equals(Convert.ToDateTime(dat.Text))) { 
                    serial.name= nazv.Text;
                    serial.description= opis.Text;
                }
            }
            serial.MySeriali<List<serial>>(lll);
        }

        private void dat_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial serial in lll)
            {
                items?.Append(serial.name);
            }
            zametki.ItemsSource = items;
        }

        private void zametki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial serial in lll)
            {
                nazv.Text = serial.name;
                opis.Text = serial.description;
            }
        }
    }
}
