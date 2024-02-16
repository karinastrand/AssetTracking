namespace AssetTracking;
public class Assets:ILists
{
    //Contains a list of assets and the Name of file they are stored in.
    public List<Asset> AssetsList { get; set; }=new List<Asset>();
    public string NameOfFile { get; set; } = "assets.txt";

    public void Show()
    {
        //Prints assetlist sorted after office first and then purchase date on the console.
        List<Asset> sortedAssets = AssetsList.OrderBy(asset=>asset.HomeOffice.Name).ThenBy(asset=>asset.PurchaseDate).ToList();
        WriteLine("Type".PadRight(15)+"Brand".PadRight(15) + "Model".PadRight(15)  + "Office".PadRight(15)+
            "Purchase Date".PadRight(15)+"Price in USD".PadRight(15)+"Currency".PadRight(15)+"Local Price");
        //The asset will be too old after three year, the asset gets a red color if it is 33 months old and a yellow color if it is's age is <30 and>33 months as a warning.
        foreach (Asset asset in sortedAssets) 
        {
            if(Functions.isOlderThanXMonthsfromNow(asset.PurchaseDate,33)) 
            {
                ForegroundColor= ConsoleColor.Red;
            }
            else if (Functions.isOlderThanXMonthsfromNow(asset.PurchaseDate,30))
            {
                ForegroundColor= ConsoleColor.Yellow;
            }
            else 
            {
                ResetColor();
            }
            asset.Print();
            ResetColor();
        }
    }
    public void GetFromFile() 
     //Fetches Asset object from the file and converts the strings to an object of the subclass it belongs to. 
    {
        FileHandling fileHandling = new FileHandling(NameOfFile);
        List<string> assetStrings = fileHandling.ReadFromFile();
        foreach(string assetString in assetStrings)
        {
            try
            {
                string typeOfAsset = assetString.Split(',')[0];
                if (typeOfAsset == "Phone")
                {
                    Phone savedAsset = new Phone();
                    AssetsList.Add(savedAsset.AssetFromString(assetString));
                }
                else if (typeOfAsset == "Computer")
                {
                    Computer savedAsset = new Computer();
                    AssetsList.Add(savedAsset.AssetFromString(assetString));
                }
                else if (typeOfAsset == "Laptop")
                {
                    Laptop savedAsset = new Laptop();
                    AssetsList.Add(savedAsset.AssetFromString(assetString));
                }
                else if(typeOfAsset =="StationaryComputer")
                {
                    StationaryComputer savedAsset = new StationaryComputer();
                    AssetsList.Add(savedAsset.AssetFromString(assetString));
                }
                else 
                {
                    ForegroundColor = ConsoleColor.Red;
                    WriteLine("The asset is not of the correct type and will be ignored" );
                    ResetColor();
                }
            }
            catch (Exception e)
            {
                ForegroundColor = ConsoleColor.Red;
                WriteLine(e);
                ResetColor();
            }
        }
    }
 
    public void SaveToFile() 
    //Converts the Asset Objects to a list of strings and saves the string list to the file.
    {
        List<string> assetsToSave = new List<string>();
        foreach (Asset asset in AssetsList)
        {
            assetsToSave.Add(asset.AssetToString());
        }
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(assetsToSave);
    }
}
