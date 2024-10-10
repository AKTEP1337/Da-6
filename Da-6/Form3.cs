using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using MySqlConnector;
using System.Security.Cryptography;

namespace Da_6
{
    public partial class Form3 : Form
    {
        Thread th;
        public int user_id { get; private set; } // Property to store User ID
        public string training_type_id { get; private set; } // Property to store Training Type ID
        public string UserGender { get; private set; }

        // Constructor
        public Form3()
        {
            InitializeComponent();
        }

        // Utility method to hash the password
        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // Method to open the previous form
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

        // Method to handle login process
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Hash the entered password
            string hashedPassword = HashPassword(password);

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
                            return;
                        }
                    }

                    // If user exists, check the password
                    string query2 = "SELECT user_id, user_gender FROM da_6.users WHERE login = @login AND password = @password";
                    using (MySqlCommand command = new MySqlCommand(query2, connect))
                    {
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", hashedPassword);

                        using (var reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                user_id = Convert.ToInt32(reader["user_id"]);
                                UserGender = Convert.ToString(reader["user_gender"]);

                                // Retrieve the training type
                                string trainingTypeQuery = "SELECT training_type_id FROM da_6.user_results WHERE user_id = @user_id";
                                using (MySqlCommand trainingTypeCommand = new MySqlCommand(trainingTypeQuery, connect))
                                {
                                    trainingTypeCommand.Parameters.AddWithValue("@user_id", user_id);
                                    using (var trainingTypeReader = trainingTypeCommand.ExecuteReader())
                                    {
                                        if (trainingTypeReader.Read())
                                        {
                                            training_type_id = Convert.ToString(trainingTypeReader["training_type_id"]);
                                        }
                                    }
                                }

                                this.Close();
                                th = new Thread(() => open2(user_id, training_type_id));
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
            // Unused method, can be removed
        }
    }
}
