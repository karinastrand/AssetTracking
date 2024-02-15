

using System.ComponentModel.DataAnnotations.Schema;
using System.IO.Enumeration;

namespace AssetTracking;

public class Offices : ILists
{
    public Offices()
    {
       
        
    }
    public string NameOfFile { get; set; } = "offices.txt";


    public List<Office> OfficeList { get; set; }= new List<Office>();

    public void Show()
    {
        WriteLine("Name".PadRight(15)+"Currency");

        foreach (Office office in OfficeList) 
        {
             office.Print();
        }
    

    }
    public void GetFromFile()
    {
        
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
