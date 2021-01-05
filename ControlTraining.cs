using System;
using System.Collections.Generic;   
using System.Text;

namespace englishTest
{
    class ControlTraining
    {
        public User user { get; }   
        private List<MulChoice> listMulChoice;
        private List<imcomplete> listImcomplete;
        private List<conversation> listConversation;
        public ControlTraining(User users,List<MulChoice> lMc,List<imcomplete> lImc,List<conversation> lCon)
        {
            this.user = users;
            this.listMulChoice = lMc;
            this.listImcomplete = lImc;
            this.listConversation = lCon;
        }
        
        public bool inArray(int id)
        {
            int[] listId = this.lId();
            for(int i = 0; i < listId.Length; i++)
            {
                if(listId[i] ==id)
                {
                    return true;
                    break;
                }
            }
            return false;
        }
        public int[] lId()
        {
            int i = 0;
            int[] Lid =new int[100] ;
            foreach(Mark k in this.user.marks)
            {
                Lid[i++] = k.idQuestion;
            }
            return Lid;
        }
        public option getOption(List<option> ops,string key)
        {
            key = key.ToUpper();
            char k = key[0];
            switch (k)
            {
                case 'A':
                    return ops[0];
                    break;
                case 'B':
                    return ops[1];
                    break;
                case 'C':
                    return ops[2];
                    break;
                case 'D':
                    return ops[3];
                    break;
                default:
                    break;
            }
            return ops[0];
        }

        public List<Mark> checkAnsMC(List<MulChoice> lMc,List<string> lAns)
        {
            MulChoice[] Mc = lMc.ToArray();
            string[] Ans = lAns.ToArray();
            List<Mark> MarkMc = new List<Mark>();
            for(int i=0; i < lMc.Count; i++)
            {
                option OpAns = getOption(lMc[i].options,lAns[i]);
                if(OpAns.Content == lMc[i].answer.Content)
                {
                    MarkMc.Add(new Mark(lMc[i].Mark, lMc[i].Id));
                }
                else { MarkMc.Add(new Mark(0, lMc[i].Id)); }
            }
            return MarkMc;
        }
        public Mark checkAnsImc(imcomplete Imc,List<string> lAns)
        {
            List<Mark> tem = checkAnsMC(Imc.Questions, lAns);
            float poin = 0;
            foreach(Mark k in tem)
            {
                poin += k.mark;
            }
            return new Mark(poin, Imc.Id);
        }
        public Mark checkAnsCon(conversation Con, List<string> lAns)
        {
            List<Mark> tem = checkAnsMC(Con.Questions, lAns);
            float poin = 0;
            foreach (Mark k in tem)
            {
                poin += k.mark;
            }
            return new Mark(poin, Con.Id);
        }

        public List<MulChoice> randomMC(int count)
        {
            int[] lId = this.lId();
            List<MulChoice> MC = new List<MulChoice>();
            MulChoice[] a = listMulChoice.ToArray();
            int i = 0;
            int j = 0;

            while (j < count && i < a.Length)
            {
                if (inArray(a[i].Id))
                {
                    i++;
                }
                else
                {
                    MC.Add(a[i]);
                    i++;
                    j++;
                }
            }
            return MC;
        }
        public imcomplete randomImc(int level)
        {
            imcomplete Imc =new imcomplete();
            int[] lId = this.lId();
            int i = 0;
            int j = 0;
            foreach(imcomplete k in this.listImcomplete)
            {
                if(k.Level ==level &&!inArray(k.Id) )
                {
                    return k;
                    break;
                }
            }
            return Imc;
        }
        public conversation randomCon(int level)
        {
            conversation Con = new conversation();
            int[] lId = this.lId();
            int i = 0;
            int j = 0;
            foreach (conversation k in this.listConversation)
            {
                if (k.Level == level && !inArray(k.Id))
                {
                    return k;
                    break;
                }
            }
            return Con;
        }
        public void show()
        {
            List<MulChoice> mc = this.randomMC(7);
            imcomplete Imc = this.randomImc(3);
            conversation Con = this.randomCon(3);
            foreach(MulChoice k in mc)
            {
                k.show();
            }
            Con.show();
            Imc.show();
        }
    }
}
