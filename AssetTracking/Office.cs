

using System.Xml.Linq;

namespace AssetTracking;

public class Office
{
    public Office()
    {
    }
    public Office(string name,string currancy)
    {
        Name = name;
        Currancy = currancy;
    }
    public Office(int id,string name, string currancy)
    {
        Id = id;
        Name = name;
        Currancy = currancy;
    }


    public string Name { get; set; }
  
    public int Id {  get; set; }
    public string Currancy {  get; set; }

    public string OfficeToString()
    {
        if (Id > 0) 
        {
            return $"{Id.ToString()},{Name},{Currancy}";

        }
        else 
        {
        return string.Empty ;
        }
    }
    public void Print()
    {
        if (Id > 0) 
        {
            Console.WriteLine($"{Id.ToString().PadRight(10)}{Name.PadRight(10)}{Currancy}");

        }
    }
    public Office OfficeFromString(string officeString)
    {
        Office savedOffice=new  Office();
        string[] officeParts= officeString.Split(',');
        try
        {
            savedOffice = new Office(Convert.ToInt32(officeParts[0]), officeParts[1], officeParts[2]);

        }
        catch (IndexOutOfRangeException)
        {
            Console.WriteLine("Couldnt read from file");
            
        }
        return savedOffice;

    }
   
}
