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

        static void notPlacable()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry, this ship can't be placed here.");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void addShips(int size, string[,] hitMatrix, string[,] selectMatrix)
        {
            //size = safeIntInput("Enter Size: ");
            //selectMatrix[0, 0] = "X";
            int[] currentSelection = new int[2];
            currentSelection[0] = 5;
            currentSelection[1] = 5;
            string selectionType = "X";
            int numberOfBotes = 5;

            while (true)
            {
                selectMatrix[currentSelection[0], currentSelection[1]] = selectionType;

                BuildAll(12, hitMatrix, selectMatrix);
                ConsoleKeyInfo keyinfo;
                //Console.WriteLine(currentSelection[0]);
                //Console.WriteLine(currentSelection[1]);
                keyinfo = Console.ReadKey();
                //Console.WriteLine(keyinfo.Key);
                if (keyinfo.Key == ConsoleKey.UpArrow)
                {
                    if (currentSelection[1] >= 1)
                    {
                        currentSelection[1] = currentSelection[1] - 1;
                        selectionType = "X";
                    }
                }
                else if (keyinfo.Key == ConsoleKey.DownArrow)
                {
                    if (currentSelection[1] < size - 1)
                    {
                        currentSelection[1] = currentSelection[1] + 1;
                        selectionType = "X";
                    }
                }
                else if (keyinfo.Key == ConsoleKey.LeftArrow)
                {
                    if (currentSelection[0] > 0)
                    {
                        currentSelection[0] = currentSelection[0] - 1;
                        selectionType = "X";
                    }
                }
                else if (keyinfo.Key == ConsoleKey.RightArrow)
                {
                    if (currentSelection[0] < size - 1)
                    {
                        currentSelection[0] = currentSelection[0] + 1;
                        selectionType = "X";
                    }
                }
                else if (keyinfo.Key == ConsoleKey.Enter)
                {
                    int length = 5;
                    selectionType = "E";
                    if (hitMatrix[currentSelection[0], currentSelection[1]] == "X")
                    {
                        notPlacable();
                    }
                    else
                    {
                        addShip(size, hitMatrix, selectMatrix, length, currentSelection);
                    }
                    selectionType = "X";
                }
                else if (keyinfo.Key == ConsoleKey.Backspace)
                {
                    selectionType = "D";
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
                    else if (selectMatrix[i, j] == "E")
                    {
                        textColorMatrix[i, j] = ConsoleColor.White;
                        backColorMatrix[i, j] = ConsoleColor.DarkBlue;
                        hitMatrix[i, j] = "#";
                    }
                    else if (selectMatrix[i, j] == "D")
                    {
                        textColorMatrix[i, j] = ConsoleColor.White;
                        backColorMatrix[i, j] = ConsoleColor.DarkRed;
                        hitMatrix[i, j] = " ";
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

            for (int b = 0; b < (size); b++)
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
                if (b < (size - 1))
                {
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
                else{
                    Console.Write("┃");
                }
            }
            Console.WriteLine("");
            
            
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

        static void addShip(int size, string[,] hitMatrix, string[,] selectMatrix, int length, int[] currentSelection)
        { 
            string selectionType = "X";

            BuildAll(12, hitMatrix, selectMatrix);

            ConsoleKeyInfo keyinfo;
            keyinfo = Console.ReadKey();

            if (keyinfo.Key == ConsoleKey.UpArrow)
            {
                bool isPlacable = true;
                for (var a = 0; a < length; a++)
                {
                    if ((currentSelection[1] - a) < 0)
                    {
                        a = length;
                        isPlacable = false;
                    }
                    else if (hitMatrix[currentSelection[0], currentSelection[1] - a] == "X")
                    {
                        a = length;
                        isPlacable = false;
                    }
                    
                }
                if (isPlacable){
                    for (var a = 0; a < length; a++)
                    {
                        {
                            hitMatrix[currentSelection[0], currentSelection[1] - a] = "X";
                        }
                    }
                    selectMatrix[currentSelection[0], currentSelection[1]] = "X";
                    hitMatrix[currentSelection[0], currentSelection[1]] = "X";
                }
                else
                {
                    selectMatrix[currentSelection[0], currentSelection[1]] = " ";
                    //hitMatrix[currentSelection[0], currentSelection[1]] = " ";
                    notPlacable();
                }
            }  
            else if (keyinfo.Key == ConsoleKey.DownArrow)
            {
                bool isPlacable = true;
                for (var a = 0; a < length; a++)
                {
                    if ((currentSelection[1] + a) > size)
                    {
                        a = length;
                        isPlacable = false;
                    }
                    else if (hitMatrix[currentSelection[0], currentSelection[1] + a] == "X")
                    {
                        a = length;
                        isPlacable = false;
                    }

                }
                if (isPlacable)
                {
                    for (var a = 0; a < length; a++)
                    {
                        {
                            hitMatrix[currentSelection[0], currentSelection[1] + a] = "X";
                        }
                    }
                    selectMatrix[currentSelection[0], currentSelection[1]] = "X";
                    hitMatrix[currentSelection[0], currentSelection[1]] = "X";
                }
                else
                {
                    selectMatrix[currentSelection[0], currentSelection[1]] = " ";
                    //hitMatrix[currentSelection[0], currentSelection[1]] = " ";
                    notPlacable();
                }
            }
            else if (keyinfo.Key == ConsoleKey.LeftArrow)
            {
                
                bool isPlacable = true;
                for (var a = 0; a < length; a++)
                {
                    if ((currentSelection[0] - a) > size)
                    {
                        a = length;
                        isPlacable = false;
                    }
                    else if (hitMatrix[currentSelection[0] - a, currentSelection[1]] == "X")
                    {
                        a = length;
                        isPlacable = false;
                    }

                }
                if (isPlacable)
                {
                    for (var a = 0; a < length; a++)
                    {
                        {
                            hitMatrix[currentSelection[0] - a, currentSelection[1]] = "X";
                        }
                    }
                    selectMatrix[currentSelection[0], currentSelection[1]] = "X";
                    hitMatrix[currentSelection[0], currentSelection[1]] = "X";
                }
                else
                {
                    selectMatrix[currentSelection[0], currentSelection[1]] = " ";
                    //hitMatrix[currentSelection[0], currentSelection[1]] = " ";
                    notPlacable();
                }




            }
            else if (keyinfo.Key == ConsoleKey.RightArrow)
            {
                bool isPlacable = true;
                for (var a = 0; a < length; a++)
                {
                    if ((currentSelection[0] + a) > size)
                    {
                        a = length;
                        isPlacable = false;
                    }
                    else if (hitMatrix[currentSelection[0] + a, currentSelection[1]] == "X")
                    {
                        a = length;
                        isPlacable = false;
                    }

                }
                if (isPlacable)
                {
                    for (var a = 0; a < length; a++)
                    {
                        {
                            hitMatrix[currentSelection[0] + a, currentSelection[1]] = "X";
                        }
                    }
                    selectMatrix[currentSelection[0], currentSelection[1]] = "X";
                    hitMatrix[currentSelection[0], currentSelection[1]] = "X";
                }
                else
                {
                    selectMatrix[currentSelection[0], currentSelection[1]] = " ";
                    //hitMatrix[currentSelection[0], currentSelection[1]] = " ";
                    notPlacable();
                }
            }

            BuildAll(size, hitMatrix, selectMatrix);

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
            int size = 12;
            string[,] hitMatrix = new string[size, size];
            string[,] selectMatrix = new string[size, size];

            for (int i = 0; i <= 11; i++)
            {
                for (int j = 0; j <= 11; j++)
                {
                    selectMatrix[i, j] = "O";
                    hitMatrix[i, j] = " ";
                }
            }


            
            
            addShips(size, hitMatrix, selectMatrix);
            Console.Read();
        }
    }
}
