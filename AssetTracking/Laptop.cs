namespace AssetTracking;
public class Laptop : Computer
{//Right now nothing more than a copy of the baseclass but prepared for extension 
    public int Size { get; set; }

    public Laptop()
    {
    }
    public Laptop(string typeOfAsset,string brand, string modelName, double price, DateTime purchaseDate, Office office) : base(typeOfAsset,brand, modelName, price, purchaseDate, office)
    {
    }
    public Laptop(int size, string typeOfAsset, string brand, string modelName, double price, DateTime purchaseDate, Office office) : base(typeOfAsset, brand, modelName, price, purchaseDate, office)
    {
        Size= size;
    }
    public void PrintLaptop()
    {
        WriteLine($"Laptop: {Brand} with {Size} inch screen");
    }
}
