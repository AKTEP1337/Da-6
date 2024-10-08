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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.EntityFrameworkCore;
using MySqlConnector;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Da_6
{
    public partial class Form2 : Form
    {
        Thread th;
        private string user_gender;
        public Form2()
        {
            InitializeComponent();
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.Items.Add("Мужской");
            comboBox2.Items.Add("Женский");
            comboBox2.SelectedIndex = 0; // Set the first item as the default value

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


        private string connectionString = "server=localhost;user=root;database=da_6;password=16x356L899MI;";

        private void button2_Click(object sender, EventArgs e)
        {

            this.Close();
            th = new Thread(open1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        public void open1(object obj)
        {
            Application.Run(new Form1());
        }

        private void button1_Click(object sender, EventArgs e)
        {


            // Проверка на пустые поля
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) || string.IsNullOrEmpty(textBox5.Text))
            {
                MessageBox.Show("Введите все данные!", "Попробуйте заново", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Проверка на совпадение паролей
            if (textBox4.Text != textBox5.Text)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string name = textBox1.Text;
            string second_name = textBox2.Text;
            string login = textBox3.Text;
            string password = textBox4.Text;
            string double_password = textBox5.Text;

            if (password != double_password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {

                connection.Open();
                string query = "SELECT COUNT(*) FROM da_6.users WHERE login = @login";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@login", login);
                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count > 0)
                    {
                        MessageBox.Show("Пользователь с таким логином уже существует.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        query = "INSERT INTO users (user_gender, name, second_name,login, password) VALUES (@user_gender, @name, @second_name, @login, @password)";
                        using (MySqlCommand insertCommand = new MySqlCommand(query, connection))
                        {
                            insertCommand.Parameters.AddWithValue("@user_gender", user_gender);
                            insertCommand.Parameters.AddWithValue("@name", name);
                            insertCommand.Parameters.AddWithValue("@second_name", second_name);
                            insertCommand.Parameters.AddWithValue("@login", login);
                            insertCommand.Parameters.AddWithValue("@password", password); // Не забудьте позаботиться о безопасности паролей
                            insertCommand.ExecuteNonQuery();

                            MessageBox.Show("Регистрация прошла успешно!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            Form4 form4 = new Form4(login);
                            form4.Show();
                            this.Hide();
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            user_gender = comboBox2.SelectedItem.ToString();

        }
    }
}




