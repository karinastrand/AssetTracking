
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
        foreach (Asset asset in AssetsList) 
        {
            asset.Print();
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
