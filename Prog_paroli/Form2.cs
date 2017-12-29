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
    public partial class Form2 : Form
    {
        string s;
        int i;
        public Form2(string s,int i)
        {
            InitializeComponent();
            this.s = s;
            this.i = i;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string fileName = "parol.txt";
            FileStream aFile = new FileStream(fileName, FileMode.Append); //открытие файла на добавление в конец файла
            StreamWriter str = new StreamWriter(aFile);
            str.WriteLine(s); //добавление строки в конец файла
            str.Close();        //закрытие файла
            this.Hide();
            Form3 form = new Form3(s);  //создание новой формы
            form.ShowDialog();          //отображение нофой формы
            this.Close();               //закрытие текущей формы
        }

        private void button2_Click(object sender, EventArgs e)
        {
            i--;            //уменьшение переменной на "1", которая определеят количество попыток ввода
            if (i == 0)
            {
                MessageBox.Show("Количество попыток равно 0!"); //вывод сообщения
                this.Close();                                   //закрытие текущей формы (останов приложения)
            }
            else
            {
                this.Hide();
                Form1 form = new Form1(i);      //создание формы
                form.ShowDialog();              //отображение формы
                this.Close();                   //закрытие текущей формы
            }
        }

    }
}
