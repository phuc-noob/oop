using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace englishTest
{
    class mulQuestion:Question
    {
        protected string[] paragraph;
        protected List<MulChoice> questions =new List<MulChoice>();
        public mulQuestion()
        {
            this.danhMuc = DanhMuc.DanhMucKhac;
        }
        public mulQuestion(int id,int level, DanhMuc danhMuc,float mark,string[] Pharagraph,List<MulChoice> Questions)
        {
            this.id = id;
            this.level = level;
            this.danhMuc = danhMuc;
            this.mark = mark;
            this.paragraph = Pharagraph;
            this.questions = Questions;
        }
        public List<MulChoice> Questions
        {
            get { return this.questions; }
        }
        
        public int Level
        {
            get { return this.level; }
            set { this.level = value; }
        }
        public string[] Pharagraph
        {
            get { return this.paragraph; }
            set { this.paragraph = value; }
        }
        public void Show()
        {
           foreach(string j in paragraph)
           {
               Console.WriteLine("\t" +j);
           }
            Console.WriteLine();
           foreach(MulChoice i in questions)
            {
                Console.Write("\t");
                i.show();
            }
           Console.WriteLine("-----------------------------------------------------------------------");
        }
    }
}
