using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class imcomplete : mulQuestion
    {
        public imcomplete() { }
        public imcomplete(int id, int level, DanhMuc danhMuc, float mark, string[] Pharagraph, List<MulChoice> Questions)
        {
            this.id = id;
            this.level = level;
            this.danhMuc = danhMuc;
            this.mark = mark;
            this.paragraph = Pharagraph;
            this.questions = Questions;
        }
        public void show()
        {
            Console.WriteLine(this.id);
            Console.WriteLine(this.level);
            Console.WriteLine(this.mark);
            Console.WriteLine(this.danhMuc);
            foreach(string i in this.paragraph)
            {
                Console.WriteLine(i);
            }
            foreach(MulChoice k in this.questions)
            {
                k.show();
            }
        }
    }
}
