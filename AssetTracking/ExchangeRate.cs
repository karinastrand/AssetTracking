namespace AssetTracking;
public  class ExchangeRate
{//Class with exchange rate for currency

    public string Currency { get; set; }
    public double Rate { get; set; }
    public ExchangeRate()
    {
    }
    public ExchangeRate(string currency, double rate)
    {
        Currency = currency;
        Rate = rate;
    }
    public void Print()
    {
        Console.WriteLine($"{Currency.PadRight(15)}{Rate}");
    }
    public string ExchangeRateToString()
    {
        //Converts ExchangeRate to a semicolon seperated string (comma seperated will not work, rate is a double and may contain a comma
        return $"{Currency};{Rate.ToString()}";
    }
    public ExchangeRate ExchangeRateFromString(string rateString)
    {
        /*Converts a string to ExchangeRate, if the string with the different fields seperated with ";". If the string 
        doesn't contain 2 parts or if some part can't be converted to the type the constructor needs the conversion fails.*/
        string[] rateParts = rateString.Split(';');
        double rate = 0;
        try
        {
           rate= Convert.ToDouble(rateParts[1]);
        }
        catch (IndexOutOfRangeException)
        {
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("couldn't convert string to exchange rate, problem with number of semicomma seperated parts of the string");
            ResetColor();
        }
        catch (FormatException)
        {
            ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("couldn't convert string to exchange rate, due to format problem");
            ResetColor();
        }
        return new ExchangeRate(rateParts[0], rate);
    }
}
