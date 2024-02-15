namespace AssetTracking;

public class ExchangeRates : ILists
{
    

    public string NameOfFile { get; set; } = "exchangerates.txt";
    public List<ExchangeRate> ExchangeRatesList { get; set; }=new List<ExchangeRate>();
    public void GetFromFile()
    {
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

    public void Show()
    {
        WriteLine("Currency".PadRight(15)+"ExchangeRate".PadRight(15));
        foreach (ExchangeRate rate in ExchangeRatesList)
        {
            rate.Print();
        }
    }
}
