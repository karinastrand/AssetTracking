namespace AssetTracking;
 class Functions
{//Help class with useful functions

    //Checks if the date is older than numberOfMonths from today
    public static bool isOlderThanXMonthsfromNow(DateTime date, int numberOfMonths)
    {
        DateTime dateToCompareWith=date.AddMonths(numberOfMonths);
        return (DateTime.Today - dateToCompareWith).TotalDays > 0;
    }
   
    //Converts a price from USD to localCurrency using the exchange rates from the list in of exchange rates saved in the file.
    public static double PriceToLocalPrice(string localCurrency, double price)
    {
        double lokalPrice=price;
        //Creats an ExchangeRates object and fetches the list from the file of exchange rates
        ExchangeRates exchangeRates = new ExchangeRates();
        exchangeRates.GetFromFile();
        //fetches the exchange rate of the localCurrency
        double rate = exchangeRates.ExchangeRatesList.Where(rates => rates.Currency == localCurrency).First().Rate;
        try
        {
            lokalPrice = price / rate;
        }
        catch (DivideByZeroException)
        {
            WriteLine("ExchangeRate was 0");
        }
        return lokalPrice;
    }
}
