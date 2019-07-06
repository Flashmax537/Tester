using System;
using System.Windows.Forms;
using mark;

namespace Tester
{
    public partial class Form4 : Form
    {
        double Mark;
        public Form4(string Name, string Theme, int NumbersOfQwest, int RightAnswers)
        {
            InitializeComponent();
            label1.Text += Name;
            label2.Text = Theme;
            label3.Text += NumbersOfQwest.ToString();
            label4.Text += RightAnswers.ToString();
            Mark = mark.MarkClass.Mark(NumbersOfQwest, RightAnswers);
            label5.Text += Mark.ToString() + "%";
        }
        #region Выход
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
