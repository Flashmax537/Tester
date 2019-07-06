using System;
using System.Windows.Forms;
using System.Xml;

namespace Tester
{
    public partial class Form6 : Form
    {
        XmlTextWriter testWriter;
        int count;
        public Form6(int k, XmlTextWriter Writer)
        {
            InitializeComponent();
            testWriter = Writer;
            count = k;
            this.Text = "Редактирование вопроса №" + count;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                if (textBox6.Text == textBox2.Text || textBox6.Text == textBox3.Text || textBox6.Text == textBox4.Text || textBox6.Text == textBox5.Text)
                {
                    testWriter.WriteStartElement("q" + count);
                    testWriter.WriteStartAttribute("text");
                    testWriter.WriteString(textBox1.Text);
                    testWriter.WriteEndAttribute();
                    testWriter.WriteStartAttribute("right");
                    testWriter.WriteString(textBox6.Text);
                    testWriter.WriteEndAttribute();
                    testWriter.WriteStartElement("answers");
                    testWriter.WriteString(textBox2.Text + "|" + textBox3.Text + "|" + textBox4.Text + "|" + textBox5.Text);
                    testWriter.WriteEndElement();
                    testWriter.WriteEndElement();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show("Правильный ответ не совпадает ни к одним из вариантов ответа!\n\nПодсказка: Скопируйте правильный вариант в поле правильного ответа!", "Внимание!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!");
            }
        }
        private void Form6_Load(object sender, EventArgs e)
        {

        }
    }
}
