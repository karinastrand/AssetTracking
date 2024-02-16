namespace AssetTracking;
public class Menu
{
    //Starting menu
    public static void ShowMenu()
    {
        WriteLine("----------------------");
        WriteLine("Welcome To AssetTracking");
        WriteLine("Choose from the menu (enter an integer from 1 to 7).");
        WriteLine("---------------------");
        WriteLine("1. Show the offices");
        WriteLine("2. Add new offices");
        WriteLine("3. Show assets");
        WriteLine("4. Add new assets");
        WriteLine("5. Show exchange rates");
        WriteLine("6. Add new exchange rates");
        WriteLine("7. Save and quit");
    }
}
