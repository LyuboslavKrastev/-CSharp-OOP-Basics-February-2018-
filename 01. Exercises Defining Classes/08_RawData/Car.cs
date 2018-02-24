using System;
using System.Collections.Generic;
using System.Text;

    public class Car
    {
    private string model;
    private Engine engine;
    private Cargo cargo;
    private List<Tire> tires;

    public Car()
    {
        this.tires = new List<Tire>();
    }

    public List<Tire> Tires
    {
        get { return tires; }
        set { tires = value; }
    }



    public Cargo Cargo
    {
        get { return cargo; }
        set { cargo = value; }
    }


    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }


    public string Model
    {
        get { return model; }
        set { model = value; }
    }

}

