

using System.Xml.Linq;

namespace AssetTracking;

public class Office
{
    public Office()
    {
    }
    
    public Office(string name, string currancy)
    {
      
        Name = name;
        Currancy = currancy;
    }


    public string Name { get; set; }
  
   
    public string Currancy {  get; set; }

    public string OfficeToString()
    {
        if (Name.Length > 0) 
        {
            return $"{Name},{Currancy}";

        }
        else 
        {
        return string.Empty ;
        }
    }
    public void Print()
    {
        if (Name.Length > 0) 
        {
            Console.WriteLine($"{Name.PadRight(15)}{Currancy}");

        }
    }
    public Office OfficeFromString(string officeString)
    {
        Office savedOffice=new  Office();
        string[] officeParts= officeString.Split(',');
        try
        {
            savedOffice = new Office(officeParts[0], officeParts[1]);

        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Couldnt read from file");
            
        }
        return savedOffice;

    }
   
}
