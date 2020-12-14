using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class multiChoise
    {
        private string content;
        private List<option> options;
        private option answer;
        private bool state;
        private string userChoice;
        public List<option> Options
        {
            get { return this.options; }
            set { this.options = value; }
        }
        public string Content
        {
            get { return this.content; }
            set { this.content = value; }
        }
        // Constructor function.
        public multiChoise()
        {
            this.content = "";
            this.state = false;
        }
        public multiChoise(string conten, List<option> options, option answer, bool state)
        {
            this.content = conten;
            this.options = options;
            this.answer = answer;
            this.state = state;
        } 
        // end of constructor function
        // Getter and Setter
        public option Answer
        {
            get { return this.answer; }
        }
        public string UserChoice
        {
            get { return this.userChoice; }
            set { this.userChoice = value; }
        }
        public bool State
        {
            get{return this.state;}
            set { this.state = value; }
        }
        //-------   end of Getter-Setter -------
        public void show()
        {
            char key = 'A';
            Console.WriteLine(content);
            foreach(option i in options)
            {
                Console.Write("\t" +key+".");
                i.show();
                key++;
            }
            Console.WriteLine();
        }
        public bool Check(string answer)
        {
            if (getOption(answer).Content == this.answer.Content)
            {
                return true;
            }
            else
                return false;
        }
        public option getOption(string answer)
        {
            switch (answer.ToUpper())
            {
                case "A":
                    return this.options[0];
                    break;
                case "B":
                    return this.options[1];
                    break;
                case "C":
                    return this.options[2];
                    break;
                case "D":
                    return this.options[3];
                    break;
                default:
                    Console.WriteLine("Default case");
                    break;
            }
            return this.options[0];
        }
        public override string ToString()
        {
            string temp;
            if(this.state ==false)
            {
                temp = "0" + "~" + this.content;
            }
            else
            {
                temp = "1" + "~" + this.content;
            }
            foreach(option i in options)
            {
                temp += (i.Content + "&" + i.Expalin + "/");
            }temp = temp.Remove(temp.Length - 1);
            temp += (">" + this.answer.Content + "&" + this.answer.Expalin);
            return temp;
        }
    }
}
