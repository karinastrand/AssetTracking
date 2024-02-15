
using System.Diagnostics;
using System.Xml.Linq;

namespace AssetTracking;

public class UI
{


    public Assets AssetsHandling { get; set; } = new Assets();
    public Offices OfficesHandling { get; set; } = new Offices();

    public void Input()
    {
        OfficesHandling.GetFromFile();
        AssetsHandling.GetFromFile();
        while (true)
        {
            Menu.ShowMenu();
            string input = ReadLine();

            switch (input)
            {
                case "1":
                    {
                        OfficesHandling.Show();
                        break;
                    }
                case "2":
                    {
                        AddNewOffice();
                        break;
                    }
                case "3":
                    {
                        AssetsHandling.Show();
                        break;
                    }
                case "4":
                    {
                        AddNewAsset();
                        break;
                    }
                case "5":
                    {
                        OfficesHandling.SaveToFile();
                        AssetsHandling.SaveToFile();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Write an integer between 1 and 5 or exit");
                        break;
                    }


            }
            if (input == "5")
            {
                break;
            }

        }

    }

    public void AddNewOffice()
    {
        while (true)
        {
            WriteLine("Add new offices, quit with exit");
            Write("Name of the office: ");
            string name = ReadLine();
            if (name.ToLower().Trim() == "exit")
            {
                break;
            }
 
            int id = 1;
            if(OfficesHandling.OfficeList.Count>0 )
            {
                 id=OfficesHandling.OfficeList.Max(offices => offices.Id) + 1;

            }
            Write("Currency (choose between USD,EUR,SEK and JPY) : ");
            string currency = ReadLine();
            currency.ToUpper().Trim();
            if(currency!="USD" && currency != "SEK" && currency != "EUR" && currency != "JPY")
            {

                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have to choose USD, SEK, EUR or JPY");
                ResetColor();
                continue;
            }
                
            OfficesHandling.OfficeList.Add(new Office(id, name,currency));
        }


    }
    public void AddNewAsset()
    {
        while (true)
        {
            WriteLine("Add new assets, quit with exit");
            Write("Type of Asset(Laptop,StationaryComputer or Phone): ");
            string typeOfAsset = ReadLine();
            if (typeOfAsset.ToLower().Trim() == "exit")
            {
                break;
            }
            if((typeOfAsset.ToLower().Trim()!="phone") && (typeOfAsset.ToLower().Trim() != "stationarycomputer") && (typeOfAsset.ToLower().Trim() != "laptop"))
            {
                Console.WriteLine("Type has to be Phone, Stationary or Laptop");
                continue;
            }
            typeOfAsset = char.ToUpper(typeOfAsset[0]) + typeOfAsset.Substring(1);
            Write("Brand: ");
            string brand = ReadLine();
            Write("ModelName: ");
            string modelName = ReadLine();
            
            Write("price (number): ");
            double price = 0;
            string stringPrice = ReadLine();
            try
            {
                price = Convert.ToDouble(stringPrice);
            }
            catch (FormatException)
            {

                Console.WriteLine("The price has to be a number");
                continue;
            }
            Write("PurchaseDate (yyyy-mm-dd): ");
            DateTime date = DateTime.Now;
            string stringDate = ReadLine();
            try
            {
                date=Convert.ToDateTime(stringDate);
            }
            catch (FormatException)
            {
                Console.WriteLine("The date should be written 'yyyy-mm-dd' for example 2024-02-14");
                continue;
            }
            
            OfficesHandling.Show();
            int id = 0;
            Write("Which office does the asset belongs to? Choose one from the list and write it's id");
            string stringId = ReadLine();
            try
            
            {
                id = Convert.ToInt32(stringId);
                bool isInList = OfficesHandling.OfficeList.Exists(office => office.Id == id);
                if (!isInList)
                {
                    Console.WriteLine("There is no office with that id");
                    continue;
                }
            }
            catch (FormatException)
            {

                Console.WriteLine("The officeid has to be an integer and it has to be in the list");
                continue;
            }
            if (typeOfAsset=="Phone")
            {
                
                AssetsHandling.AssetsList.Add(new Phone(typeOfAsset,brand, modelName, price, date, id));
            }
            else if(typeOfAsset == "Laptop")
            {
                AssetsHandling.AssetsList.Add(new Laptop(typeOfAsset,brand, modelName, price, date, id));
            }
            else if(typeOfAsset == "StationaryComputer")
            {
                AssetsHandling.AssetsList.Add(new StationaryComputer(typeOfAsset,brand, modelName, price, date, id));
            }
            

            
        }



    }
}
