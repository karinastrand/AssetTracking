
using System.Diagnostics;

namespace AssetTracking;

public abstract class Asset
{
    public Asset()
    {
    }
    public Asset(string typeOfAsset,string brand,string modelName, double price, DateTime purchaseDate, int officeId)
    {
        TypeOfAsset=typeOfAsset;
        Brand = brand;
        ModelName = modelName;
        Price = price;
        PurchaseDate = purchaseDate;
        OfficeId = officeId;
    }

    

    public string TypeOfAsset { get; set; }
    public string Brand { get; set; }
    public string ModelName { get; set; }
    public double Price { get; set; }
    public DateTime PurchaseDate { get; set; }
    public int OfficeId { get; set; }  

    public void Print()
    { 
       
        Console.WriteLine($"{TypeOfAsset}\t{ModelName }\t{Price}\t{DateOnly.FromDateTime(PurchaseDate)}\t{OfficeId}");
    }
    public abstract Asset AssetFromString(string stringAsset);
    
    public string AssetToString()
    {
        return $"{TypeOfAsset},{ModelName},{Price.ToString()},{PurchaseDate.ToString()},{OfficeId.ToString()}";
    }

   
}
