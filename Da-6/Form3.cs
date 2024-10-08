using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using MySqlConnector;
using Microsoft.VisualBasic.ApplicationServices;

namespace Da_6
{
    public partial class Form3 : Form
    {
        Thread th;
        public int user_id { get; private set; } // Property to store User ID
        public string training_type_id { get; private set; } // Property to store Training Type ID

        public int govno;

        public string UserGender { get; private set; }


        public Form3()
        {
            InitializeComponent();
        }

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

        public void open2(int user_id, string training_type_id)
        {
            Application.Run(new Form6(user_id, training_type_id)); // Pass UserId to Form6
        }

        private string connectionString = "server=localhost;user=root;database=da_6;password=16x356L899MI;";

        private void Form3_Load(object sender, EventArgs e)
        {
            // You could load any required data here if needed
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            using (MySqlConnection connect = new MySqlConnection(connectionString))
            {
                try
                {
                    connect.Open();

                    // Check if the user exists
                    string checkUserExistsQuery = "SELECT COUNT(*) FROM da_6.users WHERE login = @login";
                    using (MySqlCommand command = new MySqlCommand(checkUserExistsQuery, connect))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        int userCount = Convert.ToInt32(command.ExecuteScalar());

                        if (userCount == 0)
                        {
                            MessageBox.Show("Пользователя с таким логином не существует.");
                            return; // Exit the method if user does not exist
                        }
                    }

                    // If the user exists, check the password
                    string query2 = "SELECT user_id, user_gender FROM da_6.users WHERE login = @login AND password = @password";
                    using (MySqlCommand command = new MySqlCommand(query2, connect))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read()) // If there are results
                            {
                                user_id = Convert.ToInt32(reader["user_id"]); // Store User ID
                                UserGender = Convert.ToString(reader["user_gender"]);

                                // Create a new MySqlConnection
                                using (MySqlConnection connect2 = new MySqlConnection(connectionString))
                                {
                                    connect2.Open();

                                    string trainingTypeQuery = "SELECT training_type_id FROM da_6.user_results WHERE user_id = @user_id";
                                    using (MySqlCommand trainingTypeCommand = new MySqlCommand(trainingTypeQuery, connect2))
                                    {
                                        trainingTypeCommand.Parameters.AddWithValue("@user_id", user_id);
                                        using (var trainingTypeReader = trainingTypeCommand.ExecuteReader())
                                        {
                                            if (trainingTypeReader.Read())
                                            {
                                                training_type_id = Convert.ToString(trainingTypeReader["training_type_id"]); // Store Training Type ID
                                            }
                                        }
                                    }
                                }

                                this.Close();
                                th = new Thread(() => open2(user_id, training_type_id)); // Pass UserId, TrainingTypeId, and UserGender to open2
                                th.SetApartmentState(ApartmentState.STA);
                                th.Start();
                            }
                            else
                            {
                                MessageBox.Show("Неверно введен пароль");
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message);
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

