using System;
using System.Windows.Forms;
using System.Xml;

namespace Tester
{
    public partial class Form3 : Form
    {
        XmlReader xmlReader;
        new string Name;
        string Theme;
        int nq;
        int RightAnswers;
        int position = 0;
        string quest;
        string[] answer = new string[4];
        string right;
        bool righting;
        public Form3(string TestPath, string name, string theme)
        {
            InitializeComponent();
            Name = name;
            Theme = theme;
            MessageBox.Show("Для начала тестирования нажмите \"ОК\"", "Тестирование");
            xmlReader = new XmlTextReader(TestPath);
            xmlReader.Read();
            ReadNombers();
            LoadQwest();
            ShowQwest();
        }
        #region Чтение количества вопросов
        public void ReadNombers()
        {
            do xmlReader.Read();
            while (xmlReader.Name != "quest");
            nq = Convert.ToInt32(xmlReader.GetAttribute("numbers"));
            xmlReader.Read();
        }
        #endregion
        #region Загрузка вопроса
        public void LoadQwest()
        {
            position++;
            if (position > nq) Final();
            else
            {
                do xmlReader.Read();
                while (xmlReader.Name != "q" + position);
                if (xmlReader.Name == "q" + position)
                {
                    quest = xmlReader.GetAttribute("text");
                    right = xmlReader.GetAttribute("right");
                    xmlReader.Read();
                    do xmlReader.Read();
                    while (xmlReader.Name != "answers");
                    xmlReader.Read();
                    answer = xmlReader.Value.Split('|');
                }
            }
        }
        #endregion
        #region Вывод вопроса
        public void ShowQwest()
        {
            label1.Text = quest;
            radioButton1.Text = answer[0];
            radioButton2.Text = answer[1];
            radioButton3.Text = answer[2];
            radioButton4.Text = answer[3];
            button2.Enabled = true;
        }
        #endregion
        #region Проверка
        public void Checked()
        {
            if (righting == true)
                RightAnswers++;
        }
        #endregion
        public void Final()
        {
            MessageBox.Show("Тестирование окончено!", "Tester");
            Form4 F4 = new Form4(Name, Theme, nq, RightAnswers);
            this.Dispose();
            F4.ShowDialog();
        }
        #region Выход
        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            Checked();
            LoadQwest();
            ShowQwest();
        }
        #region Проверка правильного ответа
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            righting = false;
            if (radioButton1.Checked)
            {
                if (radioButton1.Text == right)
                    righting = true;
            }
            button2.Enabled = true;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            righting = false;
            if (radioButton2.Checked)
            {
                if (radioButton2.Text == right)
                    righting = true;
            }
            button2.Enabled = true;
        }
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            righting = false;
            if (radioButton3.Checked)
            {
                if (radioButton3.Text == right)
                    righting = true;
            }
            button2.Enabled = true;
        }
        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            righting = false;
            if (radioButton4.Checked)
            {
                if (radioButton4.Text == right)
                    righting = true;
            }
            button2.Enabled = true;
        }
        #endregion
        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
