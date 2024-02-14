

namespace AssetTracking;

public class Menu
{
    public static void ShowMenu()
    {
        Console.WriteLine("----------------------");
        Console.WriteLine("Welcome To AssetTracking");
        Console.WriteLine("Choose from the menu (enter an integer from 1 to 5).");
        Console.WriteLine("---------------------");
        Console.WriteLine("1. Show the offices");
        Console.WriteLine("2. Add new offices");
        Console.WriteLine("3. Show asserts");
        Console.WriteLine("4. Add new asserts");
        Console.WriteLine("5. Save and quit");
    }
}
