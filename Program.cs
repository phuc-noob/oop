using System;
using System.Collections.Generic;
using System.IO;

namespace englishTest
{
    class Program
    {
        
        static void Main(string[] args)
        {
            String key = "";
            menu(ref key);
            while (key.ToUpper() != "E")
            {
                if (key.ToUpper() == "A")
                {
                    controlProgram a = new controlProgram();
                    a.TrainingMC();
                    
                     //User users = new User();
                     ///ControlQuestion a = new ControlQuestion();
                    //Console.WriteLine(a.getListMC.Count);
                     //a.Show();
                    //ControlTraining b = new ControlTraining(users ,a.getListMC,a.getListImc,a.getCon);
                    //b.show();
                    menu(ref key);
                }
            }
            static void menu(ref string key)
            {
                Console.WriteLine("Enter type of test you want to exercise:");
                Console.WriteLine("\tA:Multi Question.");
                Console.WriteLine("\tB:Imcomplete Question.");
                Console.WriteLine("\tC:Conversation Question.");
                Console.WriteLine("\tE:Enter E to Exit.");
                Console.Write("\t");
                key = Console.ReadLine();
            }
        }
    }
}
