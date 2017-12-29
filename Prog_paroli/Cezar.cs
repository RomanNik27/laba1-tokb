using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prog_paroli
{
    class Cezar : System.Collections.Generic.List<Clent>
    {
        public Cezar()
        { //в конструкторе формирую коллекцию лент
            this.Add(new Clent("abcdefghijklmnopqrstuvwxyz"));
            this.Add(new Clent("ABCDEFGHIJKLMNOPQRSTUVWXYZ"));
            this.Add(new Clent("абвгдеёжзийклмнопрстуфхцчшщъыьэюя"));
            this.Add(new Clent("АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ"));
            this.Add(new Clent("0123456789"));
            this.Add(new Clent("!\"#$%^&*()+=-_'?.,|/`~№:;@[]{}"));
        }

        public string Codeс(string m, int key) //кодирование со сдвигом "key"
        {
            string res = "", tmp = "";
            for (int i = 0; i < m.Length; i++)
            {
                foreach (Clent v in this)           //просмотр всех лент (всех вариантов символов)
                {
                    tmp = v.Repl(m.Substring(i, 1), key);   //замена символа на символ со сдвигом
                    if (tmp != "") //нужная лента найдена, замена символу определена
                    {
                        res += tmp;
                        break; // прерывается foreach (перебор лент)
                    }
                }
                if (tmp == "") res += m.Substring(i, 1); //незнакомый символ оставляю без изменений
            }
            return res;
        }
    }
}
