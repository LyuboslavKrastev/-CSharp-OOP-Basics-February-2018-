using System;
using System.Text.RegularExpressions;

class Smartphone : IBrowse, ICall
{
    private const string validURLPattern = @"^[\D]*$";
    private const string validPhonePattern = @"^[\d]+$";
    private const string invalidNumberMessage = "Invalid number!";
    private const string invalidURLMessage = "Invalid URL!";

    public string Browse(string address)
    {
        ValidateURL(address);

        string message = $"Browsing: {address}!";
        return message;
    }


    public string Call(string phoneNumber)
    {
        ValidateNumber(phoneNumber);

        string message = $"Calling... {phoneNumber}";
        return message;
    }

    private static void ValidateNumber(string phoneNumber)
    {
        if (!Regex.IsMatch(phoneNumber, validPhonePattern))
        {
            throw new ArgumentException(invalidNumberMessage);
        }
    }

    private static void ValidateURL(string address)
    {
        if (!Regex.IsMatch(address, validURLPattern))
        {
            throw new ArgumentException(invalidURLMessage);
        }
    }
}

