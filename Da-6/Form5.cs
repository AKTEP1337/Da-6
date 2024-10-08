using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(textBox1.Text, out double weight) || !double.TryParse(textBox2.Text, out double height))
            {
                MessageBox.Show("Пожалуйста, введите числовые значения", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double body_mass_index1 = Math.Round((height / (weight * weight) * 10000), 1);

            DateTime date = DateTime.Now;

            Form7 form7 = new Form7(user_id, training_type_id, quantity, date, body_mass_index1);
            form7.Show();
            this.Hide();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.' && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

    }
}
