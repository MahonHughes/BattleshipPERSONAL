using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_of_increace
{
    class Program
    {

        
        static int safeIntInput(String message)
        {
            int Number = 0;
            bool isRunning = true;
            while (isRunning == true)
            {
                Console.WriteLine("");
                Console.Write(message);
                string stringToTest = Console.ReadLine();
                bool res = int.TryParse(stringToTest, out Number);
                if (res == false)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Invalid Input, please try again: ");
                }
                else
                {
                    isRunning = false;
                }
            }
            return Number;
        }

        static void BuildAll()
        {
            int size = 0;
            string input = Console.ReadLine();
            size = Convert.ToInt32(input);
            if (size == 0)
            {
                Console.WriteLine("Excuse me?");
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("Could you please leave?");
                System.Threading.Thread.Sleep(5000);
                //Console.Read();
                size = 88888;
            }
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string pop = " ";
            Console.Clear();

            char letter = 'A';
            Console.Write("    ");
            for (var y = 0; y < size; y++)
            {
                Console.Write(letter);
                Console.Write("   ");
                letter++;
            }
            Console.WriteLine("");
            Console.Write("  ┏");
            for (int a = 0; a < (size - 1); a++)
            {
                Console.Write("━━━");
                Console.Write("┳");
            }
            Console.Write("━━━┓");

            for (int b = 0; b < (size - 1); b++)
            {
                Console.WriteLine("");

                if (b < 9)
                {
                    Console.Write(b + 1);
                    Console.Write(" ");
                }
                else
                {
                    Console.Write(b + 1);
                }

                for (int c = 0; c < size; c++)
                {
                    Console.Write("┃");
                    Console.Write(" " + pop + " ");
                }

                Console.Write("┃");
                Console.WriteLine("");
                Console.Write("  ┣");
                for (int a = 0; a < (size - 1); a++)
                {
                    Console.Write("━━━");
                    Console.Write("╋");
                }
                Console.Write("━━━┫");
            }
            Console.WriteLine("");
            if (size <= 9)
            {
                Console.Write(size);
                Console.Write(" ");
            }
            else
            {
                Console.Write(size);
            }

            for (int c = 0; c < size; c++)
            {
                Console.Write("┃");
                Console.Write(" " + pop + " ");
            }
            Console.Write("┃");
            Console.WriteLine("  ");
            Console.Write("  ┗");
            for (int a = 0; a < (size - 1); a++)
            {
                Console.Write("━━━");
                Console.Write("┻");
            }
            Console.Write("━━━┛");

            // ┗━━━┻━━━┻━━━┻━━━┻━━━┻━━━┻━━━┻━━━┻━━━┻━━━┻━━━┻━━━┛

            //Console.ReadLine();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Teapots");

            while (true)
            {
                BuildAll();
            }

        }
    }
}
