namespace AssetTracking;
public class Phone : Asset
{//Assets of type Phone
    public Phone()
    {
    }
    public Phone(string typeOfAsset,string brand,string modelName, double price, DateTime purchaseDate, Office assetOffice) : base(typeOfAsset,brand,modelName, price, purchaseDate, assetOffice)
    {
    }
    public override Asset AssetFromString(string stringAsset)
    {
        /*Converts a string to Phone object, if the string with the different fields seperated with ",". If the string 
        doesn't contain 6 parts or if some part can't be converted to the type the constructor needs the conversion fails.*/
        string[] assetParts = stringAsset.Split(',');
        Phone savedAsset = new Phone();
        try
        {
            savedAsset = new Phone(assetParts[0], assetParts[1], assetParts[2], Convert.ToDouble(assetParts[3]), Convert.ToDateTime(assetParts[4]), new Office(assetParts[5], assetParts[6]));
        }
        catch (IndexOutOfRangeException)
        {
            ForegroundColor = ConsoleColor.Red;
            WriteLine($"Couldn't convert string to {TypeOfAsset}, problems with number of comma seperated parts of the string");
            ResetColor();
        }
        catch (FormatException)
        {
            WriteLine($"Couldn't convert string to {TypeOfAsset},problems with format");
        }
        return savedAsset;
    }
    
}
