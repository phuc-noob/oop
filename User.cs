using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class User
    {
        public int id { get; }
        public string name { get; set; }
        public string native { get; set; } //que quan
        public bool gender { get; set; }  //male=True
        public DateTime dOB { get; set; }
        public DateTime startDay { get; set; }
        public Account account { get; }
        public List<Mark> marks { get; set; }
        public User(int id, string name, string native, bool gender, DateTime dOB, DateTime startDay, Account account, List<Mark> marks)
        {
            this.id = id;
            this.name = name;
            this.native = native;
            this.gender = gender;
            this.dOB = dOB;
            this.startDay = startDay;
            this.account = account;
            this.marks = marks;
        }
        public User(string[] convert)
        {
            string[] node1 = convert[0].Split(",", 6);
            this.id = int.Parse(node1[0]);
            this.name = node1[1];
            this.native = node1[2];
            this.gender = bool.Parse(node1[3]);
            this.dOB = Convert.ToDateTime(node1[3]);
            this.startDay = Convert.ToDateTime(node1[4]);
            this.account = new Account(convert[1]);
            this.marks = new List<Mark>();
            string[] node3 = convert[2].Split(",");
            foreach (string i in node3)
            {
                marks.Add(new Mark(i));
            }
        }
        public User(Account account)
        {
            this.id = ControlUser.createdID();
            this.account = account;
            this.marks = new List<Mark>();
            this.startDay = DateTime.Now;
        }
        public User()
        {
            for(int i =0;i < 7; i++)
            {
                this.marks = new List<Mark>();
                this.marks.Add(new Mark(i));
            }
        }
        public User(List<Mark> t)
        {
            this.marks = t;
        }
        public void setInfor(string name, string native, bool gender, DateTime dOB)
        {
            this.name = name;
            this.native = native;
            this.gender = gender;
            this.dOB = dOB;
        }
        public override string ToString()
        {
            string s = string.Format("{0},{1},{2},{3},{4},{5}\n", this.id, this.name, this.native, this.gender, this.dOB.ToString("dd/MM/yyyy"), this.startDay);
            s = s + this.account.ToString() + "\n";
            foreach (Mark i in marks)
            {
                s = s + i.ToString() + ",";
            }
            s.Remove(s.Length - 1);
            s = s + "\n";
            return s;
        }
    }
}
