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

        static void addShips(int size, string[,] hitMatrix, string[,] selectMatrix)
        {
            //size = safeIntInput("Enter Size: ");
            //selectMatrix[0, 0] = "X";
            int[] currentSelection = new int[2];
            currentSelection[0] = 5;
            currentSelection[1] = 5;
            while (true)
            {

                selectMatrix[currentSelection[0], currentSelection[1]] = "X";

                BuildAll(12, hitMatrix, selectMatrix);
                ConsoleKeyInfo keyinfo;
                Console.WriteLine(currentSelection[0]);
                Console.WriteLine(currentSelection[1]);
                keyinfo = Console.ReadKey();
                //Console.WriteLine(keyinfo.Key);
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    //Console.WriteLine("Up");
                    if (currentSelection[1] >= 1){
                        currentSelection[1] = currentSelection[1] - 1;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    Console.WriteLine("Down");
                    if (currentSelection[1] < size - 1)
                    {
                        currentSelection[1] = currentSelection[1] + 1;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    Console.WriteLine("Left");
                    if (currentSelection[0] > 0)
                    {
                        currentSelection[0] = currentSelection[1] - 1;
                    }
                }
                else if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    Console.WriteLine("Right");
                    if (currentSelection[0] < size - 1)
                    {
                        currentSelection[0] = currentSelection[0] + 1;
                    }
                }


                for (int i = 0; i <= 11; i++)
                {
                    for (int j = 0; j <= 11; j++)
                    {
                        selectMatrix[i, j] = "O";
                    }
                }

            }

        }

        static void BuildAll(int size, string[,] hitMatrix, string[,] selectMatrix)
        {
            ConsoleColor[,] textColorMatrix = new ConsoleColor[size, size];
            ConsoleColor[,] backColorMatrix = new ConsoleColor[size, size];

            for (int i = 0; i <= 11; i++)
            {
                for (int j = 0; j <= 11; j++)
                {
                    textColorMatrix[i, j] = ConsoleColor.White;
                    backColorMatrix[i, j] = ConsoleColor.Black;
                }
            }
            for (int i = 0; i <= 11; i++)
            {
                for (int j = 0; j <= 11; j++)
                {
                    if (selectMatrix[i, j] == "X")
                    {
                        textColorMatrix[i, j] = ConsoleColor.Blue;
                        backColorMatrix[i, j] = ConsoleColor.White;
                    }
                }
            }

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
                    Console.Write(" ");
                    Console.BackgroundColor = backColorMatrix[c,b];
                    Console.ForegroundColor = textColorMatrix[c, b];
                    Console.Write(hitMatrix[c, b]);
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(" ");
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
                Console.Write(" " + hitMatrix[c, size - 1] + " ");
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


        static void addMatix(int size, int numberOfBotes)
        {
            string[,] hitMatrix = new string[size, size];

            for (int i = 0; i <= 11; i++)
            {
                for (int j = 0; j <= 11; j++)
                {
                    hitMatrix[i, j] = (" ");
                }
            }
           
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
