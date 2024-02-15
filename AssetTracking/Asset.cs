
using System.Diagnostics;
using System.Security;
using System.Security.Cryptography.X509Certificates;

namespace AssetTracking;

public abstract class Asset
{
    public Asset()
    {
    }
    public Asset(string typeOfAsset,string brand,string modelName, double price, DateTime purchaseDate, Office office)
    {
        TypeOfAsset=typeOfAsset;
        Brand = brand;
        ModelName = modelName;
        Price = price;
        PurchaseDate = purchaseDate;
        HomeOffice = new Office(office.Name,office.Currancy);
    }

    

    public string TypeOfAsset { get; set; }
    public string Brand { get; set; }
    public string ModelName { get; set; }
    public double Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public Office HomeOffice { get; set; } 

    public void Print()
    {
        try
        {
            Console.WriteLine($"{TypeOfAsset.PadRight(15)}{Brand.PadRight(15)}{ModelName.PadRight(15)}" +
                $"{HomeOffice.Name.PadRight(15)}{DateOnly.FromDateTime(PurchaseDate).ToString().PadRight(15)}" +
                $"{Price.ToString().PadRight(15)}{HomeOffice.Currancy.PadRight(15)}{PriceToLocalPrice().ToString("#.##")}");

        }
        catch (Exception)
        {

            
        }
    }
    public abstract Asset AssetFromString(string stringAsset);
    
    public string AssetToString()
    {
        try
        {
            return $"{TypeOfAsset},{Brand},{ModelName},{Price.ToString()},{PurchaseDate.ToString()},{HomeOffice.Name},{HomeOffice.Currancy}";

        }
        catch (Exception)
        {

            return string.Empty ;
        }
        
    }
    public double PriceToLocalPrice()
    {
        double localPrice = 0;
        string currency = HomeOffice.Currancy;
        ExchangeRates exchangeRates = new ExchangeRates();
        exchangeRates.GetFromFile();
        double rate=exchangeRates.ExchangeRatesList.Where(rates=>rates.Currency == currency).First().Rate;
        try
        {
            localPrice = Price / rate;

        }
        catch (FormatException)
        {

            WriteLine("ExchangeRate was 0");
        }
        return localPrice;
    }
   
}
