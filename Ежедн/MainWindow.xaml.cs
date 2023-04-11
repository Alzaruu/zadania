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


        List<string> meow = new List<string>();
        public MainWindow()
        {
            InitializeComponent();
            DateTime dateTime= DateTime.Now;
            dat.Text = dateTime.ToString();
            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial Serial in lll.ToList())
            {
                if (Serial.data == dat.DisplayDate.ToString()) {
                    zametki.ItemsSource = lll;
                    zametki.DisplayMemberPath = "name";
                }
                
            }
        }

        string[] items = null;
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            List<serial> lll = serial.MyDeser<List<serial>>();

            foreach (serial serial in lll)
            {
                if ((serial.name.Equals(nazv.Text) || serial.description.Equals(opis.Text)) && serial.data.Equals(dat.Text))
                {
                    lll.Remove(serial);
                }
            }
            serial.MySeriali(lll);

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
            serial.MySeriali(lll);
            foreach (serial Serial in lll.ToList())
            {
                if (Serial.data == dat.DisplayDate.ToString())
                {
                    zametki.ItemsSource = lll;
                    zametki.DisplayMemberPath = "name";
                }

            }

        }

        private void Sohr_Click(object sender, RoutedEventArgs e)
        {
            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial serial in lll.ToList())
            {
                if ((serial.name.Equals(nazv.Text)==true || serial.description.Equals(opis.Text)==true) && serial.data.Equals(Convert.ToDateTime(dat.Text))==true) { 
                    serial.name= nazv.Text;
                    serial.description= opis.Text;
                }
            }
            serial.MySeriali<List<serial>>(lll);
            foreach (serial Serial in lll.ToList())
            {
                if (Serial.data == dat.DisplayDate.ToString())
                {
                    zametki.ItemsSource = lll;
                    zametki.DisplayMemberPath = "name";
                }

            }
        }

        private void dat_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial Serial in lll.ToList())
            {
                if (Serial.data == dat.DisplayDate.ToString())
                {
                    zametki.ItemsSource = lll;
                    zametki.DisplayMemberPath = "name";
                }

            }
        }

        private void zametki_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var swl = zametki?.SelectedValue.ToString();
            List<serial> lll = serial.MyDeser<List<serial>>();
            foreach (serial serial in lll.ToList())
            {
                if (swl == serial.name)
                {
                    nazv.Text = serial.name;
                    opis.Text = serial.description;
                }
            }
        }   
    }
}

