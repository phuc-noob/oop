using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class MulChoice:Question
    {
        public string content { get; }
        public List<option> options { get; }
        public option answer { get; }
        
        // Constructor function.
        public MulChoice()
        {
            
        }
        public MulChoice(float mark)
        {
            this.mark = mark;
        }

        public MulChoice(int id, int level, DanhMuc danhMuc,float mark, string content, List<option> options, option answer)
        {
            this.mark = mark;
            this.danhMuc = danhMuc;
            this.id = id;
            this.level = level;
            this.content = content;
            this.options = options;
            this.answer = answer;
        } 
        
        // end of constructor function
        // Getter and Setter

        //-------   end of Getter-Setter -------
        public void show()
        {
            char key = 'A';
            Console.WriteLine("{0}.[{1}][{2}][{3}] >>{4}",this.id, this.level,this.danhMuc,this.mark,this.content);
            foreach(option i in options)
            {
                Console.Write("\t" +key+".");
                i.show();
                key++;
            }
            Console.WriteLine();
        }
    }
}
