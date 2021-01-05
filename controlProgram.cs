using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class controlProgram
    {
        private ControlQuestion conQues;
        private viewTraining viewTraining;
        private ControlTraining conTraining;
        private User user;

        public controlProgram()
        {
            this.viewTraining = new viewTraining();
            this.conQues = new ControlQuestion();
            this.user = new User();
            this.conTraining = new ControlTraining(this.user ,this.conQues.getListMC,this.conQues.getListImc,this.conQues.getCon);
        }
        public void TrainingMC()
        {
            List<MulChoice> tMc = new List<MulChoice>();
            List<Mark> tem = new List<Mark>();
            List<string> Ans = new List<string>();

            int num;
            Console.WriteLine("\t NHAP VAO SO LUONG CAU HOI:");
            num = int.Parse(Console.ReadLine());

            tMc = conTraining.randomMC(num);
            foreach(MulChoice k in tMc)
            {
                k.show();
                string t;
                t=Console.ReadLine();
                Ans.Add(t);
                
                Console.Clear();
            }

            tem = conTraining.checkAnsMC(tMc, Ans);
            foreach(Mark t in tem)
            {
                Console.WriteLine(t.idQuestion);
            }
            foreach(Mark k in tem)
            {
                this.user.marks.Add(k);
            }
            int i = 0;
            foreach(Mark k in tem)
            {
                if(k.mark == 0)
                {
                    this.WShow(Ans[i], tMc[i].answer,tMc[i]);
                }
                else
                {
                    this.rShow(Ans[i], tMc[i]);
                }
                i++;
            }
        }
        public void WShow(string uChoice,option Ans, MulChoice lMc)
        {
            uChoice = uChoice.ToUpper();
            char userC = uChoice[0];
            char aKey = getKey(Ans, lMc.options);
            
            Console.WriteLine(lMc.content);
            char k = 'A';
            int j = 0;
            for (char i = 'A'; i <='D' ; i++)
            {
                if (i == aKey)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(k + " ");
                    k++;
                    Console.WriteLine(lMc.options[j].Content);
                    Console.ResetColor();
                    j++;
                }
                else if (i == userC)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(k + " ");
                    k++;
                    Console.WriteLine(lMc.options[j].Content);
                    Console.ResetColor();
                    j++;
                }
                else
                {
                    Console.Write(k + " ");
                    k++;
                    Console.WriteLine(lMc.options[j].Content);
                    j++;
                }
            }
            Console.WriteLine();
        }
        public char getKey(option t,List<option> real)
        {
            char k = 'A';
            foreach(option i in real)
            {
                if(t.Content ==i.Content)
                {
                    return k;
                    break;
                }
                k++;
            }
            return k;
        }
        public void rShow(string ans,MulChoice lMc)
        {
            int num;
            switch (ans.ToUpper())
            {
                case "A":
                    num = 1;
                    break;
                case "B":
                    num = 2;
                    break;
                case "C":
                    num = 3;
                    break;
                case "D":
                    num = 4;
                    break;
                default:
                    num = 0;
                    break;
            }
            Console.WriteLine(lMc.content);
            char k = 'A';
            for (int i=1; i <= lMc.options.Count; i++)
            {
                if (i == num)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write(k +" ");
                    k++;
                    Console.WriteLine(lMc.options[i-1].Content);
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(k + " ");
                    k++;
                    Console.WriteLine(lMc.options[i-1].Content);
                }
            }
            Console.WriteLine();
        }
    }
}
