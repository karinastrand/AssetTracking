
namespace AssetTracking;

public  class ExchangeRate
{
    public ExchangeRate(string currency, double rate)
    {
        Currency = currency;
        Rate = rate;
    }

    public ExchangeRate()
    {
    }

    public string Currency {  get; set; }
    public double Rate { get; set; }

    public void Print()
    {
        Console.WriteLine($"{Currency.PadRight(15)}{Rate}");
    }
    public string ExchangeRateToString()
    {
        return $"{Currency};{Rate.ToString()}";
    }

    public ExchangeRate ExchangeRateFromString(string rateString)
    {
        string[] rateParts = rateString.Split(';');
        double rate = 0;
        try
        {
           rate= Convert.ToDouble(rateParts[1]);
        }
        catch (FormatException)
        {

            Console.WriteLine("ExchangeRate is missing, will be set to 0");
        }
        return new ExchangeRate(rateParts[0], rate);
    }
}
