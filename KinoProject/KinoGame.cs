﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject
{
    class KinoGame
    {
        public Ticket Ticket;
        public List<int> KinoNumbers { get; set; }
        public bool Bonus { get; set; }



        public KinoGame(int noKino)
        {
            KinoNumbers = new List<int>(noKino);
            Bonus = GetBonus();
        }


        //createNumbersList
        //Bonus



        //Manual or Random create Kino Numbers List
        public bool ManualRandomChoice()
        {
            bool isManual = true;
            
            Console.WriteLine("Would you like to choose 6 numbers");
            Console.WriteLine("Or let the Kino System choose 6 Numbers from 1 to 80  Randomly for you");
            Console.Write("To input Randomly Press 0 \t");  Console.WriteLine("To input Manually Press 1");

            try
            {
                isManual = Convert.ToBoolean(Console.ReadLine());
            }
            catch
            {
                Console.Write("You didn't enter a 0 or 1 choice. Please try again! ");
                Console.WriteLine("Manually choose 6 Numbers OR Randomly? (0/1): ");
            }

            Console.WriteLine($"Your Choice is: {isManual}, ie {Convert.ToInt32(isManual)}");

            return isManual;
        }
       
        // Get Bonus
        public bool GetBonus()
        {
            bool anas = false;
            while (!anas)
            {
                string ansBonus = "";
               
                    Console.Write($"Will you play a Bonus number? (Y/N): ");
                    try { ansBonus = Console.ReadLine(); } catch { Console.Write("You didn't enter a Y or N. Please try again! "); Console.WriteLine("Will you play a Bonus number? (Y/N): "); }
                    if (ansBonus.ToUpper() == "Y")
                    {
                        //bonusNumber = kinoNumber;  // actually is the last number of x-length list
                        Bonus = anas = true;
                    }
            }
            return Bonus;
        }


      //auto increment
      

        //Διαβάζει τα νούμερα που παίζει ο Player και τα βάζει  σε μία λίστα 
        public void CreateManualSixNumbersList()
        {
            int kinoNumber = 0;
            int count = 1;
            
            //bool ans = false;
            Random r = new Random();

            //PlayersL.Add(new Player(r.Next(501, 1501)));

            Console.WriteLine("Choose 6 Numbers from the list above from 1 to 80");


            while (count <= 6)
            {
                Console.Write($"Enter Next Number, No{count}: ");
                try { kinoNumber = int.Parse(Console.ReadLine()); } catch { Console.Write("You didn't enter a Number. Please try again! "); Console.WriteLine("Please enter a valid Number:"); }


                if (KinoNumbers.Contains(kinoNumber)) //check whether the number is already in List
                {
                    Console.Write($"You have given this number before. Please try again!");
                }
                else if (kinoNumber > 80 || kinoNumber < 1)
                {
                    Console.Write($"You have given a number out of range of 1-80. Please try again!");
                }
                else
                {
                    KinoNumbers.Add(kinoNumber); // Add User Input to Six Numers List
                    count++;
                }
            }
         

        }//end CreateSixNumbersList

        
        //Δημιουργία ενός array με 6 νούμερα ----  άλλος ένας τρόπος
        public Array RandomSix()
        {
            int[] kinoNums = new int[6];
            Random randm = new Random();
            int num = 0;

            for (int i = 0; i < kinoNums.Length; i++)
            {
                num = randm.Next(1, 80);                        //generate random number
                                                                //check to see whether number has already been picked
                while (kinoNums.Contains(num) == true)		   //if it has try another random, until it hasnt been picked
                {
                    num = randm.Next(1, 80);
                }
                kinoNums[i] = num;			                    //hasnt been picked, so added to the array
            }
            return kinoNums;
        }



    }
}
