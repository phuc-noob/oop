using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace englishTest
{
    class ControlUser
    {
        private static List<User> list;
        public const string filePath = "User.txt";
        public void InitUser()
        {
            List<User> listU = new List<User>();
            try
            {
                if (File.Exists(filePath))
                {
                    string[] u = new string[3];
                    String[] lines = File.ReadAllLines(filePath);
                    User user;
                    for (int i = 0; i < lines.Length; i = i + 3)
                    {
                        u[0] = lines[i]; u[1] = lines[i + 1]; u[2] = lines[i + 2];
                        try
                        {
                            user = new User(u);
                            listU.Add(user);
                        }
                        catch (FormatException e) { }
                        catch (IndexOutOfRangeException e) { }
                    }
                }
                else
                {
                    File.Create(filePath).Close();
                }
            }
            catch (IOException e) {; }
        }
        public static int createdID()   // = maxID +1
        {
            if (list.Count == 0) return 100;
            return list[list.Count - 1].id + 1;
        }
        public List<User> getListUser()
        {
            return ControlUser.list;
        }
        public void addUser(User newU)
        {
            list.Add(newU);
        }

        public void deleteUser(int id)
        {
            list.Remove(search(id));
        }

        public void editUser(int id, string name, bool gender, string native, DateTime dob)
        {
            User t = search(id);
            if (t != null)
            {
                t.setInfor(name, native, gender, dob);
            }
        }
        public User search(int id)
        {
            foreach (User i in ControlUser.list)
            {
                if (i.id == id) return i;
            }
            return null;
        }
        public bool containsUsername(string username)
        {
            foreach (User i in ControlUser.list)
            {
                if (i.account.username == username) return true;
            }
            return false;

        }
        public User accessUser(string user, string pass)
        {
            foreach (User i in ControlUser.list)
            {
                if (i.account.username == user && i.account.password == pass) return i;
            }
            return null;
        }
        public User search(string name, bool male, string native, DateTime dob)
        {
            foreach (User i in ControlUser.list)
            {
                if (i.name == name && i.gender == male && i.native == native && i.dOB.CompareTo(dob) == 0) return i;
            }
            return null;
        }
        public void save()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (User i in ControlUser.list)
                    {
                        sw.Write(i.ToString());
                    }
                    sw.Close();
                }
            }
            catch (IOException e)
            {
                ;
            }
        }
    }
}
