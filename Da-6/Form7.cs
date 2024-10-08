using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Threading;
using static Da_6.Form4;

namespace Da_6
{


    public partial class Form7 : Form
    {
        Thread th;
        private int user_id;
        private string training_type_id;
        private int quantity;
        private DateTime date;
        private double body_mass_index1;

        public Form7()
        {
            InitializeComponent();
        }
        public Form7(int user_id, string training_type_id, int quantity, DateTime date, double body_mass_index1)
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.user_id = user_id;
            this.training_type_id = training_type_id;
            this.quantity = quantity;
            this.date = date;
            this.body_mass_index1 = body_mass_index1;
            LoadTrainingTypes();
        }
        private void Form7_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // Код для получения значения body_mass_index
            string query = "SELECT body_mass_index FROM user_results WHERE user_id = @user_id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@user_id", user_id);

            object result = command.ExecuteScalar();
            double bodyMassIndex = Convert.ToDouble(result);
            double und = Math.Abs(((body_mass_index1 - bodyMassIndex) / bodyMassIndex) * 100);

            // Код для получения значений name и second_name
            query = "SELECT name, second_name FROM users WHERE user_id = @user_id";
            command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@user_id", user_id);
            MySqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                string name = reader["name"].ToString();
                string secondName = reader["second_name"].ToString();

                if (body_mass_index1 > bodyMassIndex)
                {
                    label2.Text = $"{name} {secondName}, ваш индекс массы тела увеличился на {Math.Round(und, 1)}%";
                }
                else if (body_mass_index1 < bodyMassIndex)
                {
                    label2.Text = $"{name} {secondName}, ваш индекс массы тела уменьшился на {Math.Round(und, 1)}%";
                }

                else
                {
                    label2.Text = $"{name} {secondName}, ваш индекс массы тела не изменился";
                }
            }
            else
            {
                label1.Text = "Результат не найден";
            }

            reader.Close();
            connection.Close();


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

        private void LoadTrainingTypes()
        {
            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
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

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип дальнейших тренировок");
                return;
            }

            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Обновляем значения в таблице user_results
                string query = "UPDATE user_results SET training_type_id = @training_type_id, quantity = @quantity, date = @date, body_mass_index = @body_mass_index WHERE user_id = @user_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@training_type_id", ((comboboxitem)comboBox1.SelectedItem).Value);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@body_mass_index", body_mass_index1);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.ExecuteNonQuery();

                // Обновляем значения в таблице user_progress
                query = "UPDATE user_progress SET training_type_id = @training_type_id, week = 0, day = 0 WHERE user_id = @user_id";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@training_type_id", ((comboboxitem)comboBox1.SelectedItem).Value);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.ExecuteNonQuery();
            }

            Form6 form6 = new Form6(user_id, ((comboboxitem)comboBox1.SelectedItem).Value);
            form6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип дальнейших тренировок");
                return;
            }

            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                // Обновляем значения в таблице user_results
                string query = "UPDATE user_results SET training_type_id = @training_type_id, quantity = @quantity, date = @date, body_mass_index = @body_mass_index WHERE user_id = @user_id";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@training_type_id", ((comboboxitem)comboBox1.SelectedItem).Value);
                command.Parameters.AddWithValue("@quantity", quantity);
                command.Parameters.AddWithValue("@date", date);
                command.Parameters.AddWithValue("@body_mass_index", body_mass_index1);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.ExecuteNonQuery();

                // Обновляем значения в таблице user_progress
                query = "UPDATE user_progress SET training_type_id = @training_type_id, week = 0, day = 0 WHERE user_id = @user_id";
                command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@training_type_id", ((comboboxitem)comboBox1.SelectedItem).Value);
                command.Parameters.AddWithValue("@user_id", user_id);
                command.ExecuteNonQuery();
            }

            this.Close();
            th = new Thread(open1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();


        }

        public void open1(object obj)
        {
            Application.Run(new Form1());
        }

    }
}

