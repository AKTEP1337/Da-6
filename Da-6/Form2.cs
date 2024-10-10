using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using MySqlConnector;
using System.Security.Cryptography;
using System.Text;

namespace Da_6
{
    public partial class Form2 : Form
    {
        Thread th;
        private string user_gender;
        private string connectionString = "server=localhost;user=root;database=da_6;password=16x356L899MI;";

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
            // Форму можно оставить пустой, если нет необходимости в обработке события загрузки
        }

        // Метод для хэширования пароля
        private static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hash).Replace("-", "").ToLower();
            }
        }

        // Метод для проверки пустых полей
        private bool AreFieldsValid(params TextBox[] textBoxes)
        {
            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                {
                    return false;
                }
            }
            return true;
        }

        // Кнопка для регистрации нового пользователя
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверка на пустые поля
            if (!AreFieldsValid(textBox1, textBox2, textBox3, textBox4, textBox5))
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
            string password = HashPassword(textBox4.Text); // Хэшируем пароль
            string double_password = HashPassword(textBox5.Text);

            if (password != double_password)
            {
                MessageBox.Show("Пароли не совпадают!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
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
                            query = "INSERT INTO users (user_gender, name, second_name, login, password) VALUES (@user_gender, @name, @second_name, @login, @password)";
                            using (MySqlCommand insertCommand = new MySqlCommand(query, connection))
                            {
                                insertCommand.Parameters.AddWithValue("@user_gender", user_gender);
                                insertCommand.Parameters.AddWithValue("@name", name);
                                insertCommand.Parameters.AddWithValue("@second_name", second_name);
                                insertCommand.Parameters.AddWithValue("@login", login);
                                insertCommand.Parameters.AddWithValue("@password", password);
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
            catch (Exception ex)
            {
                MessageBox.Show($"Произошла ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Обработчик изменения пола
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            user_gender = comboBox2.SelectedItem.ToString();
        }

        // Кнопка для возврата в Form1
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
    }
}
