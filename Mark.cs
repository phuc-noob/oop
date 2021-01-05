using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class Mark
    {
        public float mark { get; set; }
        public DateTime date { get; set; }
        public int idQuestion { get; }
        public Mark(string str)
        {
            string[] node = str.Split("-", 3);
            mark = float.Parse(node[0]);
            date = Convert.ToDateTime(node[1]);
            idQuestion = int.Parse(node[2]);
        }
        public Mark(float mark, int idQues)
        {
            this.mark = mark;
            this.idQuestion = idQues;
            date = Convert.ToDateTime(String.Format("{0:dd/MM/yyyy}", DateTime.Now));
        }
        public Mark(int i)
        {
            this.idQuestion = i;
        }
        public Mark()
        {
            this.mark = 0;
        }
        public override string ToString()
        {
            return String.Format("{0}-{1}-{2}", mark, date, idQuestion);
        }
    }
}
