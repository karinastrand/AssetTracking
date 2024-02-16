namespace AssetTracking;
public class StationaryComputer : Computer
{//Right now nothing more than a copy of the baseclass but prepared for extension
    public string DesktopType { get; set; }
    public StationaryComputer()
    {
    }
    public StationaryComputer(string typeOfAsset, string brand, string modelName, double price, DateTime purchaseDate, Office office) : base(typeOfAsset, brand, modelName, price, purchaseDate, office)
    {
    }
    public StationaryComputer(string desktopType, string typeOfAsset, string brand, string modelName, double price, DateTime purchaseDate, Office office) : base(typeOfAsset, brand, modelName, price, purchaseDate, office)
    {
        DesktopType = DesktopType;
    }
    public void PrintStationaryComputer()
    {
        WriteLine($"Desktop: {Brand}, {ModelName}, type {DesktopType}");
    }
}
