using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlConnector;

namespace Da_6
{
    public partial class Form4 : Form
    {
        Thread th;
        private string login;
        private int user_id;
        string connectionString = "server=localhost;user=root;database=da_6;password=16x356L899MI;";

        public Form4(string login)
        {
            InitializeComponent();
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            this.login = login;
            LoadUserId();
            LoadTrainingTypes();
        }

        // Загрузка ID пользователя по логину
        private void LoadUserId()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    var command = new MySqlCommand("SELECT user_id FROM da_6.users WHERE login = @login", connection);
                    command.Parameters.AddWithValue("@login", login);
                    user_id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке ID пользователя: " + ex.Message);
            }
        }

        // Загрузка типов тренировки в ComboBox
        private void LoadTrainingTypes()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT training_type_id, type_name FROM da_6.training_types";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    MySqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var item = new ComboBoxItem
                        {
                            Text = reader["type_name"].ToString(),
                            Value = reader["training_type_id"].ToString()
                        };

                        comboBox1.Items.Add(item);
                    }
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при загрузке типов тренировки: " + ex.Message);
            }
        }

        // Класс для представления элемента ComboBox
        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString() => Text;
        }

        // Обработчик изменения выбранного элемента в ComboBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Действия при изменении выбранного элемента (при необходимости)
            string selectedItem = comboBox1.SelectedItem?.ToString();
        }

        // Обработчик удаления пользователя
        private void button1_Click(object sender, EventArgs e)
        {
            // Подтверждение удаления пользователя
            var confirmResult = MessageBox.Show("Вы уверены, что хотите удалить пользователя?", "Подтверждение удаления", MessageBoxButtons.YesNo);
            if (confirmResult != DialogResult.Yes) return;

            try
            {
                string query = "DELETE FROM users WHERE login = @login";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@login", login);
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Пользователь успешно удален.");
                this.Hide();
                new Form2().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении пользователя: " + ex.Message);
            }
        }

        // Обработчик кнопки для записи данных о тренировке
        private void button2_Click(object sender, EventArgs e)
        {
            var selectedItem = comboBox1.SelectedItem;
            if (selectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип тренировки.");
                return;
            }

            var training_type_id = ((ComboBoxItem)selectedItem).Value;

            // Валидация ввода веса и роста
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

            // Вычисляем индекс массы тела
            double body_mass_index = Math.Round((height / (weight * weight) * 10000), 1);

            // Сохраняем данные
            if (SaveTrainingTypeId(training_type_id, body_mass_index))
            {
                MessageBox.Show("Данные успешно добавлены!");
                this.Hide();
                new Form6(user_id, training_type_id).Show();
            }
            else
            {
                MessageBox.Show("Ошибка при добавлении данных.");
            }
        }

        // Метод для сохранения данных о тренировке
        private bool SaveTrainingTypeId(string training_type_id, double body_mass_index)
        {
            try
            {
                string query = "INSERT INTO user_results (user_id, training_type_id, quantity, date, body_mass_index) " +
                               "VALUES (@user_id, @training_type_id, @quantity, @date, @body_mass_index)";
                DateTime date = DateTime.Now;
                double quantity = 0;

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.Parameters.AddWithValue("@training_type_id", training_type_id);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@body_mass_index", body_mass_index);

                    connection.Open();
                    command.ExecuteNonQuery();
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении данных: " + ex.Message);
                return false;
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // Действия при загрузке формы (если нужно)
        }

        // Метод для открытия Form2
        public void open1(object obj)
        {
            Application.Run(new Form2());
        }
    }
}

