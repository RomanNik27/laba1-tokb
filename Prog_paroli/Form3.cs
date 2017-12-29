using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Prog_paroli
{
    public partial class Form3 : Form
    {
        public string sh,text_sh;
        int i = 3;
        public Form3(string sh)
        {
            InitializeComponent();
            this.sh = sh;

        }

        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Hide();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cezar Me = new Cezar();             //создание элемента класса
            text_sh = Me.Codeс(Convert.ToString(textBox1.Text), 3);     //шифрование текста
            if (sh.CompareTo(text_sh) ==0)      //если ввод пароля верный
            {
                /*Отображение текстового поля и кнопки для изменения пароля*/
                label2.Visible = true;
                textBox2.Visible = true;
                button2.Visible = true;
                textBox1.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                i--;            //уменьшаем количество попыток ввода на "1"
                MessageBox.Show("Введен неверный пароль! У Вас осталось " + i.ToString() + " попыток!");    //вывод сообщения
                if (i == 0)
                    this.Close();       //закрытие текущей формы
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cezar Me = new Cezar();     //создание элемента класса
            text_sh = Me.Codeс(Convert.ToString(textBox2.Text), 3); //шифрование текста
            string fileName = "parol.txt";
            FileStream aFile = new FileStream(fileName, FileMode.Open); //открытие файла
            StreamReader str = new StreamReader(aFile);
            string text_file = str.ReadToEnd();             //считывание данных из файла
            str.Close();            //закрытие файла
            string new_text = text_file.Replace(sh, text_sh);       //замена пароля в файле
            StreamWriter str_w = new StreamWriter(fileName);    //открытие файла для записи
            str_w.Write(new_text);          //запись в файл
            str_w.Close();      //закрытие файла

            this.Hide();
            Form1 form = new Form1(3);          //создание формы
            form.ShowDialog();                  //открытие формы    
            this.Close();                       //закрытие текущей формы
        }
    }
}
