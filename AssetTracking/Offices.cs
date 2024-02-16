namespace AssetTracking;
public class Offices : ILists
{//Represents a list of Office objects and the name of the file they are stored in.

    public string NameOfFile { get; set; } = "offices.txt";
    public List<Office> OfficeList { get; set; } = new List<Office>();
    public Offices()
    {
    }
    public void Show()
    {
        //Prints the list of Offices on the console.
        WriteLine("Name".PadRight(15)+"Currency");
        foreach (Office office in OfficeList) 
        {
             office.Print();
        }
    }
    public void GetFromFile()
    {
        //Fetches strings from the file of stored offices and convert the strings to Office objects.
        FileHandling fileHandling = new FileHandling(NameOfFile);
        List<string> savedOffices = fileHandling.ReadFromFile();
        foreach (string officeString in savedOffices) 
        {
            Office savedOffice =new Office();
            OfficeList.Add(savedOffice.OfficeFromString(officeString));
        }
    }
    public void SaveToFile()
    {
        //Converts the Offices in the list to strings, adds them to a list of strings and writes them to the file.
        List<string> officeToSave = new List<string>();
        foreach (Office office in OfficeList)
        {
            if (office.Name.Length>0) 
            {
                officeToSave.Add(office.OfficeToString()); 
            }
        }
        FileHandling fileHandling = new FileHandling(NameOfFile);
        fileHandling.SaveToFile(officeToSave);
    }
}
