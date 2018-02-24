using System;
using System.Collections.Generic;
using System.Text;


    public class Room
    {
        public int Number { get; set; }
        public List<string> Patients { get; set; } = new List<string>();

        public Room(int number)
        {
            this.Number = number;
        }
    }

