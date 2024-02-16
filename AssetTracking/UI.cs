namespace AssetTracking;
public class UI
{
    //The user interface of the program
    public Assets AssetsHandling { get; set; } = new Assets();
    public Offices OfficesHandling { get; set; } = new Offices();
    public ExchangeRates ExchangeRatesHandling { get; set; }=new ExchangeRates();

    public void Input()
    {
        //Offices, assets and exchangerates will be fetched from their files.
        OfficesHandling.GetFromFile();
        AssetsHandling.GetFromFile();
        ExchangeRatesHandling.GetFromFile();
        while (true)
        {
            //Shows the menu and takes care of the users input, will continue until the user inputs 7 for save and exit.
            Menu.ShowMenu();
            string input = ReadLine();
            switch (input)
            {
                case "1":
                    {
                        OfficesHandling.Show();//Shows the list of offices
                        break;
                    }
                case "2":
                    {
                        AddNewOffice();//Adds new offices
                        break;
                    }
                case "3":
                    {
                        AssetsHandling.Show();//Shows the list of assets
                        break;
                    }
                case "4":
                    {
                        AddNewAsset();//Adds new assets
                        break;
                    }
                case "5":
                    {
                        ExchangeRatesHandling.Show();//Shows the list of exchangerates
                        break;
                    }
                case "6":
                    {
                        AddNewExchangeRate();//Adds new exchangerates
                        break;
                    }
                case "7":
                    {
                        //Saves the tree listes to files
                        OfficesHandling.SaveToFile();
                        AssetsHandling.SaveToFile();
                        ExchangeRatesHandling.SaveToFile();
                        break;
                    }
                default:
                    {
                        //If the user has written something else than the menuchoices
                        ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Write an integer between 1 and 7");
                        ResetColor();
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
        //Adds new Office objects until the user writes exit
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
            //Shows the list of exchange rates, the user has to choose one of them or go back to the menu and add a new one 
            Write("Currency (choose from the list above) :");
            string currency = ReadLine();
            currency.ToUpper().Trim();
            //Cheeks if the currency is in the list of exchange rates
            bool isInList = ExchangeRatesHandling.ExchangeRatesList.Exists(rate => rate.Currency == currency);
            if (!isInList)
            {
                //The currency was not in the list so the user has to restart to add the office with a correct currency or leave and add it first.
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("There is no such currency in the list, you can add it if you return to the menu and chooses 6, 'Add new exchange rates'.");
                ResetColor();
                continue;
            }
            OfficesHandling.OfficeList.Add(new Office(name,currency));
            ForegroundColor=ConsoleColor.Green;
            WriteLine("The office was successfully added");
            ResetColor();
        }
    }
    public void AddNewAsset()
    {
        //Adds new assets until the user writes exit
        while (true)
        {
            WriteLine("Add new assets, quit with exit");
            //The asset has to be one of these:"
            Write("Type of Asset(Computer, Laptop, StationaryComputer or Phone): ");
            string typeOfAsset = ReadLine();
            typeOfAsset = typeOfAsset.ToLower().Trim();
            if (typeOfAsset == "exit")
            {
                break;
            }
            if((typeOfAsset!="phone") &&  (typeOfAsset != "computer")&& (typeOfAsset != "stationarycomputer") && (typeOfAsset != "laptop"))
            {
                Console.WriteLine("Type has to be Phone,Computer, StationaryComputer or Laptop");
                continue;
            }
            //Sets the first letter to capital
            typeOfAsset = char.ToUpper(typeOfAsset[0]) + typeOfAsset.Substring(1);
            Write("Brand: ");
            string brand = ReadLine();
            Write("ModelName: ");
            string modelName = ReadLine();
            //the price has to be a number
            Write("price (number): ");
            double price = 0;
            string stringPrice = ReadLine();
            try
            {
                price = Convert.ToDouble(stringPrice);
            }
            catch (FormatException)
            {
                //if the stringPrice can't be converted to a double the user has to restart the input of a new asset
                ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("The price has to be a number");
                ResetColor();
                continue;
            }
            //PurchaseDate has to be a date
            Write("PurchaseDate (yyyy-mm-dd): ");
            DateTime date = DateTime.Now;
            string stringDate = ReadLine();
            try
            {
                date=Convert.ToDateTime(stringDate);
            }
            catch (FormatException)
            {
                //if the stringDate can't be converted to DateTime the user has to restart the input of a new asset
                ForegroundColor = ConsoleColor.Red;
                WriteLine("The date should be written 'yyyy-mm-dd' for example 2024-02-27");
                ResetColor();
                continue;
            }
            //Shows the list of offices, the user has to choose one from the list or go back to the menu and add a new office.
            OfficesHandling.Show();
            Write("Which office does the asset belongs to? (Choose one from the list and write it's name): ");
            string name = ReadLine();
            //Checks if the office is in the list
            bool isInList = OfficesHandling.OfficeList.Exists(office => office.Name == name);
            if (!isInList)
            {
                //The office was not in the list so the user has to restart the input with a correct office or leave and add it first.
                Console.WriteLine("There is no office with that name");
                continue;
            }
            //Fetches the Office object from the list of Offices.
            Office assetOffice= OfficesHandling.OfficeList.Where(office=>office.Name==name).FirstOrDefault();
            //Creats an assetobject of the correct subclass and adds it to the list of assets.
            if (typeOfAsset=="Phone")
            {
                AssetsHandling.AssetsList.Add(new Phone(typeOfAsset,brand, modelName, price, date, assetOffice));
            }
            else if (typeOfAsset == "Computer")
            {
                AssetsHandling.AssetsList.Add(new Computer(typeOfAsset, brand, modelName, price, date, assetOffice));
            }
            else if(typeOfAsset == "Laptop")
            {
                AssetsHandling.AssetsList.Add(new Laptop(typeOfAsset,brand, modelName, price, date, assetOffice));
            }
            else if(typeOfAsset == "StationaryComputer")
            {
                AssetsHandling.AssetsList.Add(new StationaryComputer(typeOfAsset,brand, modelName, price, date, assetOffice));
            }
            ForegroundColor = ConsoleColor.Green;
            WriteLine($"The {typeOfAsset} was successfully added.");
            ResetColor();
        }
    }
    public void AddNewExchangeRate()
    {
        //Adds a new exchange rate,continues until the user writes exit
        while (true)
        {
            WriteLine("Add new exchangerate, quit with exit");
            Write("Currency: ");
            string currency = ReadLine();
            if (currency.ToLower().Trim() == "exit")
            {
                //Saves the new ExchangeRates before leaving so they can be used directly.
                ExchangeRatesHandling.SaveToFile();
                break;
            }
            //The exchange rate has to be a number
            Write("Exchanger rate (a number) : ");
            double rate = 0;
            string stringRate = ReadLine();
            try
            {
                rate=Convert.ToDouble(stringRate);
            }
            catch (FormatException)
            {
                //It was not possible to convert stringRate to double so the user has to restart the input
                ForegroundColor=ConsoleColor.Red;
                Console.WriteLine("Exchange rate has to be a number");
                ResetColor();
                continue;
            }
            ExchangeRatesHandling.ExchangeRatesList.Add(new ExchangeRate(currency,rate));
            ForegroundColor= ConsoleColor.Green;
            WriteLine("The exchange rate was successfully added");
            ResetColor();
        }
    }
}
