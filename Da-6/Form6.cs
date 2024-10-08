using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Da_6.Form3;
using static Da_6.Form4;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using static System.Windows.Forms.DataFormats;

namespace Da_6
{
    public partial class Form6 : Form
    {

        private int quantity = 0;
        private int user_id;
        private string training_type_id;
        public Form6()
        {

        }

        public Form6(int user_id, string training_type_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.training_type_id = training_type_id;

            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");

            switch (training_type_id)
            {
                case "1":
                    comboBox2.Items.Add("1");
                    comboBox2.Items.Add("2");
                    comboBox2.Items.Add("3");
                    comboBox2.Items.Add("4");
                    break;

                case "2":
                    comboBox2.Items.Add("1");
                    comboBox2.Items.Add("2");
                    comboBox2.Items.Add("3");
                    break;

                case "3":
                    comboBox2.Items.Add("1");
                    comboBox2.Items.Add("2");
                    break;


            }
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            button1.Enabled = false;

        }
        private void Form6_Load(object sender, EventArgs e)
        {
            string connectionString1 = "server=localhost;user=root;password=16x356L899MI;database=da_6";

            MySqlConnection connection1 = new MySqlConnection(connectionString1);

            string query1 = "SELECT COUNT(*) FROM user_progress WHERE user_id = @user_id";
            MySqlCommand command1 = new MySqlCommand(query1, connection1);
            connection1.Open();
            command1.Parameters.AddWithValue("@user_id", user_id);
            int count = Convert.ToInt32(command1.ExecuteScalar());

            if (count == 0)
            {
                // Если записи нет, добавляем новую запись с week = 1 и day = 1
                query1 = "INSERT INTO user_progress (user_id,training_type_id, week, day) VALUES (@user_id, @training_type_id, @week, @day)";
                command1 = new MySqlCommand(query1, connection1);
                command1.Parameters.AddWithValue("@training_type_id", training_type_id);
                command1.Parameters.AddWithValue("@user_id", user_id);
                command1.Parameters.AddWithValue("@week", 1);
                command1.Parameters.AddWithValue("@day", 1);
                command1.ExecuteNonQuery();
            }

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;


            // Соединение с базой данных
            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // Запрос на получение значений из таблицы
            string query = "SELECT week, day FROM da_6.user_progress WHERE user_id = @user_id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@user_id", user_id);
            MySqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.SelectedItem = reader["week"].ToString();
                comboBox2.SelectedItem = reader["day"].ToString();
            }

            reader.Close();
            connection.Close();


            if (training_type_id == "1")
            {
                quantity += 16;
            }
            else if (training_type_id == "2")
            {
                quantity += 12;
            }
            else if (training_type_id == "3")
            {
                quantity += 8;
            }




        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1 || comboBox2.SelectedIndex < comboBox2.Items.Count - 1)
            {

                // Change the value of comboBox2
                if (comboBox2.SelectedIndex < comboBox2.Items.Count - 1)
                {
                    comboBox2.SelectedIndex++;
                }
                else
                {
                    // If comboBox2 has reached the end, change the value of comboBox1
                    if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
                    {
                        comboBox1.SelectedIndex++;
                        comboBox2.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                // Hide the button
                button2.Visible = false;
                button1.Enabled = true;
            }

            // Соединение с базой данных
            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            // Запрос на обновление значений в таблице
            string query = "UPDATE user_progress SET week = @week, day = @day WHERE user_id = @user_id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@week", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("@day", comboBox2.SelectedItem.ToString());
            command.Parameters.AddWithValue("@training_type_id", training_type_id);
            command.Parameters.AddWithValue("@user_id", user_id);
            command.ExecuteNonQuery();
            connection.Close();


            if(comboBox1.SelectedItem.ToString() == "1" && training_type_id == "1")
            {
                label7.Text = "4x10";
                label8.Text = "4x8";
                label9.Text = "3x8";
                label10.Text = "3x10";
            }
            else if (comboBox1.SelectedItem.ToString() == "2" && training_type_id == "1")
            {
                label7.Text = "4x12";
                label8.Text = "4x10";
                label9.Text = "3x10";
                label10.Text = "3x12";
            }

            else if (comboBox1.SelectedItem.ToString() == "3" && training_type_id == "1")
            {
                label7.Text = "4x10";
                label8.Text = "4x8";
                label9.Text = "3x8";
                label10.Text = "3x10";
            }

            else if (comboBox1.SelectedItem.ToString() == "4" && training_type_id == "1")
            {
                label7.Text = "4x8";
                label8.Text = "4x6";
                label9.Text = "3x6";
                label10.Text = "3x8";
            }

            else if (comboBox2.SelectedItem.ToString() == "1" && comboBox1.SelectedItem.ToString() == "1" && training_type_id == "2")
            {
                label7.Text = "4x8";
                label8.Text = "5x12";
                label9.Text = "4x8";
                label10.Text = "5x10";
            }

            else if (comboBox2.SelectedItem.ToString() == "2" && comboBox1.SelectedItem.ToString() == "1" && training_type_id == "2")
            {
                label7.Text = "4x20";
                label8.Text = "5x25";
                label9.Text = "4x15";
                label10.Text = "5x25";
            }

            else if (comboBox2.SelectedItem.ToString() == "3" && comboBox1.SelectedItem.ToString() == "1" && training_type_id == "2")
            {
                label7.Text = "4x8";
                label8.Text = "5x10";
                label9.Text = "4x8";
                label10.Text = "5x8";
            }

            else if (comboBox2.SelectedItem.ToString() == "1" && comboBox1.SelectedItem.ToString() == "2" && training_type_id == "2")
            {
                label7.Text = "4x10";
                label8.Text = "5x12";
                label9.Text = "4x10";
                label10.Text = "5x12";
            }

            else if (comboBox2.SelectedItem.ToString() == "2" && comboBox1.SelectedItem.ToString() == "2" && training_type_id == "2")
            {
                label7.Text = "4x25";
                label8.Text = "5x25";
                label9.Text = "4x20";
                label10.Text = "5x25";
            }

            else if (comboBox2.SelectedItem.ToString() == "3" && comboBox1.SelectedItem.ToString() == "2" && training_type_id == "2")
            {
                label7.Text = "4x10";
                label8.Text = "5x12";
                label9.Text = "4x10";
                label10.Text = "5x10";
            }
            else if (comboBox2.SelectedItem.ToString() == "1" && comboBox1.SelectedItem.ToString() == "3" && training_type_id == "2")
            {
                label7.Text = "4x10";
                label8.Text = "5x12";
                label9.Text = "4x10";
                label10.Text = "5x10";
            }

            else if (comboBox2.SelectedItem.ToString() == "2" && comboBox1.SelectedItem.ToString() == "3" && training_type_id == "2")
            {
                label7.Text = "4x25";
                label8.Text = "5x25";
                label9.Text = "4x20";
                label10.Text = "5x25";
            }

            else if (comboBox2.SelectedItem.ToString() == "3" && comboBox1.SelectedItem.ToString() == "3" && training_type_id == "2")
            {
                label7.Text = "4x8";
                label8.Text = "5x10";
                label9.Text = "4x8";
                label10.Text = "5x8";
            }
            else if (comboBox2.SelectedItem.ToString() == "1" && comboBox1.SelectedItem.ToString() == "4" && training_type_id == "2")
            {
                label7.Text = "4x14";
                label8.Text = "5x12";
                label9.Text = "4x12";
                label10.Text = "5x12";
            }

            else if (comboBox2.SelectedItem.ToString() == "2" && comboBox1.SelectedItem.ToString() == "4" && training_type_id == "2")
            {
                label7.Text = "4x20";
                label8.Text = "5x25";
                label9.Text = "4x20";
                label10.Text = "5x25";
            }

            else if (comboBox2.SelectedItem.ToString() == "3" && comboBox1.SelectedItem.ToString() == "4" && training_type_id == "2")
            {
                label7.Text = "4x10";
                label8.Text = "5x12";
                label9.Text = "4x8";
                label10.Text = "5x8";
            }

            else if (comboBox1.SelectedItem.ToString() == "1" && training_type_id == "3")
            {
                label7.Text = "4x25";
                label8.Text = "4x20";
                label9.Text = "5x20";
                label10.Text = "4x15";
            }

            else if (comboBox1.SelectedItem.ToString() == "2" && training_type_id == "3")
            {
                label7.Text = "5x20";
                label8.Text = "4x15";
                label9.Text = "4x25";
                label10.Text = "5x15";
            }

            else if (comboBox1.SelectedItem.ToString() == "3" && training_type_id == "3")
            {
                label7.Text = "5x20";
                label8.Text = "5x15";
                label9.Text = "4x25";
                label10.Text = "5x15";
            }

            else if (comboBox1.SelectedItem.ToString() == "4" && training_type_id == "3")
            {
                label7.Text = "5x20";
                label8.Text = "5x15";
                label9.Text = "4x25";
                label10.Text = "5x15";
            }



        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            // Соединение с базой данных
            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string ex_type = ""; // Initialize ex_type with an empty string

            if (comboBox2.SelectedItem.ToString() == "1" && training_type_id == "1")
            {
                ex_type = "Грудь и трицепсы";
            }
            else if (comboBox2.SelectedItem.ToString() == "2" && training_type_id == "1")
            {
                ex_type = "Ноги";
            }
            else if (comboBox2.SelectedItem.ToString() == "3" && training_type_id == "1")
            {
                ex_type = "Плечи и трапеции";
            }
            else if (comboBox2.SelectedItem.ToString() == "4" && training_type_id == "1")
            {
                ex_type = "Спина и бицепсы";
            }
            else if (comboBox2.SelectedItem.ToString() == "1" && training_type_id == "2")
            {
                ex_type = "С собственным весом";
            }
            else if (comboBox2.SelectedItem.ToString() == "2" && training_type_id == "2")
            {
                ex_type = "Кардио";
            }
            else if (comboBox2.SelectedItem.ToString() == "3" && training_type_id == "2")
            {
                ex_type = "Силовая тренировка";
            }
            else if (comboBox2.SelectedItem.ToString() == "1" && training_type_id == "3")
            {
                ex_type = "С собственным весом";
            }
            else if (comboBox2.SelectedItem.ToString() == "2" && training_type_id == "3")
            {
                ex_type = "Кардио";
            }
            else
            {
                ex_type = "Unknown"; // Assign a default value when conditions are not met
            }

            // Запрос на получение упражнений из таблицы
            string query = "SELECT name FROM exercises WHERE training_type_id = @training_type_id AND ex_type = @ex_type";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@training_type_id", training_type_id);
            command.Parameters.AddWithValue("@ex_type", ex_type); // Исправлена ошибка
            MySqlDataReader reader = command.ExecuteReader();

            List<string> exercises = new List<string>();
            while (reader.Read())
            {
                exercises.Add(reader["name"].ToString());
            }

            reader.Close();
            connection.Close();

            // Shuffle the list of exercises
            Random random = new Random();
            exercises = exercises.OrderBy(x => random.Next()).ToList();

            List<string> assignedExercises = new List<string>();

            // ...

            // Назначение упражнений меткам
            if (exercises.Count >= 4)
            {
                for (int i = 0; i < 4; i++)
                {
                    string exercise = exercises[i];
                    while (assignedExercises.Contains(exercise))
                    {
                        exercises.Remove(exercise);
                        exercise = exercises[random.Next(exercises.Count)];
                    }
                    assignedExercises.Add(exercise);
                    switch (i)
                    {
                        case 0:
                            label1.Text = exercise;
                            break;
                        case 1:
                            label2.Text = exercise;
                            break;
                        case 2:
                            label4.Text = exercise;
                            break;
                        case 3:
                            label5.Text = exercise;
                            break;
                    }
                }
            }
            else
            {
                // Если упражнений меньше 4, то заполняем метки пустыми значениями
                label1.Text = "";
                label2.Text = "";
                label4.Text = "";
                label5.Text = "";
            }

            label3.Text = $"День {comboBox2.SelectedItem.ToString()}: {ex_type}";


        }
        private void Form6_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(training_type_id, user_id, quantity);
            form5.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            


        }
    }
}
