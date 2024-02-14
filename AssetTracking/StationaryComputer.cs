

namespace AssetTracking;

public class StationaryComputer : Computer
{
    public StationaryComputer()
    {
    }

    public StationaryComputer(string typeOfAsset,string brand, string modelName, double price, DateTime purchaseDate, int officeId) : base(typeOfAsset,brand, modelName, price, purchaseDate, officeId)
    {
    }
    public override Asset AssetFromString(string stringAsset)
    {
        string[] assetParts = stringAsset.Split(',');

        StationaryComputer savedAsset = new StationaryComputer(assetParts[0],assetParts[1],assetParts[2], Convert.ToDouble(assetParts[3]), Convert.ToDateTime(assetParts[4]), Convert.ToInt32(assetParts[5]));
        return savedAsset;
    }
}
