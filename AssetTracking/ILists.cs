
namespace AssetTracking;

public interface ILists
{
    public string NameOfFile { get; set; }
    public void GetFromFile();

    public void SaveToFile();

    public void Show();
}
