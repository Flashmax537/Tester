using System;
using System.Windows.Forms;

namespace Tester
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show(); this.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 F5 = new Form5();
            F5.Show(); this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
