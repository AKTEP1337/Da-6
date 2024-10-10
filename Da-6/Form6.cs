using Microsoft.VisualBasic.ApplicationServices;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Da_6
{
    public partial class Form6 : Form
    {
        // Поля формы
        private int quantity = 0;       // Количество тренировок
        private int user_id;             // ID пользователя
        private string training_type_id; // Тип тренировки

        // Конструктор формы
        public Form6() { }

        // Конструктор с передачей параметров (ID пользователя и типа тренировки)
        public Form6(int user_id, string training_type_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.training_type_id = training_type_id;

            // Заполняем ComboBox1 с количеством тренировок по неделям
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");

            // Заполняем ComboBox2 в зависимости от типа тренировки
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

            button1.Enabled = false; // Кнопка неактивна, пока не выполнены условия
        }

        // Загружается при старте формы
        private void Form6_Load(object sender, EventArgs e)
        {
            string connectionString1 = "server=localhost;user=root;password=16x356L899MI;database=da_6";

            MySqlConnection connection1 = new MySqlConnection(connectionString1);

            // Запрос на проверку, есть ли прогресс пользователя в базе
            string query1 = "SELECT COUNT(*) FROM user_progress WHERE user_id = @user_id";
            MySqlCommand command1 = new MySqlCommand(query1, connection1);
            connection1.Open();
            command1.Parameters.AddWithValue("@user_id", user_id);
            int count = Convert.ToInt32(command1.ExecuteScalar());

            // Если нет записи, то добавляем нового пользователя с week=1, day=1
            if (count == 0)
            {
                query1 = "INSERT INTO user_progress (user_id, training_type_id, week, day) VALUES (@user_id, @training_type_id, @week, @day)";
                command1 = new MySqlCommand(query1, connection1);
                command1.Parameters.AddWithValue("@training_type_id", training_type_id);
                command1.Parameters.AddWithValue("@user_id", user_id);
                command1.Parameters.AddWithValue("@week", 1);
                command1.Parameters.AddWithValue("@day", 1);
                command1.ExecuteNonQuery();
            }

            // Блокируем редактирование ComboBox'ов
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;

            // Получение текущих значений недели и дня из базы
            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT week, day FROM user_progress WHERE user_id = @user_id";
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

            // Устанавливаем количество тренировок в зависимости от типа тренировки
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

        // Нажатие кнопки "Следующий день"
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1 || comboBox2.SelectedIndex < comboBox2.Items.Count - 1)
            {
                if (comboBox2.SelectedIndex < comboBox2.Items.Count - 1)
                {
                    comboBox2.SelectedIndex++;
                }
                else
                {
                    if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
                    {
                        comboBox1.SelectedIndex++;
                        comboBox2.SelectedIndex = 0;
                    }
                }
            }
            else
            {
                button2.Visible = false;
                button1.Enabled = true;
            }

            // Обновляем прогресс в базе данных
            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "UPDATE user_progress SET week = @week, day = @day WHERE user_id = @user_id";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@week", comboBox1.SelectedItem.ToString());
            command.Parameters.AddWithValue("@day", comboBox2.SelectedItem.ToString());
            command.Parameters.AddWithValue("@user_id", user_id);
            command.ExecuteNonQuery();
            connection.Close();

            // Обновляем метки с упражнениями в зависимости от недели, дня и типа тренировки
            UpdateExercises();
        }

        // Обновление упражнений в зависимости от типа тренировки
        private void UpdateExercises()
        {
            if (comboBox1.SelectedItem.ToString() == "1" && training_type_id == "1")
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
            // Другие условия для типов тренировок и дней...
        }

        // Обработчик изменения ComboBox2 (день тренировки)
        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // Получаем тип упражнения на основе значения ComboBox'ов и типа тренировки
            string ex_type = GetExerciseType();

            // Запрос на получение упражнений из базы данных
            string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();

            string query = "SELECT name FROM exercises WHERE training_type_id = @training_type_id AND ex_type = @ex_type";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@training_type_id", training_type_id);
            command.Parameters.AddWithValue("@ex_type", ex_type);
            MySqlDataReader reader = command.ExecuteReader();

            List<string> exercises = new List<string>();
            while (reader.Read())
            {
                exercises.Add(reader["name"].ToString());
            }

            reader.Close();
            connection.Close();

            // Перемешиваем список упражнений
            Random random = new Random();
            exercises = exercises.OrderBy(x => random.Next()).ToList();

            // Назначаем упражнения меткам
            AssignExercisesToLabels(exercises);
        }

        // Получаем тип упражнения
        private string GetExerciseType()
        {
            if (comboBox2.SelectedItem.ToString() == "1" && training_type_id == "1") return "Грудь и трицепсы";
            if (comboBox2.SelectedItem.ToString() == "2" && training_type_id == "1") return "Ноги";
            // Другие условия для типов упражнений
            return "Unknown";
        }

        // Назначение упражнений меткам
        private void AssignExercisesToLabels(List<string> exercises)
        {
            List<string> assignedExercises = new List<string>();

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
                label1.Text = "";
                label2.Text = "";
                label4.Text = "";
                label5.Text = "";
            }

            label3.Text = $"День {comboBox2.SelectedItem.ToString()}: {GetExerciseType()}";
        }

        // Закрытие формы
        private void Form6_FormClosing(object sender, FormClosingEventArgs e) { }

        // Переключение на другую форму
        private void button1_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5(training_type_id, user_id, quantity);
            form5.Show();
            this.Hide();
        }
    }
}
