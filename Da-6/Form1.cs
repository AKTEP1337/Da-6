using System.Windows.Forms;
using System.Threading;

namespace Da_6
{
    public partial class Form1 : Form
    {
        Thread th;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(open1);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }

        public void open1(object obj)
        {
            Application.Run(new Form2());
        }
        public void open2(object obj)
        {
            Application.Run(new Form3());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(open2);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
