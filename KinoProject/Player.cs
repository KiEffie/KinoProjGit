﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KinoProject
{
    class Player
    {
        public int ID;
        private string name;
        public string Name { get; set; }

        public Player(int id)
        {
            ID = id;
            Name = name;
        }

        public override string ToString()
        {
            return "Player ID:" + ID + " " + Name;
        }


    }//end class
}// end namespace
