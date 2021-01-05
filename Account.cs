using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    class Account
    {
        public string username { get; }
        public string password { get; set; }
        public Account(string convert)
        {
            string[] node = convert.Split(",", 2);
            username = node[0];
            password = node[1];
        }
        public Account(string username, string pass)
        {
            this.username = username;
            this.password = pass;
        }
        public override string ToString()
        {
            return this.username + "," + this.password;
        }
    }
}
