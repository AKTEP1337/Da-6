using System;
using System.Threading;
using System.Windows.Forms;

namespace Da_6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Обработчик кнопки для открытия Form2
        private void button1_Click(object sender, EventArgs e)
        {
            // Запускаем Form2 в отдельном потоке, без закрытия Form1
            Thread th = new Thread(openForm2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        // Метод для открытия Form2
        public void openForm2()
        {
            Application.Run(new Form2());
        }

        // Обработчик кнопки для открытия Form3
        private void button3_Click(object sender, EventArgs e)
        {
            // Запускаем Form3 в отдельном потоке, без закрытия Form1
            Thread th = new Thread(openForm3);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        // Метод для открытия Form3
        public void openForm3()
        {
            Application.Run(new Form3());
        }

        // Оставляем пустую обработку для label1_Click, если она не используется
        private void label1_Click(object sender, EventArgs e)
        {
        }
    }
}
