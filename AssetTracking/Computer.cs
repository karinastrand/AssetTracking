


using System.Runtime.CompilerServices;

namespace AssetTracking;

public class Computer : Asset
{
    public Computer()
    {
    }

    public Computer(string typeOfAsset,string brand, string modelName, double price, DateTime purchaseDate, Office office) : base(typeOfAsset,brand, modelName, price, purchaseDate, office)
    {
    }

    public override Asset AssetFromString(string stringAsset)
    {
        string[] assetParts = stringAsset.Split(',');

        Computer savedAsset = new Computer();
        try
        {
            savedAsset = new Computer(assetParts[0], assetParts[1], assetParts[2], Convert.ToDouble(assetParts[3]), Convert.ToDateTime(assetParts[4]), new Office(assetParts[5], assetParts[6]));

        }
        catch (IndexOutOfRangeException)
        {

            Console.WriteLine("Couldnt read asset from the file");
        }
        
        return savedAsset;
    }
}
