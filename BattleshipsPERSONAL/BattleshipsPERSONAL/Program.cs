using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_of_increace
{
    class Program
    {
        static void Winner()
        {
            Console.Clear();
            Console.WriteLine("Congratulations, you have won this game of Battleships!");
            Console.ReadKey();
            System.Environment.Exit(1);
        }
        
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
            //Console.WriteLine("Sorry, this ship can't be placed here.");
            //Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        static void Destroy(int size, string[,] hitMatrix, string[,] selectMatrix, int crosses, int numberOfBoats)
        {
            //size = safeIntInput("Enter Size: ");
            //selectMatrix[0, 0] = "X";
            int[] currentSelection = new int[2];
            currentSelection[0] = 0;
            currentSelection[1] = 0;
            string selectionType = "X";
            //int numberOfboats = 5;

            while (true)
            {
                selectMatrix[currentSelection[0], currentSelection[1]] = selectionType;

                BuildAll(size, hitMatrix, selectMatrix, crosses, numberOfBoats);
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
                    if (hitMatrix[currentSelection[0], currentSelection[1]] == " ")
                    {
                        hitMatrix[currentSelection[0], currentSelection[1]] = "/";
                    }
                    else if (hitMatrix[currentSelection[0], currentSelection[1]] == "X")
                    {
                        hitMatrix[currentSelection[0], currentSelection[1]] = "!";
                    }
                    selectionType = "X";
                }
                else if (keyinfo.Key == ConsoleKey.Backspace)
                {
                    selectionType = "D";
                }

                for (int i = 0; i <= size - 1; i++)
                {
                    for (int j = 0; j <= size - 1; j++)
                    {
                        selectMatrix[i, j] = "O";
                    }
                }

            }

        }
        
        static void BuildAll(int size, string[,] hitMatrix, string[,] selectMatrix, int crosses, int numberOfboats)
        {
            int hits = 0;
            ConsoleColor[,] textColorMatrix = new ConsoleColor[size, size];
            ConsoleColor[,] backColorMatrix = new ConsoleColor[size, size];
            string[,] displayMatrix = new string[size, size];
            for (int i = 0; i <= size-1; i++)
            {
                for (int j = 0; j <= size-1; j++)
                {
                    textColorMatrix[i, j] = ConsoleColor.White;
                    backColorMatrix[i, j] = ConsoleColor.Black;
                    displayMatrix[i, j] = " ";
                }
            }
            for (int i = 0; i <= size-1; i++)
            {
                for (int j = 0; j <= size-1; j++)
                {
                    if (hitMatrix[i, j] == "/")
                    {
                        textColorMatrix[i, j] = ConsoleColor.White;
                        backColorMatrix[i, j] = ConsoleColor.Black;
                        displayMatrix[i, j] = "●";
                    }
                    else if (hitMatrix[i, j] == "!")
                    {
                        textColorMatrix[i, j] = ConsoleColor.Red;
                        backColorMatrix[i, j] = ConsoleColor.Black;
                        displayMatrix[i, j] = "●";
                        hits++;

                    }
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
            int total = 0;
            //Console.ReadLine();
            for (var a = 2; a <= numberOfboats+1; a++)
            {
                total = total + a;
                //total = total - 1;
                
            }
            Console.WriteLine("");
            Console.WriteLine("Game stats. Hits: " + hits + "/" + total);
            if (hits == total)
            {
                Winner();
            }
        }

        static bool addShip(int size, string[,] hitMatrix, string[,] selectMatrix, int length, int[] currentSelection, int direction, int crosses)
        { 
            string selectionType = "X";

            //BuildAll(12, hitMatrix, selectMatrix);

            //ConsoleKeyInfo keyinfo;
            //keyinfo = Console.ReadKey();
            bool isPlacable = true;
            if (direction == 1)
            {
                isPlacable = true;
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
                        
                        hitMatrix[currentSelection[0], currentSelection[1] - a] = "X";
                        
                        //shipMatrix[currentSelection[0], currentSelection[1] - a] = length-1;
                        

                    }
                    //selectMatrix[currentSelection[0], currentSelection[1]] = "X";
                    hitMatrix[currentSelection[0], currentSelection[1]] = "X";
                }
                else
                {
                    //selectMatrix[currentSelection[0], currentSelection[1]] = " ";
                    //hitMatrix[currentSelection[0], currentSelection[1]] = " ";
                    notPlacable();
                }
            }  
            else if (direction == 2)
            {
                isPlacable = true;
                for (var a = 0; a < length; a++)
                {
                    if ((currentSelection[1] + a) > size - 1)
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
                            //shipMatrix[currentSelection[0], currentSelection[1] + a] = length - 1;
                            
                        }
                    }
                    //selectMatrix[currentSelection[0], currentSelection[1]] = "X";
                    hitMatrix[currentSelection[0], currentSelection[1]] = "X";
                }
                else
                {
                    //selectMatrix[currentSelection[0], currentSelection[1]] = " ";
                    //hitMatrix[currentSelection[0], currentSelection[1]] = " ";
                    notPlacable();
                }
            }
            else if (direction == 3)
            {
                
                isPlacable = true;
                for (var a = 0; a < length; a++)
                {
                    if ((currentSelection[0] - a) < 0)
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
                            //shipMatrix[currentSelection[0] - a, currentSelection[1]] = length - 1;
                            
                        }
                    }
                    //selectMatrix[currentSelection[0], currentSelection[1]] = "X";
                    hitMatrix[currentSelection[0], currentSelection[1]] = "X";
                }
                else
                {
                   // selectMatrix[currentSelection[0], currentSelection[1]] = " ";
                    //hitMatrix[currentSelection[0], currentSelection[1]] = " ";
                    notPlacable();
                }


               
                

            }
            else if (direction == 4)
            {
                isPlacable = true;
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
                            //shipMatrix[currentSelection[0] + a, currentSelection[1]] = length - 1;
                            
                        }
                    }
                    //selectMatrix[currentSelection[0], currentSelection[1]] = "X";
                    hitMatrix[currentSelection[0], currentSelection[1]] = "X";
                }
                else
                {
                   // selectMatrix[currentSelection[0], currentSelection[1]] = " ";
                    //hitMatrix[currentSelection[0], currentSelection[1]] = " ";
                    notPlacable();
                }
            }
            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    selectMatrix[i, j] = "O";
                }
            }
            //BuildAll(size, hitMatrix, selectMatrix);
            return isPlacable;
        }

        static void addMatix(int size, int numberOfboats)
        {
            string[,] hitMatrix = new string[size, size];

            for (int i = 0; i <= size-1; i++)
            {
                for (int j = 0; j <= size-1; j++)
                {
                    hitMatrix[i, j] = (" ");
                }
            }
           
        }

        static void populate(string[,] hitMatrix, string[,] selectMatrix, int size)
        {
            ConsoleColor [,]
            textColorMatrix = new ConsoleColor[size, size];
            ConsoleColor[,] backColorMatrix = new ConsoleColor[size, size];

            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
                {
                    textColorMatrix[i, j] = ConsoleColor.White;
                    backColorMatrix[i, j] = ConsoleColor.Black;
                    
                }
}
            for (int i = 0; i <= size; i++)
            {
                for (int j = 0; j <= size; j++)
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
        }
        
        static void Main(string[] args)
        {

            Console.WriteLine("Welcome to battleships!");


            int size = 1;
            int crosses = 0;
            bool isRunning = true;
            while (isRunning)
            {
               size = safeIntInput("Please enter grid size (1 to 26): ");
                if (size >= 2)
                {
                    if (size <= 26){
                        isRunning = false;
                    }
                    else
                    {
                        Console.WriteLine("Grid must be less than 27");
                    }
                }
                else
                {
                    Console.WriteLine("Grid must be bigger than 1");
                }
            }

            int numberofboats = safeIntInput("Please enter desired number of boats: ");
            string[,] hitMatrix = new string[size, size];
            string[,] selectMatrix = new string[size, size];
            //int[,] shipMatrix = new int[size, size];

            for (int i = 0; i <= size - 1; i++)
            {
                for (int j = 0; j <= size - 1; j++)
                {
                    selectMatrix[i, j] = "O";
                    hitMatrix[i, j] = " ";
                }
            }
            
            int length = 2;

            for (int a = 0; a < numberofboats; a++)
            {
                Random generator = new Random();
                int rand = generator.Next(1, size);

                Random generator2 = new Random();
                int rand2 = generator.Next(1, size);

                int[] currentSelection = new int[2];
                currentSelection[0] = rand;
                currentSelection[1] = rand2;

                Random generator3 = new Random();
                int rand3 = generator.Next(1, 4);
                //selectMatrix[currentSelection[0], currentSelection[1]] = "E";
                //populate(hitMatrix, selectMatrix, size);


                if (addShip(size, hitMatrix, selectMatrix, length, currentSelection, rand3, crosses))
                {
                    Console.CursorVisible = false;
                    //Console.Clear();
                    length++;
                    Console.CursorLeft = 0;
                    Console.Write("[");
                    Console.CursorLeft = numberofboats + 1;
                    Console.Write("]");
                    Console.CursorLeft = 1;
                    
                    for (var b = 0; b < numberofboats; b++)
                    {
                        Console.CursorLeft = b + 1;
                        if (b <= a)
                        {
                            Console.Write("=");
                        }
                    }

                    Console.CursorLeft = 50;

                }
                else
                {
                    a--;
                }



            }
            //BuildAll(size, hitMatrix, selectMatrix);
            Destroy(size, hitMatrix, selectMatrix, crosses, numberofboats);
            //addShips(size, hitMatrix, selectMatrix);
            Console.Read();
        }
            

    }
}
