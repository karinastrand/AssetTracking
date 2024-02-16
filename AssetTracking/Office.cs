namespace AssetTracking;
public class Office
{//Office the assets belongs to
    public string Name { get; set; }
    public string Currancy { get; set; }
    public Office()
    {
    }
    public Office(string name, string currancy)
    {
        Name = name;
        Currancy = currancy;
    }
    public void Print()
    {
        //Prints information of the office to the console
        if (Name.Length > 0)
        {
            WriteLine($"{Name.PadRight(15)}{Currancy}");
        }
    }
    public string OfficeToString()
    {
        //Converts Office to a comma seperated string
        if (Name.Length > 0) 
        {
            return $"{Name},{Currancy}";
        }
        else 
        {
        return string.Empty ;
        }
    }
    
    public Office OfficeFromString(string officeString)
    {
        //Converts a comma seperated string to Office, only works if the string contains at least one comma
        Office savedOffice=new  Office();
        string[] officeParts= officeString.Split(',');
        try
        {
            savedOffice = new Office(officeParts[0], officeParts[1]);
        }
        catch (IndexOutOfRangeException)
        {
            BackgroundColor=ConsoleColor.Red;
            Console.WriteLine("Couldn't convert the string to Office, problem with number of comma seperated parts of the string");
            ResetColor();
        }
        return savedOffice;
    }    
}
