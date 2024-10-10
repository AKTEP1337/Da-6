using System;
using System.Windows.Forms;

namespace Da_6
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private string training_type_id;
        private int user_id;
        private int quantity;

        // Конструктор с параметрами для передачи данных в форму
        public Form5(string training_type_id, int user_id, int quantity)
        {
            InitializeComponent();
            this.training_type_id = training_type_id;
            this.user_id = user_id;
            this.quantity = quantity;
        }

        // Загрузка формы, отображение количества тренировок
        private void Form5_Load(object sender, EventArgs e)
        {
            label4.Text = quantity.ToString();
        }

        // Обработчик кнопки "Рассчитать ИМТ"
        private void button1_Click(object sender, EventArgs e)
        {
            // Проверяем, заполнены ли все поля
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем, является ли введённый вес и рост числовыми значениями
            if (!double.TryParse(textBox1.Text, out double weight) || !double.TryParse(textBox2.Text, out double height))
            {
                MessageBox.Show("Пожалуйста, введите числовые значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем, что вес и рост положительные значения
            if (weight <= 0 || height <= 0)
            {
                MessageBox.Show("Вес и рост должны быть положительными значениями", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Рассчитываем индекс массы тела (ИМТ)
            double body_mass_index1 = Math.Round(weight / (height * height), 1);

            // Получаем текущую дату
            DateTime date = DateTime.Now;

            // Создаём экземпляр следующей формы и передаём в неё параметры
            Form7 form7 = new Form7(user_id, training_type_id, quantity, date, body_mass_index1);
            form7.Show();
            this.Hide(); // Скрываем текущую форму
        }

        // Обработчик изменения текста в textBox1 (вес)
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Можно оставить пустым, если не требуется дополнительной обработки
        }

        // Обработчик события KeyPress для textBox1 (вес)
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр, точки и знака минус (только в начале)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && (e.KeyChar != '-' || textBox1.SelectionStart != 0))
            {
                e.Handled = true;
            }
        }

        // Обработчик события KeyPress для textBox2 (рост)
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем ввод только цифр и точки
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
