
using System.Diagnostics;
using System.Xml.Linq;

namespace AssetTracking;

public class UI
{


    public Assets AssetsHandling { get; set; } = new Assets();
    public Offices OfficesHandling { get; set; } = new Offices();
    public ExchangeRates ExchangeRatesHandling { get; set; }=new ExchangeRates();

    public void Input()
    {
        OfficesHandling.GetFromFile();
        AssetsHandling.GetFromFile();
        ExchangeRatesHandling.GetFromFile();
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
                        ExchangeRatesHandling.Show();
                        break;
                    }
                case "6":
                    {
                        AddNewExchangeRate();
                        break;
                    }
                case "7":
                    {
                        OfficesHandling.SaveToFile();
                        AssetsHandling.SaveToFile();
                        ExchangeRatesHandling.SaveToFile();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Write an integer between 1 and 7");
                        break;
                    }


            }
            if (input == "7")
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
            ExchangeRatesHandling.Show();
            Write("Currency (choose from the list above) : ");
            string currency = ReadLine();
            currency.ToUpper().Trim();
            bool isInList = ExchangeRatesHandling.ExchangeRatesList.Exists(rate => rate.Currency == currency);
            if (!isInList)
            {
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such currency in the list");
                ResetColor();
                continue;
            }
            
                
            OfficesHandling.OfficeList.Add(new Office(name,currency));
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
            
            Write("Which office does the asset belongs to? (Choose one from the list and write it's name): ");
            string name = ReadLine();
          
            bool isInList = OfficesHandling.OfficeList.Exists(office => office.Name == name);
            if (!isInList)
            {
                Console.WriteLine("There is no office with that name");
                continue;
            }
            
            Office assetOffice= OfficesHandling.OfficeList.Where(office=>office.Name==name).FirstOrDefault();
           
           

            if (typeOfAsset=="Phone")
            {
                
                AssetsHandling.AssetsList.Add(new Phone(typeOfAsset,brand, modelName, price, date, assetOffice));
            }
            else if(typeOfAsset == "Laptop")
            {
                AssetsHandling.AssetsList.Add(new Laptop(typeOfAsset,brand, modelName, price, date, assetOffice));
            }
            else if(typeOfAsset == "StationaryComputer")
            {
                AssetsHandling.AssetsList.Add(new StationaryComputer(typeOfAsset,brand, modelName, price, date, assetOffice));
            }
            

            
        }



    }
    public void AddNewExchangeRate()
    {
        while (true)
        {
            WriteLine("Add new exchangerate, quit with exit");
            Write("Currency: ");
            string currency = ReadLine();
            if (currency.ToLower().Trim() == "exit")
            {
                ExchangeRatesHandling.SaveToFile();
                break;
            }

            Write("ExchangeRate (a number) : ");
            double rate = 0;
            string stringRate = ReadLine();
            try
            {
                rate=Convert.ToDouble(stringRate);
            }
            catch (FormatException)
            {
                ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("Rate has to be a number");
                ResetColor();
                continue;
            }

            ExchangeRatesHandling.ExchangeRatesList.Add(new ExchangeRate(currency,rate));
        }


    }
}
