


namespace AssetTracking;

public class Phone : Asset
{
    public Phone()
    {
    }

    public Phone(string typeOfAsset,string brand,string modelName, double price, DateTime purchaseDate, int officeId) : base(typeOfAsset,brand,modelName, price, purchaseDate, officeId)
    {
    }
    public override Asset AssetFromString(string stringAsset)
    {
        string[] assetParts = stringAsset.Split(',');
        Phone savedAsset = new Phone();
        try
        {
            savedAsset = new Phone(assetParts[0], assetParts[1], assetParts[2], Convert.ToDouble(assetParts[3]), Convert.ToDateTime(assetParts[4]), Convert.ToInt32(assetParts[5]));

        }
        catch (IndexOutOfRangeException)
        {

            Console.WriteLine("Couldnt read asset from the file");
        }

        return savedAsset;
    }

    
}
