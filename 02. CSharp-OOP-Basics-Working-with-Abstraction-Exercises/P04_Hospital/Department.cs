using System;
using System.Collections.Generic;
using System.Text;


    public class Department
    {

    public Department(string name)
    {
        this.Name = name;

        for (int roomNumber = 1; roomNumber <= 20; roomNumber++)
        {
            this.Rooms.Add(new Room(roomNumber));
        }
    }

    public string Name { get; set; }
    public List<Room> Rooms { get; set; } = new List<Room>();


    }

