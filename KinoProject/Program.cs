﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject
{
    enum WinCategory
    {
        SixPlus = 1,
        Six = 2,
        FivePlus = 4,
        Five = 8,
        FourPlus = 16,
        Four = 32,
        ThreePlus = 64,
        Three = 128,
        TwoPlus = 256,
        Two = 512,
        OnePlus = 1024,
        One = 2048,
        Zero = 4096

    }
    class Program
    {

        static void Main(string[] args)
        {

        bool ans = true;
        Player player = new Player(1);
        Lottery lottery = new Lottery();
            List<int> PlayersList = new List<int>();
            List<int> TicketsList = new List<int>();

            do
            {
                int choice = 0;
                Console.WriteLine();
                Console.WriteLine("Choose a category number");
                Console.WriteLine("1. One Player Kino Game");
                Console.WriteLine("2. Many Players Kino Game");
                Console.WriteLine("3. Make the Draw");
                Console.WriteLine("4. Winners");
                Console.WriteLine("5. Statistics");
                Console.WriteLine("6. Exit");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("Please enter a valid menu number (1-6)");
                }
                switch (choice)
                {
                    case 1:
                        CreateNumbersTable();
                        player.CreateSixNumbersList();
                        break;
                    case 2:
                        var newDict=player.CreateRandomPlayersDict();
                        player.PrintRandomPlayersWithNumbersDict(newDict);
                        break;
                    case 3:
                        double drawAmount = 0;
                        bool test = false;
                        do
                        {
                            Console.WriteLine("Enter the Total Draw Amount to be shared: ");
                            try { drawAmount = double.Parse(Console.ReadLine());}
                            catch
                            {
                                test = true;
                                Console.WriteLine("Enter a valid double for total Draw Amount");
                            }
                            
                        } while (test);
                        Draw draw = new Draw(drawAmount);
                        draw.PrintWinnerList();
                        break;
                    case 4:
                        lottery.Results();
                        lottery.CountMatches();
                        lottery.PrintMatches();
                        break;
                    case 5:
                        break;
                    case 6:
                        Console.WriteLine("You chose to Exit Program");
                        return;
                    case 7:
                        break;
                    default:
                        break;
                }//end switch

                Console.WriteLine();
                Console.Write("PROGRAM END:Would you like to continue? (Y/N): ");
                string answ = Console.ReadLine();

                try
                {
                    if (answ.ToUpper() != "Y"){ans = false;}
                }
                catch
                {
                    Console.WriteLine("Please enter a valid menu number (1-11)");
                }

            } while (ans);
            return;


            /////***************************************************************************************************************************************
            void CreateNumbersTable()
            {


                for (int j = 1; j <= 80; j++)
                {
                    if (j < 10)
                    {
                        Console.Write("  {0}  ", j);
                    }
                    else if (j % 10 == 0)
                    {
                        Console.Write("  {0}  ", j);
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Write("  {0}  ", j);
                    }
                }
            }

        }//end Main
    }//end Program
}//end Namespace
