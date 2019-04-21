﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject
{
    class KinoGame
    {
        public List<int> KinoNumbersList { get; set; }

        public int noKino;
        private bool isManual = true;


        public KinoGame()
        {
            KinoNumbersList =  new List<int>();
        }

       
        //Manual or Random create Kino Numbers List
        private bool ChooseManualRandom()
        {
            
            Console.WriteLine("Would you like to choose Kino numbers");
            Console.WriteLine("Or let the Kino System choose 6 Numbers from 1 to 80  Randomly for you");
            Console.Write("Press M for Manual \t"); Console.WriteLine("Press R for Random (M/R): ");

            try
            {
                var ans = Console.ReadLine().ToUpper();


                if (ans == "M")
                { isManual = true; }
                else
                { isManual = false; }
            }
            catch
            {
                Console.Write("You didn't enter an R or M choice. Please try again! ");
                Console.WriteLine("Manually choose 6 Numbers OR Randomly? (M/R): ");
            }
            Console.WriteLine("Your Choice is: {0}", (isManual ? "Manual" : "Randon"));
            return isManual;
        }//end Manual OR Random

       
        //get how many KINo Number will be on Ticket (3-15)
        private int GetNoKino()
        {
            Console.WriteLine("How many Kino Numbers would you like to play? (min 3 - max 15)");
            try {
                noKino = int.Parse(Console.ReadLine());
                if (noKino < 3 || noKino > 10)
                {
                    Console.Write("You didn't enter a Valid Number. Please try again! "); Console.WriteLine("Please enter a valid Number (min 3 - max 15):");
                }
                } catch { Console.Write("You didn't enter a Number. Please try again! "); Console.WriteLine("Please enter a valid Number (min 3 - max 15):"); }

            return noKino;
        }

        public List<int> SetKinoList()
        {
            //List<int> KinoNumbersList = new List<int>();
            ChooseManualRandom();
            noKino = GetNoKino();
            if (isManual)
            {
                KinoNumbersList = CreateManualKINONumbersList(noKino);
            }
            else
            {
                KinoNumbersList = CreateRandomKINONumbersList(noKino);
            }
            //SortKinoNumbersList();
          return KinoNumbersList;
        }
        // sort the list but keep last the probable Kino Bonus 
        private List<int> SortKinoNumbersList()
        {

            var temp = KinoNumbersList.Last();
            KinoNumbersList.Sort();
            KinoNumbersList.Remove(temp);
            KinoNumbersList.Add(temp);

            return KinoNumbersList;
        }
        // Δημιουργία μιας λίστας με KINO numbers - Manually 
        private List<int> CreateManualKINONumbersList(int noKino)
        {
            int kinoNumber = 0;
            int count = 1;

            CreateNumbersTable();
            Console.WriteLine($"Choose {noKino} Numbers from the list above from 1 to 80");


            while (count <= noKino)
            {
                Console.Write($"Enter Next Number, No{count}: ");
                try { kinoNumber = int.Parse(Console.ReadLine()); } catch { Console.Write("You didn't enter a Number. Please try again! "); Console.WriteLine("Please enter a valid Number:"); }


                if (KinoNumbersList.Contains(kinoNumber))
                //check whether the number is already in List
                {
                    Console.Write($"You have given this number before. Please try again!");
                }
                else if (kinoNumber > 80 || kinoNumber < 1)
                {
                    Console.Write($"You have given a number out of range of 1-80. Please try again!");
                }
                else
                {
                    KinoNumbersList.Add(kinoNumber); // Add User Input to Six Numers List
                    count++;
                }
            }
            return KinoNumbersList;

        }//end Manual

        // Δημιουργία μιας λίστας με KINO numbers - Randomly
        private List<int> CreateRandomKINONumbersList(int noKino)
        {
            Random random = new Random();
            int randomNumber = (random.Next(1, 80));

            for (int j = 0; j < noKino; j++)
            {
                if (!KinoNumbersList.Contains(randomNumber))
                {
                    KinoNumbersList.Add(randomNumber);
                }
                else
                {
                    j--;
                }
                randomNumber = (random.Next(1, 80));
            }
            return KinoNumbersList;
        }//end Random

        public void CreateNumbersTable()
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

    }
}
