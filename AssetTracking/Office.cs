

namespace AssetTracking;

public class Office
{
    public Office()
    {
    }
    public Office(string name, string country)
    {
        Name = name;
        Country = country;
    }
    public Office(int id,string name, string country)
    {
        Id = id;
        Name = name;
        Country = country;
    }


    public string Name { get; set; }
    public string Country { get; set; }
    public int Id {  get; set; }

    public string OfficeToString()
    {
        return $"{Id.ToString()},{Name},{Country}";
    }
    public void Print()
    {
        Console.WriteLine($"{Id}\t{Name}\t{Country}");
    }
    public Office OfficeFromString(string officeString)
    {
        string[] officeParts= officeString.Split(',');
        Office savedOffice=new Office(Convert.ToInt32(officeParts[0]), officeParts[1], officeParts[2]);
        return savedOffice;

    }
   
}
