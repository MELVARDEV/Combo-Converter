using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Timers;
using System.Diagnostics;
using System.Threading;

namespace combo_converteer
{
    class Program
    {
        static long CountLinesInFile(string f)
        {
            long count = 0;
            using (StreamReader r = new StreamReader(f))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }

        private int _calls;
        
        private static void display_menu()
        {
            Console.Clear();
            Console.WriteLine("---------------------------------------" + Environment.NewLine);
            Console.WriteLine("-------------Combo Reverser------------" + Environment.NewLine);
            Console.WriteLine("---------------------------------------" + Environment.NewLine + Environment.NewLine);
        }

        private static void reverseCombo(string read_filename, string output)
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            long lines_count = CountLinesInFile(read_filename);
            string[] lines = System.IO.File.ReadAllLines(read_filename);
            int counter = 0;
            foreach (string line in lines)
            {
                counter++;
                Console.Title = "Combo status: " + counter + "/" + lines_count;
                // Use a tab to indent each line of the file.
                string password = line.Split(':').Last();
                string email = line.Split(':')[0];
                File.AppendAllText(output, password + ":" + email + Environment.NewLine);
                Console.WriteLine(line);
            }
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "---------------------------" + Environment.NewLine + "Reversing Combo Done.");
            System.Console.ReadKey();
            
        }


        private static void email_toUsername(string read_filename, string output)
        {
            FileStream ostrm;
            StreamWriter writer;
            TextWriter oldOut = Console.Out;
            long lines_count = CountLinesInFile(read_filename);
            string[] lines = System.IO.File.ReadAllLines(read_filename);
            int counter = 0;
            foreach (string line in lines)
            {
                counter++;
                Console.Title = "Combo status: " + counter + "/" + lines_count;
                // Use a tab to indent each line of the file.
                string password = line.Split(':').Last();
                string email = line.Split(':')[0];
                string username = email.Split('@')[0];
                File.AppendAllText(output, username + ":" + password + Environment.NewLine);
                Console.WriteLine(line);
            }
            Console.WriteLine(Environment.NewLine + Environment.NewLine + "---------------------------" + Environment.NewLine + "Reversing Combo Done.");
            System.Console.ReadKey();
        }


        static void Main(string[] args)
        {
            mainfinction:
            display_menu();
            Console.WriteLine("Please choose mode:" + Environment.NewLine);
            Console.WriteLine("[1] Combo Reverse (pass:email --> email:pass)" + Environment.NewLine);
            Console.WriteLine("[2] Email Combo --> Username Combo (username@gmail.com:pass --> username:pass):" + Environment.NewLine);
            string choice = Console.ReadLine();
            if(choice == "1")
            {
                Console.Clear();
                display_menu();
                Console.WriteLine("Please enter your combo filename without extension (fx. 'combo')" + Environment.NewLine);
                Console.WriteLine("(It must be in the same folder as the program):" + Environment.NewLine);
                string read_filename = Console.ReadLine() + ".txt";
                Console.Clear();
                display_menu();
                Console.WriteLine("Please enter output filename (fx. 'output'):" + Environment.NewLine);
                string output = Console.ReadLine() + ".txt";
                Console.Clear();

                reverseCombo(read_filename,output);
                goto mainfinction;
            } else if (choice == "2")
            {
                Console.Clear();
                display_menu();
                Console.WriteLine("Please enter your combo filename without extension (fx. 'combo')" + Environment.NewLine);
                Console.WriteLine("(It must be in the same folder as the program):" + Environment.NewLine);
                string read_filename = Console.ReadLine() + ".txt";
                Console.Clear();
                display_menu();
                Console.WriteLine("Please enter output filename (fx. 'output'):" + Environment.NewLine);
                string output = Console.ReadLine() + ".txt";
                Console.Clear();
                email_toUsername(read_filename, output);

                goto mainfinction;
            } else
            {
                Console.Clear();
                display_menu();
                Console.WriteLine("There is not such function");
                Thread.Sleep(1500);
                goto mainfinction;
            }

            









        }
    }
}
