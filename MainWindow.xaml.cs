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

using Microsoft.Data.SqlClient;
using System.Data;

namespace esimerkki
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void hae_painike_Click(object sender, RoutedEventArgs e)
        {
            string polku = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\k2101816\\OneDrive - Epedu O365\\3. lukuvuosi\\Sovelluskehitys\\esimerkki\\tuotekanta.mdf\";Integrated Security=True;Connect Timeout=30";
            SqlConnection kanta = new SqlConnection(polku);
            kanta.Open();

            //Tehdään sql-komento
            string kysely = "Select * from tuotteet";
            SqlCommand komento= kanta.CreateCommand();
            komento.CommandText = kysely;

            //Tehdään data adapteri ja taulu johon tiedot haetaan
            SqlDataAdapter adapteri = new SqlDataAdapter(komento);
            DataTable dt = new DataTable("tuotteet");
            adapteri.Fill(dt);

            //Sijoitetaan data taulun tiedot DataGridiin//
            tuotelista.ItemsSource = dt.DefaultView;
            kanta.Close();
        }
    }
}
