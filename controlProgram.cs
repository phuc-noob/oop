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
            }

            tem = conTraining.checkAnsMC(tMc, Ans);
            this.user = new User(tem);
            
        }
    }
}
