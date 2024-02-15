
namespace AssetTracking;

public class Assets:ILists
{
    public Assets()
    {
        
        
    }

    public List<Asset> AssetsList { get; set; }=new List<Asset>();
    public string NameOfFile { get; set; } = "assets.txt";

    public void Show()
    {
        List<Asset> sortedAssets = AssetsList.OrderBy(asset=>asset.HomeOffice.Name).ThenBy(asset=>asset.PurchaseDate).ToList();
        WriteLine("Type".PadRight(15)+"Brand".PadRight(15) + "Model".PadRight(15)  + "Office".PadRight(15)+
            "Purchase Date".PadRight(15)+"Price in USD".PadRight(15)+"Currency".PadRight(15)+"Local Price");
        foreach (Asset asset in sortedAssets) 
        {
            if(Functions.expirationDateWarning(asset.PurchaseDate,33)) 
            {
                ForegroundColor= ConsoleColor.Red;
            }
            else if (Functions.expirationDateWarning(asset.PurchaseDate,30))
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
    {
        FileHandling fileHandling = new FileHandling(NameOfFile);
        List<string> assetStrings = fileHandling.ReadFromFile();
        foreach(string assetString in assetStrings)
        {
            string typeOfAsset = assetString.Split(',')[0];
            if (typeOfAsset== "Phone")
            {
                Phone savedAsset = new Phone();
                AssetsList.Add(savedAsset.AssetFromString(assetString));
            }
            else if (typeOfAsset=="Laptop")
            {
                Laptop savedAsset= new Laptop();    
                AssetsList.Add(savedAsset.AssetFromString(assetString));
            }
            else
            {
                StationaryComputer savedAsset= new StationaryComputer();
                AssetsList.Add(savedAsset.AssetFromString(assetString));
            }
          
            
        }
        
    }

 
    public void SaveToFile()
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
