using System;
using System.Collections.Generic;
using System.Text;

namespace englishTest
{
    interface IManageUser
    {
        List<User> getListUser();
        User search(int id);
        User search(string name, bool gender, string native, string dob);
        void addUser(User newU);
        void editUser(int id, string name, bool gender, string native, string dob, string pass);
        void deleteUser(int id);
        void save();
        bool containsUsername(string username);
        User accessUser(Account account);
    }
}
