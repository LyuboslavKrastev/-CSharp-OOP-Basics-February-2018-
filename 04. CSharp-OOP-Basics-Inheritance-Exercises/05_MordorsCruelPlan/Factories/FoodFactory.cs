using System;
using System.Collections.Generic;
using System.Text;

public class FoodFactory
{
    public static Food GetFood(string foodInput)
    {
        switch (foodInput.ToLower())
        {
            case "apple":
                return new Apple();
            case "lembas":
                return new Lembas();
            case "cram":
                return new Cram();
            case "melon":
                return new Melon();
            case "honeycake":
                return new HoneyCake();
            case "mushrooms":
                return new Mushrooms();
            default:
                return new Everything_else();
        }
    }
}

