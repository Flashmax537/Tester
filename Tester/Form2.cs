using System;
using System.Windows.Forms;
using System.IO;
using System.Xml;

namespace Tester
{
    public partial class Form2 : Form
    {
        XmlReader xmlThemeRead;
        DirectoryInfo testsDirectory = new DirectoryInfo("Тесты");
        public Form2()
        {
            InitializeComponent();
            if (testsDirectory.Exists == false)
                CreateTestDir();
            comboBox1.Items.AddRange(testsDirectory.GetDirectories());
        }
        #region Обновление ListBox
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = "Тема: ";
            DirectoryInfo testsDir = new DirectoryInfo("Тесты\\" + comboBox1.Text);
            listBox1.Items.Clear();
            foreach (FileInfo file in testsDir.GetFiles())
            {
                listBox1.Items.Add(Path.GetFileNameWithoutExtension(file.FullName));
            }
            button2.Enabled = false;
        }
        #endregion
        #region Выход
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        #region Создание папок
        public void CreateTestDir()
        {
            testsDirectory.Create();
        }
        #endregion
        #region Выбор теста
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                xmlThemeRead = new XmlTextReader("Тесты\\" + comboBox1.Text + "\\" + listBox1.Text + ".xml");
                do xmlThemeRead.Read();
                while (xmlThemeRead.Name != "Theme");
                xmlThemeRead.Read();
                label2.Text = "Тема: " + xmlThemeRead.Value;
                xmlThemeRead.Read();
                button2.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Файл не найден!", "Ошибка");
            }
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            string xmlPath = "Тесты\\" + comboBox1.Text + "\\" + listBox1.Text + ".xml";
            Form3 F3 = new Form3(xmlPath, textBox1.Text, label2.Text);
            F3.Show();
            this.Visible = false;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
