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
    // Основной класс формы
    public partial class Form3 : Form
    {
        // Поток для открытия других форм
        Thread th;
        
        // Свойства для хранения User ID и Training Type ID
        public int user_id { get; private set; } 
        public string training_type_id { get; private set; }

        // Переменная, которая нигде не используется
        public int govno;

        // Свойство для хранения пола пользователя
        public string UserGender { get; private set; }

        // Конструктор формы, инициализация компонентов
        public Form3()
        {
            InitializeComponent();
        }

        // Обработчик события кнопки "Закрыть"
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close(); // Закрытие формы
            th = new Thread(open1); // Открываем Form1 в новом потоке
            th.SetApartmentState(ApartmentState.STA); // Устанавливаем поток в STA для правильной работы с UI
            th.Start(); // Запускаем поток
        }

        // Метод для открытия Form1
        public void open1(object obj)
        {
            Application.Run(new Form1()); // Открытие Form1
        }

        // Метод для открытия Form6 с передачей данных (user_id, training_type_id)
        public void open2(int user_id, string training_type_id)
        {
            Application.Run(new Form6(user_id, training_type_id)); // Открытие Form6
        }

        // Строка подключения к базе данных
        private string connectionString = "server=localhost;user=root;database=da_6;password=16x356L899MI;";

        // Обработчик события загрузки формы (пока не используется)
        private void Form3_Load(object sender, EventArgs e)
        {
            // Здесь можно было бы загружать дополнительные данные, если требуется
        }

        // Обработчик кнопки "Логин"
        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text; // Логин, введенный пользователем
            string password = textBox2.Text; // Пароль, введенный пользователем

            // Открываем соединение с базой данных
            using (MySqlConnection connect = new MySqlConnection(connectionString))
            {
                try
                {
                    connect.Open(); // Открываем соединение

                    // Проверяем, существует ли пользователь с таким логином
                    string checkUserExistsQuery = "SELECT COUNT(*) FROM da_6.users WHERE login = @login";
                    using (MySqlCommand command = new MySqlCommand(checkUserExistsQuery, connect))
                    {
                        command.Parameters.AddWithValue("@login", login); // Передаем параметр логина
                        int userCount = Convert.ToInt32(command.ExecuteScalar()); // Выполняем запрос

                        // Если пользователя с таким логином нет
                        if (userCount == 0)
                        {
                            MessageBox.Show("Пользователя с таким логином не существует."); // Сообщение об ошибке
                            return; // Выход из метода
                        }
                    }

                    // Если пользователь существует, проверяем правильность пароля
                    string query2 = "SELECT user_id, user_gender FROM da_6.users WHERE login = @login AND password = @password";
                    using (MySqlCommand command = new MySqlCommand(query2, connect))
                    {
                        command.Parameters.AddWithValue("@login", login); // Передаем логин
                        command.Parameters.AddWithValue("@password", password); // Передаем пароль

                        using (var reader = command.ExecuteReader()) // Выполняем запрос для получения данных о пользователе
                        {
                            if (reader.Read()) // Если запись найдена
                            {
                                user_id = Convert.ToInt32(reader["user_id"]); // Получаем user_id
                                UserGender = Convert.ToString(reader["user_gender"]); // Получаем пол пользователя

                                // Открываем новое соединение для получения типа тренировки пользователя
                                using (MySqlConnection connect2 = new MySqlConnection(connectionString))
                                {
                                    connect2.Open(); // Открываем новое соединение

                                    // Запрос для получения типа тренировки пользователя
                                    string trainingTypeQuery = "SELECT training_type_id FROM da_6.user_results WHERE user_id = @user_id";
                                    using (MySqlCommand trainingTypeCommand = new MySqlCommand(trainingTypeQuery, connect2))
                                    {
                                        trainingTypeCommand.Parameters.AddWithValue("@user_id", user_id); // Передаем user_id
                                        using (var trainingTypeReader = trainingTypeCommand.ExecuteReader())
                                        {
                                            if (trainingTypeReader.Read()) // Если данные найдены
                                            {
                                                training_type_id = Convert.ToString(trainingTypeReader["training_type_id"]); // Получаем training_type_id
                                            }
                                        }
                                    }
                                }

                                this.Close(); // Закрытие текущей формы

                                // Открытие Form6 с передачей данных
                                th = new Thread(() => open2(user_id, training_type_id)); 
                                th.SetApartmentState(ApartmentState.STA); // Устанавливаем поток в STA
                                th.Start(); // Запускаем поток
                            }
                            else
                            {
                                MessageBox.Show("Неверно введен пароль"); // Ошибка, если пароль неверный
                            }
                        }
                    }
                }
                catch (Exception ex) // Обработка ошибок
                {
                    MessageBox.Show("Произошла ошибка: " + ex.Message); // Сообщение об ошибке
                }
            }
        }

        // Этот метод не используется в коде, но его можно использовать для обработки кликов по элементу label
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

