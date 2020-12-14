using System;
using System.Collections.Generic;
using System.IO;

namespace englishTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            String key ="";
            menu(ref key);
            while (key.ToUpper() != "E")
            {
                if (key.ToUpper() == "A")
                {
                    string pathMultiChoice = "C:\\Users\\PC\\source\\repos\\englishTest\\englishTest\\Data\\multiQuestion.txt";
                    List<multiChoise> questions = new List<multiChoise>();
                    readFile(pathMultiChoice, ref questions);

                    exerciseMultiChoice(ref questions);

                    foreach (multiChoise i in questions)
                    {
                        Console.Write(i.State + "--------");
                        i.show();
                        if (i.State == true) { Console.WriteLine("\t your answer is {0}", i.UserChoice); }
                        Console.WriteLine();
                    }
                    writeTofile(pathMultiChoice, questions);
                    menu(ref key);
                }
                else if (key.ToUpper() == "B")
                {
                    List<imcomplete> imcompletes = new List<imcomplete>();
                    string path = "C:\\Users\\PC\\source\\repos\\englishTest\\englishTest\\Data\\incomplete.txt";
                    readImcompleteFile(path, imcompletes);
                    exerciseImcomplete(ref imcompletes);
                    menu(ref key);
                }
                else if (key.ToUpper() == "C")
                {
                    List<conversation> conversations = new List<conversation>();
                    string pathConversation = "C:\\Users\\PC\\source\\repos\\englishTest\\englishTest\\Data\\conversation.txt";
                    readConversationFile(pathConversation, conversations);
                    exercuseConversation(conversations);
                    menu(ref key);
                }
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
        static void exercuseConversation(List<conversation> conversations)
        {
            Console.Write("Enter your level you want to exercise:");
            int level = int.Parse(Console.ReadLine());
            foreach(conversation i in conversations)
            {
                if (level == i.Level && i.State == false)
                {
                    foreach (multiChoise j in i.Questions)
                    {
                        foreach (string line in i.Pharagraph)
                        {
                            Console.WriteLine(line);
                        }
                        j.show();
                        string opAnswer = Console.ReadLine();
                        j.UserChoice = opAnswer;
                        Console.Clear();
                    }

                    foreach (string grap in i.Pharagraph)
                    {
                        Console.WriteLine(grap);
                    }
                    foreach (multiChoise k in i.Questions)
                    {
                        k.show();
                        Console.Write("Your answer is {0}: ", k.UserChoice.ToUpper()); k.getOption(k.UserChoice).show();
                        if (k.Check(k.UserChoice))
                        {
                            Console.WriteLine("\tGood chop.");
                        }
                        else
                        {
                            Console.WriteLine("\tfuck you.");
                        }
                        Console.WriteLine();
                    }
                }
                break;
            }
        }
        static void readConversationFile(string pathConversation,List<conversation> conversations)
        {
            string[] lines = File.ReadAllLines(@pathConversation);
            int level = 0;
            string[] tempPharagraph = { };
            List<multiChoise> questions = new List<multiChoise>();
            foreach (string i in lines)
            {
                if (i[0] == '@')
                {
                    if (i[1] == '1')
                    {
                        level = 1;
                    }
                    else if (i[1] == '2')
                    {
                        level = 2;
                    }
                    else if (i[1] == '3')
                    {
                        level = 3;
                    }
                }
                if (i[0] != '#')
                {
                    if (i[2] == '#')
                    {
                        string j = i;
                        j = j.Remove(0, 3);
                        string splitText = "\\";
                        splitText = splitText + 'n';
                        string[] temp = j.Split(splitText);
                        tempPharagraph = temp;
                        //Console.WriteLine("--------------------------------------------------------------");
                    }
                    else if (i[0] == '?')
                    {
                        string j = i;
                        j = j.Remove(0, 1);
                        // get state of question
                        string[] getState = j.Split("~");
                        bool tempState;
                        if (getState[0][0] == '0')
                        {
                            tempState = false;
                        }
                        else
                        {
                            tempState = true;
                        }
                        // end of get state

                        List<option> tempOptions = new List<option>();
                        string[] getContent = getState[1].Split('?');

                        string tempContent = getContent[0] + "?";
                        //Console.WriteLine(tempContent);
                        //Console.WriteLine(getContent[1]);
                        string[] getOption = getContent[1].Split(">");

                        string[] getAnswer = getOption[1].Split("&");
                        //Console.WriteLine(getAnswer[0]);
                        //Console.WriteLine(getAnswer[1]);

                        option tempAnswer = new option(getAnswer[0], getAnswer[1]);
                        string[] OptionGet = getOption[0].Split('/');
                        //Console.WriteLine(getOption[0]);
                        foreach (string text in OptionGet)
                        {
                            string[] t = text.Split("&");
                            tempOptions.Add(new option(t[0], t[1]));
                        }
                        questions.Add(new multiChoise(tempContent, tempOptions, tempAnswer, tempState));
                    }
                }
                else if (i[0] == '#')
                {
                    conversations.Add(new conversation(tempPharagraph, questions, level));
                    List<multiChoise> temp = new List<multiChoise>();
                    questions = temp;
                }
            }
        }
        static void exerciseImcomplete(ref List<imcomplete> imcompletes)
        {
            Console.Write("Enter your level you want to exercise:");
            int level = int.Parse(Console.ReadLine());
            foreach(imcomplete i in imcompletes)
            {
                if(level ==i.Level && i.State==false)
                {
                    foreach(multiChoise j in i.Questions)
                    {
                        foreach(string line in i.Pharagraph)
                        {
                            Console.WriteLine(line);
                        }
                        j.show();
                        string opAnswer =Console.ReadLine();
                        j.UserChoice = opAnswer;
                        Console.Clear();
                    }
                    foreach(string grap in i.Pharagraph)
                    {
                        Console.WriteLine(grap);
                    }
                    foreach(multiChoise k in i.Questions)
                    {
                        k.show();
                        Console.Write("Your answer is {0}: ", k.UserChoice.ToUpper());k.getOption(k.UserChoice).show();
                        if (k.Check(k.UserChoice))
                        {
                            Console.WriteLine("\tGood chop.");
                        }
                        else
                        {
                            Console.WriteLine("\tfuck you.");
                        }
                        Console.WriteLine();
                    }
                }
            }
        }
        static void readImcompleteFile(string path,List<imcomplete> imcompletes)
        {
            string[] lines = File.ReadAllLines(@path);
            int level =0;
            string[] tempPharagraph = { };
            List<multiChoise> questions = new List<multiChoise>();
            foreach (string i in lines)
            {
                if(i[0] =='@')
                {
                    if(i[1] =='1')
                    {
                        level = 1;
                    }else if(i[1] =='2')
                    {
                        level = 2;
                    }else if(i[1]=='3')
                    {
                        level = 3;
                    }
                }
                if (i[0] != '#')
                {
                    if (i[2] == '#')
                    {
                        string j = i;
                        j = j.Remove(0, 3);
                        string splitText = "\\";
                        splitText = splitText + 'n';
                        string[] temp = j.Split(splitText);
                        tempPharagraph = temp;
                        //Console.WriteLine("--------------------------------------------------------------");
                    }
                    else if (i[0] == '?')
                    {
                        string j = i;
                        j = j.Remove(0, 1);
                        // get state of question
                        string[] getState = j.Split("~");
                        bool tempState;
                        if (getState[0][0] == '0')
                        {
                            tempState = false;
                        }
                        else
                        {
                            tempState = true;
                        }
                        // end of get state

                        List<option> tempOptions = new List<option>();
                        string[] getContent = getState[1].Split('?');

                        string tempContent = getContent[0] + "?";
                        //Console.WriteLine(tempContent);
                        //Console.WriteLine(getContent[1]);
                        string[] getOption = getContent[1].Split(">");

                        string[] getAnswer = getOption[1].Split("&");
                        //Console.WriteLine(getAnswer[0]);
                        //Console.WriteLine(getAnswer[1]);

                        option tempAnswer = new option(getAnswer[0], getAnswer[1]);
                        string[] OptionGet = getOption[0].Split('/');
                        //Console.WriteLine(getOption[0]);
                        foreach (string text in OptionGet)
                        {
                            string[] t = text.Split("&");
                            tempOptions.Add(new option(t[0], t[1]));
                        }
                        questions.Add(new multiChoise(tempContent, tempOptions, tempAnswer, tempState));
                    }
                }
                else if (i[0] == '#')
                {
                    imcompletes.Add(new imcomplete(tempPharagraph, questions,level));
                    List<multiChoise> temp = new List<multiChoise>();
                    questions = temp;
                }
            }
        }

        static void writeTofile(string path,List<multiChoise> multiChoises)
        {
            string[] text= new string[multiChoises.Count];
            int index = 0;

            foreach(multiChoise i in multiChoises)
            {
                text[index] = i.ToString();
                index++;
            }
            File.WriteAllLines(@path, text);
        }
        static void exerciseMultiChoice(ref List<multiChoise> questions)
        {
            Console.Write("Enter count of question you want exercise:");
            int count =int.Parse(Console.ReadLine());
            List<multiChoise> temp = new List<multiChoise>();
            int lenghtOfQuestion = questions.Count;
            for(int i =0; i<count; i++)
            {
                Random rand = new Random();
                int num = rand.Next(0, lenghtOfQuestion);
                while (questions[num].State == true)
                {
                    num = rand.Next(0, lenghtOfQuestion);
                }
                questions[num].State = true;
                questions[num].show();
                Console.WriteLine();
                Console.Write("Enter your answer: ");
                questions[num].UserChoice = Console.ReadLine();
                temp.Add(questions[num]);
                Console.Clear();
            }
            
            foreach (multiChoise j in temp)
            {
                j.show();
                Console.WriteLine();
                Console.Write("Your answer is {0}.", j.UserChoice.ToUpper());
                j.getOption(j.UserChoice).show();
                if (j.Check(j.UserChoice) == true)
                {
                    Console.WriteLine("\t\tcongraluation.");
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("\t\tgood luck to you.");
                    Console.WriteLine();
                }
            }
        }
        static void readFile(string path, ref List<multiChoise> questions)
        {
            string[] lines = File.ReadAllLines(@path);
            foreach (string line in lines)
            {
                option opAnswer;
                List<option> options = new List<option>();
                bool temp;
                if (line[0] == '0')
                {
                    temp = false;
                }
                else
                {
                    temp = true;
                }

                // split for a question.
                // divide a string to 2 part
                // the first is the content and the state
                // the second is the option and the answer
                string[] s = line.Split("?");

                // get content
                string[] c = s[0].Split("~");
                string content = c[1] + "?";

                // end of get content
                string[] op = s[1].Split(">");
                string[] answer = op[1].Split("&");
                opAnswer = new option(answer[0], answer[1]);
                // divide the second part of the string
                // per part contain conten of option and the explain
                string[] j = op[0].Split("/");

                foreach (string k in j)
                {
                    string[] ops = k.Split("&");
                    options.Add(new option(ops[0], ops[1]));
                }
                questions.Add(new multiChoise(content, options, opAnswer, temp));
            }
        }
    }
}
