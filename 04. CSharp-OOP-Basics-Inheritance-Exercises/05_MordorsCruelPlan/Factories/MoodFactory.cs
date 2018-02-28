using System;
using System.Collections.Generic;
using System.Text;

public class MoodFactory
{
    private const int AngryTopBorder = -6;
    private const int SadTopBorder = 0;
    private const int HappyTopBorder = 15;

    public static string GetMood(int happinessPoints)
    {
        if (happinessPoints <= AngryTopBorder)
        {
            return "Angry";
        }
        else if (happinessPoints <= SadTopBorder)
        {
            return "Sad";
        }
        else if (happinessPoints <= HappyTopBorder)
        {
            return "Happy";
        }
        else
        {
            return "JavaScript";
        }
    }

}

