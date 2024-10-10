using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Da_6
{
    public partial class Form7 : Form
    {
        private Thread th;
        private int user_id;
        private string training_type_id;
        private int quantity;
        private DateTime date;
        private double body_mass_index1;

        private readonly string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";

        public Form7() { InitializeComponent(); }

        public Form7(int user_id, string training_type_id, int quantity, DateTime date, double body_mass_index1) : this()
        {
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
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT body_mass_index FROM user_results WHERE user_id = @user_id";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", user_id);

                    var result = command.ExecuteScalar();
                    if (result != null)
                    {
                        double bodyMassIndex = Convert.ToDouble(result);
                        double und = Math.Abs(((body_mass_index1 - bodyMassIndex) / bodyMassIndex) * 100);

                        query = "SELECT name, second_name FROM users WHERE user_id = @user_id";
                        command = new MySqlCommand(query, connection);
                        command.Parameters.AddWithValue("@user_id", user_id);
                        MySqlDataReader reader = command.ExecuteReader();

                        if (reader.Read())
                        {
                            string name = reader["name"].ToString();
                            string secondName = reader["second_name"].ToString();
                            label2.Text = $"{name} {secondName}, ваш индекс массы тела {(body_mass_index1 > bodyMassIndex ? "увеличился" : body_mass_index1 < bodyMassIndex ? "уменьшился" : "не изменился")} на {Math.Round(und, 1)}%";
                        }
                        else
                        {
                            label1.Text = "Результат не найден";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public class ComboBoxItem
        {
            public string Text { get; set; }
            public string Value { get; set; }

            public override string ToString() => Text;
        }

        private void LoadTrainingTypes()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT training_type_id, type_name FROM da_6.training_types";
                    var command = new MySqlCommand(query, connection);
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
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке типов тренировок: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Выберите тип дальнейших тренировок");
                return;
            }

            UpdateUserResults();
            UpdateUserProgress();
            OpenForm6();
        }

        private void UpdateUserResults()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE user_results SET training_type_id = @training_type_id, quantity = @quantity, date = @date, body_mass_index = @body_mass_index WHERE user_id = @user_id";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@training_type_id", ((ComboBoxItem)comboBox1.SelectedItem).Value);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@date", date);
                    command.Parameters.AddWithValue("@body_mass_index", body_mass_index1);
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении результатов пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserProgress()
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE user_progress SET training_type_id = @training_type_id, week = 0, day = 0 WHERE user_id = @user_id";
                    var command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@training_type_id", ((ComboBoxItem)comboBox1.SelectedItem).Value);
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении прогресса пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OpenForm6()
        {
            Form6 form6 = new Form6(user_id, ((ComboBoxItem)comboBox1.SelectedItem).Value);
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

            UpdateUserResults();
            UpdateUserProgress();
            this.Close();

            th = new Thread(OpenForm1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void OpenForm1(object obj)
        {
            Application.Run(new Form1());
        }
    }
}
