using System;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.IO;

namespace Tester
{
    public partial class Form5 : Form
    {
        XmlTextWriter testWriter;
        public Form5()
        {
            InitializeComponent();
            DirectoryInfo TestsDir = new DirectoryInfo("Тесты");
            if (!TestsDir.Exists) TestsDir.Create();
            comboBox1.Items.AddRange(TestsDir.GetDirectories());
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && textBox2.Text != "" && textBox1.Text != "")
            {
                try
                {
                    testWriter = new XmlTextWriter("Тесты\\" + comboBox1.Text + "\\" + textBox1.Text + ".xml", Encoding.UTF8);
                }
                catch (DirectoryNotFoundException)
                {
                    Directory.CreateDirectory("Тесты\\" + comboBox1.Text);
                    testWriter = new XmlTextWriter("Тесты\\" + comboBox1.Text + "\\" + textBox1.Text + ".xml", Encoding.UTF8);
                }
                testWriter.Formatting = Formatting.Indented;
                testWriter.WriteStartDocument();
                testWriter.WriteStartElement("test");
                testWriter.WriteStartElement("Theme");
                testWriter.WriteString(textBox2.Text);
                testWriter.WriteEndElement();
                testWriter.WriteStartElement("quest");
                testWriter.WriteStartAttribute("numbers");
                testWriter.WriteString(numericUpDown1.Value.ToString());
                testWriter.WriteEndAttribute();
                for (int i = 1; i <= numericUpDown1.Value; i++)
                {
                    Form6 F6 = new Form6(i, testWriter);
                    F6.ShowDialog();
                }
                testWriter.WriteEndElement();
                testWriter.WriteEndElement();
                testWriter.WriteEndDocument();
                testWriter.Close();
                MessageBox.Show("Все вопросы успешно созданы!", "Выход");
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Заполните все поля!", "Ошибка!");
            }
        }
        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
