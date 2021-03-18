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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;

namespace dd_sabelnikova_aa
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "SERVER=localhost;DATABASE=dbapp_sabelnikova_aa;UID=root;PASSWORD=Sabaton#2103;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT * FROM new_table", connection);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            dtGrid.DataContext = dt;
        }

        private void Button_Click(object sender, RoutedEventArgs e) // Добавить
        {
            string connectionString = "SERVER=localhost;DATABASE=dbapp_sabelnikova_aa;UID=root;PASSWORD=Sabaton#2103;";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO new_table (title, company, price) VALUES ('"+title_box.Text+"', '"+company_box.Text+"', "+price_box.Text+")", connection);
            DataTable dt = new DataTable();
            dt.Load(cmd.ExecuteReader());
            cmd = new MySqlCommand("SELECT * FROM new_table", connection);
            dt.Load(cmd.ExecuteReader());
            connection.Close();
            dtGrid.DataContext = dt;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e) // Удалить
        {
            if (deleteID_box.Text == "")
            {
                MessageBox.Show("Поле ID пустое!");
            }
            else
            {
                string connectionString = "SERVER=localhost;DATABASE=dbapp_sabelnikova_aa;UID=root;PASSWORD=Sabaton#2103;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM new_table WHERE id_table = " + deleteID_box.Text, connection);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cmd = new MySqlCommand("SELECT * FROM new_table", connection);
                dt.Load(cmd.ExecuteReader());
                connection.Close();
                dtGrid.DataContext = dt;
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e) // Другое окно
        {
            Window1 window = new Window1();
            window.Show();
        }

        private void Button_Click3(object sender, RoutedEventArgs e) //Изменить
        {
            if (deleteID_box.Text == "")
            {
                MessageBox.Show("Поле ID пустое!");
            }
            else
            {
                string connectionString = "SERVER=localhost;DATABASE=dbapp_sabelnikova_aa;UID=root;PASSWORD=Sabaton#2103;";
                MySqlConnection connection = new MySqlConnection(connectionString);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM new_table WHERE id_table = " + deleteID_box.Text, connection);
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());
                cmd = new MySqlCommand("SELECT * FROM new_table", connection);
                dt.Load(cmd.ExecuteReader());
                connection.Close();
                dtGrid.DataContext = dt;
            }
        }

    }

}
