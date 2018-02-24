using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


public class Hospital
{
    public List<Department> Departments { get; set; } = new List<Department>();

    public Room FindRoom(string departament)
    {
        var freeRoom = this.Departments.FirstOrDefault(d => d.Name == departament).Rooms.FirstOrDefault(r => r.Patients.Count < 3);
        return freeRoom;
    }

    public void AddPatient(string department, Room room, string patient)
    {
        this.Departments.FirstOrDefault(d => d.Name == department).Rooms.FirstOrDefault(r => r == room).Patients.Add(patient);
    }

    public void CreateNewDepartment(string departament)
    {
        this.Departments.Add(new Department(departament));
    }

    public string[] FindRoomPatients(string[] args, int roomNumber)
    {
        var department = args[0];
        var patients = this.Departments.FirstOrDefault(d => d.Name == department)
            .Rooms.FirstOrDefault(r => r.Number == roomNumber)
            .Patients.OrderBy(p => p).ToArray();

        return(patients);
    }



    public string[] FindDepartmentPatients(string[] args)
    {
        var department = args[0];
        var patients = this.Departments.FirstOrDefault(d => d.Name == department).Rooms
            .Where(x => x.Patients.Count > 0).SelectMany(x => x.Patients).ToArray();

        return(patients);
    }
}

