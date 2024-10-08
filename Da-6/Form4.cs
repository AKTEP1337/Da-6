using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography.X509Certificates;
using MySqlConnector;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Xml.Linq;
using System.Windows.Forms.Design.Behavior;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic.ApplicationServices;
using static System.Windows.Forms.DataFormats;

namespace Da_6
{
    public partial class Form4 : Form
    {
        Thread th;


        public int xiu;
        private string login;
        private int user_id;
        private string user_gender;
        string connectionString = "server=localhost;user=root;database=da_6;password=16x356L899MI;";


        public Form4(string login)
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.login = login;
            Loaduser_id();
            LoadTrainingTypes();
        }


        private void Loaduser_id()
        {
            using (var connection = new MySqlConnection("server=localhost;user=root;database=da_6;password=16x356L899MI;"))
            {
                connection.Open();
                var command = new MySqlCommand("SELECT user_id FROM da_6.users WHERE login = @login", connection);
                command.Parameters.AddWithValue("@login", login);
                user_id = Convert.ToInt32(command.ExecuteScalar());
            }
        }

        private void LoadTrainingTypes()
        {
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT training_type_id, type_name FROM da_6.training_types"; // Предполагается, что у вас есть таблица training_types 
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var item = new comboboxitem
                    {
                        Text = reader["type_name"].ToString(),
                        Value = reader["training_type_id"].ToString()
                    };

                    comboBox1.Items.Add(item);


                }
                reader.Close();
            }
        }
        public Form4()
        {

        }

        public class comboboxitem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString() => Text;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = comboBox1.SelectedItem.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Код для удаления данных о пользователе из таблицы users
    string connectionString = "server=localhost;user=root;database=da_6;password=16x356L899MI;";
            string query = "DELETE FROM users WHERE login = @login";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@login", login);
                command.ExecuteNonQuery();
            }

            this.Close();
            th = new Thread(open1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public void open1(object obj)
        {
            Application.Run(new Form2());
        }


        public void open2(int user_id, string training_type_id)
        {
            Application.Run(new Form6(user_id, training_type_id));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var selectedItem = comboBox1.SelectedItem;
            if (selectedItem != null)
            {
                // Получаем значение id выбранного типа тренировки 
                var training_type_id = ((dynamic)selectedItem).Value;
                // Теперь вы можете использовать trainingTypeId для вашего запроса 



                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text))
                {
                    MessageBox.Show("Ошибка: Пожалуйста, введите значения в поля веса и роста.");
                    return;
                }

                if (!double.TryParse(textBox1.Text, out double weight) || !double.TryParse(textBox2.Text, out double height))
                {
                    MessageBox.Show("Ошибка: Пожалуйста, введите числовые значения в поля веса и роста.");
                    return;
                }

                SaveTrainingTypeId(training_type_id);

                int xui = 0;
                int xui2 = 0;
                this.Close();
                th = new Thread(() => open2(user_id, training_type_id));
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите тип тренировки.");
            }
        }
        // Метод для сохранения training_type_id 
        private void SaveTrainingTypeId(string training_type_id)
        {

            // Параметры подключения к базе данных
            string connectionString = "server=localhost;user=root;database=da_6;password=16x356L899MI;";
            DateTime date = DateTime.Now;
            string query = "INSERT INTO user_results (user_id, training_type_id, quantity, date, body_mass_index) VALUES (@user_id, @training_type_id,@quantity, @date, @body_mass_index)";
            double weight = double.Parse(textBox1.Text);
            double height = double.Parse(textBox2.Text);
            double body_mass_index = Math.Round((height / (weight * weight) * 10000), 1);
            double quantity = 0;

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@user_id", user_id);
                cmd.Parameters.AddWithValue("@training_type_id", training_type_id);
                cmd.Parameters.AddWithValue("@quantity", quantity);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.Parameters.AddWithValue("@body_mass_index", body_mass_index);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Данные успешно добавлены!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }

            }
        }
        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }



    }
}
