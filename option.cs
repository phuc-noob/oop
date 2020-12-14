using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class option
    {
        protected string content;
        protected string explain;
        public string Content
        {
            get { return this.content; }
        }
        public string Expalin
        {
            get { return this.explain; }
        }
        public option(string content, string explain)
        {
            this.content = content;
            this.explain = explain;
        }
        public void show()
        {
            Console.WriteLine(this.content + "\t\t");
        }
    }
}
