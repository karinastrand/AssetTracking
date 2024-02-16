namespace AssetTracking;

public abstract class Asset
{
    //Baseclass for the different assets
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
        //Prints the asset on the console
        try
        {
            Console.WriteLine($"{TypeOfAsset.PadRight(15)}{Brand.PadRight(15)}{ModelName.PadRight(15)}" +
                $"{HomeOffice.Name.PadRight(15)}{DateOnly.FromDateTime(PurchaseDate).ToString().PadRight(15)}" +
                $"{Price.ToString().PadRight(15)}{HomeOffice.Currancy.PadRight(15)}{Functions.PriceToLocalPrice(HomeOffice.Currancy,Price).ToString("#.##")}");

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }
    public abstract Asset AssetFromString(string stringAsset); //Have to be implemented in the subclasses, needs to create an Assetobject
    
    public string AssetToString()
    {
        //Converts asset to a string
        try
        {
            return $"{TypeOfAsset},{Brand},{ModelName},{Price.ToString()},{PurchaseDate.ToString()},{HomeOffice.Name},{HomeOffice.Currancy}";
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return string.Empty ;
        }        
    }    
}
