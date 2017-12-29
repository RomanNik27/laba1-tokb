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
    public partial class Form1 : Form
    {
        public string text_sh;  //текст, который проверяется (пароль)
        int i;                  //переменная для хранения количества попыток ввода пароля
        public Form1(int i)
        {
            InitializeComponent();
            this.i = i;
            if (i>0 && i < 3)
                MessageBox.Show("Введен неверный пароль! У Вас осталось " + i.ToString() + " попыток!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
                Cezar Me = new Cezar();  //создание элемента класса
                text_sh = Me.Codeс(Convert.ToString(textBox1.Text), 3);  //шифрование по шифру Цезаря со сдвигом 3
                string fileName = "parol.txt";
                FileStream aFile = new FileStream(fileName, FileMode.OpenOrCreate); //открытие или создание файла
                StreamReader str = new StreamReader(aFile);
                string text_file = str.ReadToEnd();    //считывание всего файла и запись в строку
                str.Close();                           //закрытие файла
                string[] spl = text_file.Split('\n');   //разделение всех строк, которые были в файле по одной строке 
                bool f = false;
                for (int i = 0; i < spl.Length; i++)
                    if (spl[i].CompareTo(text_sh + '\r') == 0) //проверка пароля (если найден в файле)
                        f = true;
                if (!f)                                     //если пароль не найден
                {
                    this.Hide();
                    Form2 form = new Form2(text_sh,i);   //создание нофой формы
                    form.ShowDialog();                   //отображение новой формы
                    this.Close();                       //закрытие текущей формы
                }
                else
                {
                    this.Hide();
                    Form3 form = new Form3(text_sh);    //создание нофой формы
                    form.ShowDialog();                  //отображение новой формы
                    this.Close();                       //закрытие текущей формы
                }
            }
        }
    }
