using System;
using System.Collections.Generic;
using System.Data;
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
using MySql.Data.MySqlClient;

namespace dd_sabelnikova_aa
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=dbapp_sabelnikova_aa;UID=root;PASSWORD=Sabaton#2103;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tablik", connection);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            dtGrid.DataContext = dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=dbapp_sabelnikova_aa;UID=root;PASSWORD=Sabaton#2103;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO tablik (con_number, con_data_sig, con_name) VALUES ('" + con_number_box.Text + "', '" + con_data_sig_box.Text + "', '" + con_name_box.Text + "')", connection);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cmd = new MySqlCommand("SELECT * FROM tablik", connection);
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            dtGrid.DataContext = dt;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string connectionString = "SERVER=localhost;DATABASE=dbapp_sabelnikova_aa;UID=root;PASSWORD=Sabaton#2103;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("DELETE FROM tablik WHERE id_tablik_contr = " + deleteID1_box.Text, connection);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cmd = new MySqlCommand("SELECT * FROM tablik", connection);
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            dtGrid.DataContext = dt;
        }
    }
}
