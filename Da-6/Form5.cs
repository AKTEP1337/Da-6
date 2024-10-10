using System;
using System.Windows.Forms;

namespace Da_6
{
    public partial class Form5 : Form
    {
        private string training_type_id;
        private int user_id;
        private int quantity;

        public Form5()
        {
            InitializeComponent();
        }

        public Form5(string training_type_id, int user_id, int quantity)
        {
            InitializeComponent();
            this.training_type_id = training_type_id;
            this.user_id = user_id;
            this.quantity = quantity;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label4.Text = quantity.ToString();
        }

        // Обработчик кнопки для отправки данных
        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Проверяем вводимые данные как числовые значения с учетом локали (например, использование '.' как разделителя)
            if (!double.TryParse(textBox1.Text, out double weight) || !double.TryParse(textBox2.Text, out double height))
            {
                MessageBox.Show("Пожалуйста, введите числовые значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Вычисляем индекс массы тела (BMI)
            double body_mass_index = Math.Round((height / (weight * weight) * 10000), 1);

            // Получаем текущую дату
            DateTime date = DateTime.Now;

            // Открываем новую форму с переданными параметрами
            Form7 form7 = new Form7(user_id, training_type_id, quantity, date, body_mass_index);
            form7.Show();

            // Закрываем текущую форму
            this.Close();
        }

        // Ограничение ввода для текстового поля веса (только цифры и одна точка)
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и одну точку для ввода
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) && e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        // Ограничение ввода для текстового поля роста (только цифры и одна точка)
        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Разрешаем только цифры и одну точку для ввода
            if (!char.IsControl(e.KeyChar) && (!char.IsDigit(e.KeyChar) && e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}

