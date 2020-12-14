using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace englishTest
{
    class multiQuestion
    {
        protected string[] paragraph;
        protected List<multiChoise> questions =new List<multiChoise>();
        protected int level;
        public multiQuestion(){}
        public multiQuestion(string[] Pharagraph,List<multiChoise> Questions,int level)
        {
            this.paragraph = Pharagraph;
            this.questions = Questions;
            this.level = level;
        }
        public List<multiChoise> Questions
        {
            get { return this.questions; }
        }
        public bool State
        {
            get { return questions[0].State; }
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
           foreach(multiChoise i in questions)
            {
                Console.Write("\t");
                i.show();
            }
           Console.WriteLine("-----------------------------------------------------------------------");
        }
    }
}
