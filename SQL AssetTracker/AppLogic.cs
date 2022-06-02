namespace SQL_AssetTracker
{
    class AppLogic
    {
        // This class contains all the workings of the asset tracking program.
        // My solution to it was to set it up by using 4 methods one of which is called from a diffirent class,
        // And the others in a switch statement. Essential lists, items and variables are declared as early as possible in the class.
        // Because I find it more managable to read and edit it if needed.
        // Everything is being stored and loaded from an SQL database that has to be setup by the user here before using the program.
        // See the Readme.md about setting up for proper database and local SQL connection. 


        // Variables... Variables everywhere...

        // Currency
        static string sek = "SEK";
        static string euro = "EUR";
        static string usd = "USD";

        // Currency exchange rate (by 2022-05-08)
        static double usdSekEx = 9.95;
        static double usdEuroEx = 0.95;

        // Offices variables.
        static string sweden = "Sweden";
        static string france = "France";
        static string germany = "Germany";
        static string finland = "Finland";
        static string spain = "Spain";
        static string usa = "USA";

        // PC brands
        static string apple = "Apple";
        static string lenovo = "Lenovo";
        static string asus = "Asus";

        // Phone brands
        static string applePhone = "Apple";
        static string samsung = "Samsung";
        static string xiaomi = "Xiaomi";

        // Apple Models
        // Laptops:
        static string MBP1 = "MacBook Pro 13-in (2016)";
        static string MBP2 = "MacBook Pro 13-in (2020)";
        static string MBP3 = "MacBook Pro 16-in (2019)";
        // Phones:
        static string IPhone1 = "IPhone 4S";
        static string IPhone2 = "IPhone 5";
        static string IPhone3 = "IPhone 6";

        // Lenovo Models
        static string lenovo1 = "Lenovo IdeaPad Slim 5";
        static string lenovo2 = "Lenovo ThinkPad E15 Gen 2";
        static string lenovo3 = "Lenovo IdeaPad Flex 3i CB";

        // Asus Models
        static string asusPC1 = "A42DE";
        static string asusPC2 = "A42F";
        static string asusPC3 = "A42JA";

        // Samsung Models
        static string samsung1 = "Samsung Galaxy S6";
        static string samsung2 = "Samsung Galaxy S7";
        static string samsung3 = "Samsung Galaxy S8";

        // Xiaomi Models
        static string xiaomi1 = "Redmi 10A";
        static string xiaomi2 = "Redmi Note 10";
        static string xiaomi3 = "Redmi Note 11";

        // Type variables.
        static string pC = "Laptop";
        static string mobilePhone = "Phone";


        public void Start()
        {
            Console.Clear();
            Console.CursorVisible = false;
            // the greeting
            string prompt = @"Welcome to the Asset Tracker program." +
                                "\nPlease select what you wish to do.\n\n";

            string[] options = { "Add an Asset", "Show list of Assets", "About", "Exit" };
            MenuSystem mainMenu = new MenuSystem(prompt, options);
            int selectedIndex = mainMenu.Run();

            switch (selectedIndex)
            {
                case 0:
                    AddAsset();
                    break;
                case 1:
                    ShowList();
                    break;
                case 2:
                    About();
                    break;
                case 3:
                    Environment.Exit(0);
                    break;
            }
        }

        private static void AddAsset()
        {
            Console.Clear();
            while (true)
            {
                // Create the asset object
                AssetTracking asset = new AssetTracking();
                //asset.Type = pC;

                //------------------------------------------------------------------
                // Ask user what type of asset is being added.
                string promptType = @"What type of asset do you wish to add?";
                string[] optionsType = { "Laptop", "Phone" };
                MenuSystem typeMenu = new MenuSystem(promptType, optionsType);
                int selectedIndexType = typeMenu.Run();
                switch (selectedIndexType)
                {
                    case 0:
                        asset.Type = pC;
                        break;
                    case 1:
                        asset.Type = mobilePhone;
                        break;
                }

                //------------------------------------------------------------------
                // Ask user to input purchase date.
                Console.CursorVisible = true;
                DateTime inputDate;
            ERROR1: try
                {
                    Console.WriteLine("Type in a purchase date of the computer asset (yyyy-mm-dd)");
                    inputDate = DateTime.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You have entered the date wrong, please try again. (yyyy-mm-dd)");
                    Console.ResetColor();
                    goto ERROR1;
                }

                asset.PurchaseDate = inputDate;


                //------------------------------------------------------------------
                // Ask the user which office the asset is based in.
                Console.CursorVisible = false;
                string promptOffice = @"Which office is the asset located in? (Country)";
                string[] optionsOffice = { "Sweden", "France", "Germany", "Finland", "Spain", "United States of America" };
                MenuSystem officeMenu = new MenuSystem(promptOffice, optionsOffice);
                int selectedIndexOffice = officeMenu.Run();
                switch (selectedIndexOffice)
                {
                    case 0:
                        asset.Office = sweden;
                        break;
                    case 1:
                        asset.Office = france;
                        break;
                    case 2:
                        asset.Office = germany;
                        break;
                    case 3:
                        asset.Office = finland;
                        break;
                    case 4:
                        asset.Office = spain;
                        break;
                    case 5:
                        asset.Office = usa;
                        break;
                }

                //------------------------------------------------------------------
                // Ask the user for brand depending if the asset is a computer or a phone.
                if (asset.Type == pC)
                {
                    string promptBrand = @"Select the brand of the computer asset.";
                    string[] optionsBrand = { "Apple", "Lenovo", "Asus" };
                    MenuSystem brandMenu = new MenuSystem(promptBrand, optionsBrand);
                    int selectedIndexBrand = brandMenu.Run();
                    switch (selectedIndexBrand)
                    {
                        // This is a long switch :D
                        // I <3 Switch :D
                        case 0:
                            asset.Brand = apple;
                            asset.PhoneModel = "N/A";
                            break;
                        case 1:
                            asset.Brand = lenovo;
                            asset.PhoneModel = "N/A";
                            break;
                        case 2:
                            asset.Brand = asus;
                            asset.PhoneModel = "N/A";
                            break;
                    }
                }
                else if (asset.Type == mobilePhone)
                {
                    string promptBrand = @"Select the brand of the phone asset.";
                    string[] optionsBrand = { "Apple", "Samsung", "Xiaomi" };
                    MenuSystem brandMenu = new MenuSystem(promptBrand, optionsBrand);
                    int selectedIndexBrand = brandMenu.Run();
                    switch (selectedIndexBrand)
                    {
                        // I <3 Switch :D
                        case 0:
                            asset.Brand = applePhone;
                            asset.LaptopModel = "N/A";
                            break;
                        case 1:
                            asset.Brand = samsung;
                            asset.LaptopModel = "N/A";
                            break;
                        case 2:
                            asset.Brand = xiaomi;
                            asset.LaptopModel = "N/A";
                            break;
                    }
                }

                //------------------------------------------------------------------
                // Ask the user for the model depending if the asset is a computer or a phone.
                // There will be tons of switches here...
                if (asset.Type == pC)
                {
                    if (asset.Brand == apple)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { MBP1, MBP2, MBP3 };
                        MenuSystem modelMenu = new MenuSystem(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0:
                                asset.LaptopModel = MBP1;
                                break;
                            case 1:
                                asset.LaptopModel = MBP2;
                                break;
                            case 3:
                                asset.LaptopModel = MBP3;
                                break;
                        }
                    }
                    else if (asset.Brand == lenovo)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { lenovo1, lenovo2, lenovo3 };
                        MenuSystem modelMenu = new MenuSystem(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0:
                                asset.LaptopModel = lenovo1;
                                break;
                            case 1:
                                asset.LaptopModel = lenovo2;
                                break;
                            case 3:
                                asset.LaptopModel = lenovo3;
                                break;
                        }
                    }
                    else if (asset.Brand == asus)
                    {
                        string promptModel = @"Select the model of the computer asset.";
                        string[] optionsModel = { asusPC1, asusPC2, asusPC3 };
                        MenuSystem modelMenu = new MenuSystem(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0:
                                asset.LaptopModel = asusPC1;
                                break;
                            case 1:
                                asset.LaptopModel = asusPC2;
                                break;
                            case 3:
                                asset.LaptopModel = asusPC3;
                                break;
                        }
                    }
                }
                else if (asset.Type == mobilePhone)
                {
                    if (asset.Brand == applePhone)
                    {
                        string promptModel = @"Select the model of the phone asset.";
                        string[] optionsModel = { IPhone1, IPhone2, IPhone3 };
                        MenuSystem modelMenu = new MenuSystem(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0:
                                asset.PhoneModel = IPhone1;
                                break;
                            case 1:
                                asset.PhoneModel = IPhone2;
                                break;
                            case 3:
                                asset.PhoneModel = IPhone3;
                                break;
                        }
                    }
                    else if (asset.Brand == samsung)
                    {
                        string promptModel = @"Select the model of the phone asset.";
                        string[] optionsModel = { samsung1, samsung2, samsung3 };
                        MenuSystem modelMenu = new MenuSystem(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0:
                                asset.PhoneModel = samsung1;
                                break;
                            case 1:
                                asset.PhoneModel = samsung2;
                                break;
                            case 3:
                                asset.PhoneModel = samsung3;
                                break;
                        }
                    }
                    else if (asset.Brand == xiaomi)
                    {
                        string promptModel = @"Select the model of the phone asset.";
                        string[] optionsModel = { xiaomi1, xiaomi2, xiaomi3 };
                        MenuSystem modelMenu = new MenuSystem(promptModel, optionsModel);
                        int selectedIndexModel = modelMenu.Run();
                        switch (selectedIndexModel)
                        {
                            case 0:
                                asset.PhoneModel = xiaomi1;
                                break;
                            case 1:
                                asset.PhoneModel = xiaomi2;
                                break;
                            case 3:
                                asset.PhoneModel = xiaomi3;
                                break;
                        }
                    }
                }
                //------------------------------------------------------------------
                // Change this so the user is not asked but rather the program detects at which country the asset is bought.
                // And then sets the what type of currency was used on its own.
                // It also tells the user in which currency it is supposed to be written in.

                // For Euro
                if (asset.Office == france || asset.Office == germany || asset.Office == finland || asset.Office == spain)
                {
                    asset.Currency = euro;
                }
                // For SEK
                else if (asset.Office == sweden)
                {
                    asset.Currency = sek;
                }
                // For USD
                else if (asset.Office == usa)
                {
                    asset.Currency = usd;
                }

                //------------------------------------------------------------------
                // Ask the user for the price depending on the selected country (do it in double)

                // For Euro
                if (asset.Office == france || asset.Office == germany || asset.Office == finland || asset.Office == spain)
                {
                    Console.WriteLine("What was the price of the asset in Euros?");
                }
                // For SEK
                else if (asset.Office == sweden)
                {
                    Console.WriteLine("What was the price of the asset in Swedish Krona?");
                }
                // For USD
                else if (asset.Office == usa)
                {
                    Console.WriteLine("What was the price of the asset in US Dollars?");
                }


                string inputPrice = Console.ReadLine();
                double dblAssetPrice = Convert.ToDouble(inputPrice);

                // Put the integer into the 'asset' object.
                // And add the local price which does not use exchange rate.
                asset.LocalPrice = dblAssetPrice;
                asset.Price = dblAssetPrice;

                // Setup the exchange rate to USD
                if (asset.Currency == sek)
                {
                    asset.Price /= usdSekEx;
                }
                else if (asset.Currency == euro)
                {
                    asset.Price /= usdEuroEx;
                }

                //------------------------------------------------------------------
                // Put the object into the list.

                App.Context.Assets.Add(asset);
                App.Context.SaveChanges();

                // Ask user if user wish to add another asset.
                Console.WriteLine("Do you wish to add another computer asset? Y/N");
                if (Console.ReadLine().ToLower().Trim() == "n")
                {
                    AppLogic start = new AppLogic();
                    start.Start();
                    break;
                }
                else if (Console.ReadLine().ToLower().Trim() == "y")
                {
                    AddAsset();
                    break;
                }
            }
        }

        private static void About()
        {
            Console.Clear();
            Console.CursorVisible = false;
            Console.WriteLine("This program tracks assets for a company using SQL Database to store data.");
            Console.WriteLine("It was written in educational purposes and I learned a great deal in the process");
            Console.WriteLine("Also I learned that I'm very fond of switches in C# :D");
            Console.WriteLine("Enjoy the program :D");
            Console.WriteLine("Written by Karl Christian Karlsson Korbacz");
            Console.WriteLine("2022-05-08");
            Console.WriteLine();
            Console.WriteLine("Press 'R' and enter to return to the main menu...");
            if (Console.ReadLine().ToLower().Trim() == "r")
            {
                AppLogic start = new AppLogic();
                start.Start();
            }
        }


        // This method is called when to show the list of added items.
        private static void ShowList()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.WriteLine("Assets:\n");
            Console.WriteLine("Type:".PadRight(25) + "Brand:".PadRight(25) + "Model:".PadRight(35) + "Purchase Date:".PadRight(25) + "Office:".PadRight(25) + "Price(USD):".PadRight(25) + "Purchase Currency:".PadRight(25) + "Local Price:".PadRight(25));
            Console.WriteLine("-----".PadRight(25) + "------".PadRight(25) + "------".PadRight(35) + "--------------".PadRight(25) + "-------".PadRight(25) + "-----------".PadRight(25) + "------------------".PadRight(25) + "------------".PadRight(25));
            Console.WriteLine();

            // This sorts it first by office then by purchase date.
            App.assets = App.assets.OrderBy(asset => asset.Office).ThenBy(asset => asset.PurchaseDate).ToList();

            foreach (AssetTracking asset in App.assets)
            {
                //Check the date of purchase and color the element in list accordingly.
                if (asset.PurchaseDate < DateTime.Parse("2019-01-01") && asset.PurchaseDate > DateTime.Parse("2016-01-01"))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                }
                else if (asset.PurchaseDate < DateTime.Parse("2016-01-01"))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ResetColor();
                }

                if (asset.Type == pC)
                {
                    Console.WriteLine(asset.Type.PadRight(25) + asset.Brand.PadRight(25) + asset.LaptopModel.PadRight(35) + asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(25) + asset.Office.PadRight(25) + asset.Price.ToString("0.00").PadRight(25) + asset.Currency.PadRight(25) + asset.LocalPrice.ToString("0.00").PadRight(25));
                }
                if (asset.Type == mobilePhone)
                {
                    Console.WriteLine(asset.Type.PadRight(25) + asset.Brand.PadRight(25) + asset.PhoneModel.PadRight(35) + asset.PurchaseDate.ToString("yyyy-MM-dd").PadRight(25) + asset.Office.PadRight(25) + asset.Price.ToString("0.00").PadRight(25) + asset.Currency.PadRight(25) + asset.LocalPrice.ToString("0.00").PadRight(25));
                }
                Console.ResetColor();

            }
            Console.WriteLine("¤===================================================================================================================================================================================================¤");
            Console.WriteLine();
            Console.WriteLine("\nReturn to main menu? Y = yes, N = exit program");
            if (Console.ReadLine().ToLower().Trim() == "y")
            {
                AppLogic start = new AppLogic();
                start.Start();
            }
            else if (Console.ReadLine().ToLower().Trim() == "n")
            {
                Environment.Exit(0);
            }
        }

    }
}
