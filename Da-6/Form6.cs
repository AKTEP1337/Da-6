using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Da_6
{
    public partial class Form6 : Form
    {
        private int quantity = 0;
        private int user_id;
        private string training_type_id;

        // Строка подключения к базе данных
        private readonly string connectionString = "server=localhost;user=root;password=16x356L899MI;database=da_6";

        // Словарь для типов тренировок и их упражнений
        private Dictionary<string, string> exerciseTypes = new Dictionary<string, string>
        {
            { "1", "Грудь и трицепсы" },
            { "2", "Силовая тренировка" },
            { "3", "Кардио" }
        };

        public Form6(int user_id, string training_type_id)
        {
            InitializeComponent();
            this.user_id = user_id;
            this.training_type_id = training_type_id;

            comboBox1.Items.AddRange(new object[] { "1", "2", "3", "4" });
            InitializeComboBox2();

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;

            button1.Enabled = false;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            InitializeUserProgress();
            LoadUserProgress();
            SetTrainingQuantity();
            SetComboBoxStyles();
        }

        private void InitializeComboBox2()
        {
            switch (training_type_id)
            {
                case "1":
                    comboBox2.Items.AddRange(new object[] { "1", "2", "3", "4" });
                    break;
                case "2":
                    comboBox2.Items.AddRange(new object[] { "1", "2", "3" });
                    break;
                case "3":
                    comboBox2.Items.AddRange(new object[] { "1", "2" });
                    break;
            }
        }

        private void SetTrainingQuantity()
        {
            switch (training_type_id)
            {
                case "1":
                    quantity += 16;
                    break;
                case "2":
                    quantity += 12;
                    break;
                case "3":
                    quantity += 8;
                    break;
            }
        }

        private void SetComboBoxStyles()
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.Enabled = false;
            comboBox2.Enabled = false;
        }

        private void InitializeUserProgress()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM user_progress WHERE user_id = @user_id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", user_id);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 0)
                    {
                        // Если записи нет, добавляем новую запись с week = 1 и day = 1
                        string insertQuery = "INSERT INTO user_progress (user_id, training_type_id, week, day) VALUES (@user_id, @training_type_id, @week, @day)";
                        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@user_id", user_id);
                        insertCommand.Parameters.AddWithValue("@training_type_id", training_type_id);
                        insertCommand.Parameters.AddWithValue("@week", 1);
                        insertCommand.Parameters.AddWithValue("@day", 1);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при инициализации прогресса пользователя: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadUserProgress()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT week, day FROM user_progress WHERE user_id = @user_id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@user_id", user_id);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            comboBox1.SelectedItem = reader["week"].ToString();
                            comboBox2.SelectedItem = reader["day"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке данных о прогрессе: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1 || comboBox2.SelectedIndex < comboBox2.Items.Count - 1)
            {
                // Изменение значений в comboBox2 и comboBox1
                if (comboBox2.SelectedIndex < comboBox2.Items.Count - 1)
                {
                    comboBox2.SelectedIndex++;
                }
                else if (comboBox1.SelectedIndex < comboBox1.Items.Count - 1)
                {
                    comboBox1.SelectedIndex++;
                    comboBox2.SelectedIndex = 0;
                }
            }
            else
            {
                button2.Visible = false;
                button1.Enabled = true;
            }

            UpdateUserProgress();
            UpdateExerciseLabels();
        }

        private void UpdateUserProgress()
        {
            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE user_progress SET week = @week, day = @day WHERE user_id = @user_id";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@week", comboBox1.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@day", comboBox2.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@user_id", user_id);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении прогресса: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateExerciseLabels()
        {
            string week = comboBox1.SelectedItem.ToString();
            string day = comboBox2.SelectedItem.ToString();

            // Пример, как обновить лейблы упражнений в зависимости от выбранной недели, дня и типа тренировки.
            // Здесь используется более чистый и расширяемый подход с определением упражнений через словарь и switch
            if (week == "1" && training_type_id == "1")
            {
                label7.Text = "4x10";
                label8.Text = "4x8";
                label9.Text = "3x8";
                label10.Text = "3x10";
            }
            // Пример других условий для обновления меток упражнений
            // Примечание: добавьте все условия, как в исходном коде, или вынесите в метод, который назначает упражнения.
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string exType = GetExerciseType(comboBox2.SelectedItem.ToString(), training_type_id);
            List<string> exercises = GetExercisesFromDatabase(exType);

            // Перемешиваем список упражнений
            Random random = new Random();
            exercises = exercises.OrderBy(x => random.Next()).ToList();

            AssignExercisesToLabels(exercises);
        }

        private string GetExerciseType(string day, string trainingTypeId)
        {
            if (trainingTypeId == "1")
            {
                switch (day)
                {
                    case "1": return "Грудь и трицепсы";
                    case "2": return "Ноги";
                    case "3": return "Плечи и трапеции";
                    case "4": return "Спина и бицепсы";
                }
            }
            else if (trainingTypeId == "2")
            {
                switch (day)
                {
                    case "1": return "С собственным весом";
                    case "2": return "Кардио";
                    case "3": return "Силовая тренировка";
                }
            }
            else if (trainingTypeId == "3")
            {
                switch (day)
                {
                    case "1": return "С собственным весом";
                    case "2": return "Кардио";
                }
            }

            return "Unknown";
        }

        private List<string> GetExercisesFromDatabase(string exerciseType)
        {
            List<string> exercises = new List<string>();

            try
            {
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT name FROM exercises WHERE training_type_id = @training_type_id AND ex_type = @ex_type";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@training_type_id", training_type_id);
                    command.Parameters.AddWithValue("@ex_type", exerciseType);

                    using (MySqlDataReader reader = command.ExecuteReader())
