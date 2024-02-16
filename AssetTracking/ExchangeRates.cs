namespace AssetTracking;
public class ExchangeRates : ILists
{
    /*Contains a list of ExchangeRate objets and name of the file where they are stored. If you add a file with todays exchange rates
     the program reads it to the list when it starts and the currency converion will be correct.*/
    public string NameOfFile { get; set; } = "exchangerates.txt";
    public List<ExchangeRate> ExchangeRatesList { get; set; }=new List<ExchangeRate>();
    public void Show()
    {
        //Prints info about the Exchange Rates on the console
        WriteLine("Currency".PadRight(15) + "ExchangeRate".PadRight(15));
        foreach (ExchangeRate rate in ExchangeRatesList)
        {
            rate.Print();
        }
    }
    public void GetFromFile()
    {
        //Reads from the file and convert the string to an Exchange Rate Object and adds it to the list.
        FileHandling ReadFile= new FileHandling(NameOfFile);
        List<string> rates=ReadFile.ReadFromFile();
        foreach (string savedRate in rates)
        {
            ExchangeRate rateFromFile= new ExchangeRate();
            ExchangeRatesList.Add(rateFromFile.ExchangeRateFromString(savedRate));
        }
    }

    public void SaveToFile()
    {
        //Convets the Exchange Rates in the list to strings and saves them to the file.
        List<string> ratesToSave = new List<string>();
        foreach (ExchangeRate rate in ExchangeRatesList)
        {
            if (rate.Currency.Length > 0)
            {
                ratesToSave.Add(rate.ExchangeRateToString());
            }
        }
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(ratesToSave);
    }

   
}
