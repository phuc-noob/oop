using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace englishTest
{
    class ControlQuestion
    {
        private List<MulChoice> listMulChoice = new List<MulChoice>();
        private List<imcomplete> listImcomplete = new List<imcomplete>();
        private List<conversation> listConversation = new List<conversation>();
        private string fileMulChoice = "C:\\Users\\PC\\source\\repos\\englishTest\\englishTest\\Data\\multiChoice.txt";
        private string fileImcomplete = "C:\\Users\\PC\\source\\repos\\englishTest\\englishTest\\Data\\imcomplete.txt";
        private string fileConversation = "C:\\Users\\PC\\source\\repos\\englishTest\\englishTest\\Data\\conversation.txt";
        public ControlQuestion()
        {
            this.listMulChoice = InitMC();
            this.listImcomplete = InitImc();
            this.listConversation = InitCon();
        }

        // Search question
        public List<MulChoice> searchMC(int level)
        {
            List<MulChoice> Mc = new List<MulChoice>();
            foreach(MulChoice k in this.listMulChoice)
            {
                if(k.Level ==level)
                {
                    Mc.Add(k);
                }
            }
            return Mc;
        }
        public List<imcomplete> searchImc(int level)
        {
            List<imcomplete> Imc = new List<imcomplete>();
            foreach(imcomplete k in this.listImcomplete)
            {
                if(k.Level == level)
                {
                    Imc.Add(k);
                }
            }
            return Imc;
        }
        public List<conversation> searchCon(int level)
        {
            List<conversation> Con = new List<conversation>();
            foreach(conversation k in listConversation)
            {
                if(k.Level == level)
                {
                    Con.Add(k);
                }
            }
            return Con;
        }

        public List<MulChoice> searchMC(DanhMuc danhMuc)
        {
            List<MulChoice> MC = new List<MulChoice>();
            foreach(MulChoice k in this.listMulChoice)
            {
                if(k.DanhMuc ==danhMuc) { MC.Add(k); }
            }
            return MC;
        }
        public List<imcomplete> searchImc(DanhMuc danhMuc)
        {
            List<imcomplete> Imc = new List<imcomplete>();
            foreach(imcomplete k in this.listImcomplete)
            {
                if(k.DanhMuc == danhMuc) { Imc.Add(k); }
            }
            return Imc;
        }
        public List<conversation> searchCon(DanhMuc danhMuc)
        {
            List<conversation> Con = new List<conversation>();
            foreach(conversation k in this.listConversation)
            {
                if(k.DanhMuc == danhMuc) { Con.Add(k); }
            }
            return Con;
        }

        public List<MulChoice> searchMC(string content)
        {
            List<MulChoice> MC = new List<MulChoice>();
            foreach(MulChoice k in this.listMulChoice)
            {
                if (k.content.Contains(content))
                {
                    MC.Add(k);
                }
            }
            return MC;
        }
        public List<imcomplete> searchImc(string content)
        {
            List<imcomplete> Imc = new List<imcomplete>();
            foreach(imcomplete k in this.listImcomplete)
            {
                foreach(string line in k.Pharagraph)
                {
                    if (line.Contains(content))
                    {
                        Imc.Add(k);
                        break;
                    }
                }
            }
            return Imc;
        }
        public List<conversation> searchCon(string content)
        {
            List<conversation> Con = new List<conversation>();
            foreach(conversation k in this.listConversation)
            {
                foreach(string line in k.Pharagraph)
                {
                    if (line.Contains(content))
                    {
                        Con.Add(k);
                        break;
                    }
                }
            }
            return Con;
        }
        // end of search question
        public List<MulChoice> InitMC()
        {
            List<MulChoice> MC = new List<MulChoice>();
            int i = 0;
            string[] lines = File.ReadAllLines(this.fileMulChoice);
            while (i < lines.Length)
            {
                string[] sMc = new string[4];
                sMc[0] = lines[i++];
                sMc[1] = lines[i++];
                sMc[2] = lines[i++];
                sMc[3] = lines[i++];
                MulChoice Mc = ConvertToMc(sMc);
                MC.Add(Mc);
                i++;
            }
            return MC;
        }
        public List<imcomplete> InitImc()
        {
            List<imcomplete> Imc = new List<imcomplete>();

            int i = 0;
            string[] lines = File.ReadAllLines(this.fileImcomplete);

            while (i < lines.Length)
            {
                string[] getData = lines[i++].Split(",");
                int id = int.Parse(getData[0]);
                int level = int.Parse(getData[1]);
                float mark = float.Parse(getData[2]);
                DanhMuc dMuc = this.getDanhMuc(getData[3]);
                string[] paragraph = convertToParagraph(lines[i++]);

                List<MulChoice> Mc = new List<MulChoice>();
                while (lines[i] != "")
                {
                    string[] sImc = new string[4];
                    sImc[0] = lines[i++];
                    sImc[1] = lines[i++];
                    sImc[2] = lines[i++];
                    sImc[3] = lines[i++];

                    Mc.Add(ConvertToMc(sImc));
                }
                Imc.Add(new imcomplete(id, level, dMuc, mark, paragraph, Mc));
                if (lines[i] == "")
                {
                    i++;
                }

            }
            return Imc;
        }
        public List<conversation> InitCon()
        {
            List<conversation> Con = new List<conversation>();

            int i = 0;
            string[] lines = File.ReadAllLines(this.fileConversation);

            while (i < lines.Length)
            {
                string[] getData = lines[i++].Split(",");
                int id = int.Parse(getData[0]);
                int level = int.Parse(getData[1]);
                float mark = float.Parse(getData[2]);
                DanhMuc dMuc = this.getDanhMuc(getData[3]);
                string[] paragraph = convertToParagraph(lines[i++]);

                List<MulChoice> Mc = new List<MulChoice>();
                while (lines[i] != "")
                {
                    string[] sImc = new string[4];
                    sImc[0] = lines[i++];
                    sImc[1] = lines[i++];
                    sImc[2] = lines[i++];
                    sImc[3] = lines[i++];

                    Mc.Add(ConvertToMc(sImc));
                }
                Con.Add(new conversation(id, level, dMuc, mark, paragraph, Mc));
                if (lines[i] == "")
                {
                    i++;
                }

            }
            return Con;
        }

        public List<MulChoice> getListMC
        {
            get { return this.listMulChoice; }
        }
        public List<imcomplete> getListImc
        {
            get { return this.listImcomplete; }
        }
        public List<conversation> getCon
        {
            get { return this.listConversation; }
        }

        public DanhMuc getDanhMuc(string DMuc)
        {
            DanhMuc danhMuc;
            switch (DMuc)
            {
                case "noun":
                    danhMuc = DanhMuc.DanhTu;
                    break;
                case "verb":
                    danhMuc = DanhMuc.DongTu;
                    break;
                case "adj":
                    danhMuc = DanhMuc.TinhTu;
                    break;
                case "adv":
                    danhMuc = DanhMuc.GioiTu;
                    break;
                default:
                    danhMuc = DanhMuc.DanhMucKhac;
                    break;
            }
            return danhMuc;
        }
        public MulChoice ConvertToMc(string[] lines)
        {
            List<option> options = new List<option>();
            string[] getData = lines[0].Split(",");

            int id = (getData[0] == "") ? -1 : int.Parse(getData[0]);
            int level = (getData[1] == "") ? -1 : int.Parse(getData[1]);
            float mark = (getData[2] == "") ? -1 : float.Parse(getData[2]);
            DanhMuc danhMuc;

            danhMuc = (getData[3] == "") ? DanhMuc.DanhMucKhac : this.getDanhMuc(getData[3]);

            string content = lines[1];
            string[] option = lines[2].Split('/');
            foreach (string k in option)
            {
                string[] o = k.Split('&');
                options.Add(new option(o[0], o[1]));
            }
            option answer;

            string[] answerOption = lines[3].Split('&');
            answer = new option(answerOption[0], answerOption[1]);
            return new MulChoice(id, level, danhMuc, mark, content, options, answer);
        }
        public string[] convertToParagraph(string text)
        {
            string[] para;
            string tem = "\\";
            tem += "n";
            para = text.Split(tem);
            return para;
        }
        public void Show()
        {
            List<MulChoice> a = this.searchMC("search");
            List<imcomplete> b = this.searchImc("Dragon");
            List<conversation> c = this.searchCon("The");
            foreach(MulChoice i in a)
            {
                i.show();
            }
            foreach(imcomplete j in b)
            {
                j.show();
            }
            foreach(conversation k in c)
            {
                k.show();
            }
        }
    }
}
