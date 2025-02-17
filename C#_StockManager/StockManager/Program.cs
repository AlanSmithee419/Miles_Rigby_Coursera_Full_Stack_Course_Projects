using System;
using System.Collections.Generic;

namespace StockManager
{
    class Program
    {
        static void Main(string[] args)
        {
            // Initialise stock lists
            List<string> stockItems = new List<string>();
            List<double> stockPrices = new List<double>();
            List<int> stockAmounts = new List<int>();

            // Initialise menu to main menu
            string currentMenu = "Main";

            // Main loop
            while (true){

                switch (currentMenu){

                    // Prompt the user to select an option from the main menu
                    case "Main": MainMenu(ref currentMenu); break;

                    // Display all stock items, set menu back to main menu
                    case "Display stock": DisplayStock(stockItems, stockPrices, stockAmounts); currentMenu = "Main"; break;

                    // Add an item to the stock list
                    case "Add item": AddItem(stockItems, stockPrices, stockAmounts, ref currentMenu); break;

                    // Remove an item from the stock list
                    case "Remove item": RemoveItem(stockItems, stockPrices, stockAmounts, ref currentMenu); break;

                    // Provide the current price of an item
                    case "Lookup price": LookupItemInfo("Price", stockItems, stockPrices, stockAmounts, ref currentMenu); break;

                    // Provide the current stock level of an item
                    case "Lookup stock": LookupItemInfo("Stock", stockItems, stockPrices, stockAmounts, ref currentMenu); break;

                    // Change the price of an item
                    case "Update price": UpdateItemPrice(stockItems, stockPrices, ref currentMenu); break;

                    // Update stock level of an item
                    case "Update stock": UpdateItemStock(stockItems, stockAmounts, ref currentMenu); break;

                    // Handle user choosing to exit the program
                    case "Exit": Console.WriteLine("Exiting program."); return;

                    // Default case to handle invalid menu states for debugging
                    default: Console.WriteLine("ERROR: Invalid menu, exiting program."); return;

                }

            }

        }

        // MENU METHODS

        // Main menu
        static void MainMenu(ref string currentMenu){

            // Display the main menu options
            Console.WriteLine("Please select an option by number, at any time type 'Main' to return to this menu:");
            Console.WriteLine("1. Display stock");
            Console.WriteLine("2. Add item");
            Console.WriteLine("3. Remove item");
            Console.WriteLine("4. Lookup an item's price");
            Console.WriteLine("5. Lookup an item's stock level");
            Console.WriteLine("6. Update an item's price");
            Console.WriteLine("7. Update an item's stock level");
            Console.WriteLine("Or press e to exit");

            // Get user input
            string input = Console.ReadLine();
            Console.WriteLine();

            // Set menu to display to user's selection
            switch (input){

                case "1": currentMenu = "Display stock"; break;

                case "2": currentMenu = "Add item"; break;

                case "3": currentMenu = "Remove item"; break;

                case "4": currentMenu = "Lookup price"; break;

                case "5": currentMenu = "Lookup stock"; break;

                case "6": currentMenu = "Update price"; break;

                case "7": currentMenu = "Update stock"; break;

                case "e": currentMenu = "Exit"; break;

                // If user provides invalid input, display an error message and return to main program loop
                default:
                    Console.WriteLine("Invalid input, please try again." + Environment.NewLine);
                    currentMenu = "Main"; // likely not necessary, but included for clarity
                    break;

            }

        }

        // Display all stock items to the user
        static void DisplayStock(List<string> stockItems, List<double> stockPrices, List<int> stockAmounts){

            // Check if there are any stock items to display, if not return to main menu
            if (stockItems.Count == 0){
                Console.WriteLine("No stock items to display." + Environment.NewLine);
                return;
            }

            // Display stock items if there are any
            Console.WriteLine("Stock items:");
            for (int i = 0; i < stockItems.Count; i++){
                Console.WriteLine(stockItems[i] + " - Price: £" + stockPrices[i] + "; Quantity: " + stockAmounts[i]);
            }

            Console.WriteLine();

        }

        // Allow the user to add a new item to the database
        static void AddItem(List<string> stockItems, List<double> stockPrices, List<int> stockAmounts, ref string currentMenu){

            // Used to return the user to the main menu early if they choose to do so
            bool returnToMain = false; 

            // Menus other than main menu do not call each other
            currentMenu = "Main";

            // Take in item name, item should not already exist in stock list
            string newItem = GetItemNameFromUser(stockItems, "New", ref returnToMain);
            if (returnToMain) { return; }

            // Take in item price, must be positive double
            double newPrice = GetItemPriceFromUser(ref returnToMain);
            if (returnToMain) { return; }

            // Take in item quantity, must be positive integer
            int newQuantity = GetItemQuantityFromUser(ref returnToMain);
            if (returnToMain) { return; }

            // Add item to database
            stockItems.Add(newItem);
            stockPrices.Add(newPrice);
            stockAmounts.Add(newQuantity);

            // Report to user that item has been added and return to main menu
            Console.WriteLine("Item sucesfully added to stock list." + Environment.NewLine);

        }

        // Allow the user to remove an item from the database
        static void RemoveItem(List<string> stockItems, List<double> stockPrices, List<int> stockAmounts, ref string currentMenu){

            // Used to return the user to the main menu early if they choose to do so
            bool returnToMain = false; 

            // Menus other than main menu do not call each other
            currentMenu = "Main";

            // If the database is empty, report this to the user and return to main menu
            if (stockItems.Count == 0){
                Console.WriteLine("No stock items in database." + Environment.NewLine);
                return;
            }

            // Take in item name, item should already exist in stock list
            string itemToRemove = GetItemNameFromUser(stockItems, "Old", ref returnToMain);
            if (returnToMain) { return; }

            // Find index of item in stock list
            int itemIndex = stockItems.IndexOf(itemToRemove);

            // Remove item from database
            stockItems.RemoveAt(itemIndex);
            stockPrices.RemoveAt(itemIndex);
            stockAmounts.RemoveAt(itemIndex);

            // Report to user that item has been removed and return to main menu
            Console.WriteLine("Item successfully removed from stock list." + Environment.NewLine);

        }

        // Allow user to lookup an item's price or stock level
        static void LookupItemInfo(string control, List<string> stockItems, List<double> stockPrices, List<int> stockAmounts, ref string currentMenu){

            // Used to return the user to the main menu early if they choose to do so
            bool returnToMain = false; 

            // Menus other than main menu do not call each other
            currentMenu = "Main";

            // If the database is empty, report this to the user and return to main menu
            if (stockItems.Count == 0){
                Console.WriteLine("No stock items in database." + Environment.NewLine);
                return;
            }

            // Take in item name, item should already exist in stock list
            string itemToLookup = GetItemNameFromUser(stockItems, "Old", ref returnToMain);
            if (returnToMain) { return; }

            // Find index of item in stock list
            int itemIndex = stockItems.IndexOf(itemToLookup);

            //report price or stock level depending on user option
            switch (control) {

                // Report item price to user
                case "Price": Console.WriteLine("The price of " + itemToLookup + " is £" + stockPrices[itemIndex] + "." + Environment.NewLine); break;

                // Report item stock level to user
                case "Stock": Console.WriteLine("The stock level of " + itemToLookup + " is " + stockAmounts[itemIndex] + "." + Environment.NewLine); break;

                default: Console.WriteLine("ERROR: Invalid control value in LookupItemInfo method, exiting program."); Environment.Exit(1); break; //debugging error

            }

        }

        // Allow user to update an item's price
        static void UpdateItemPrice(List<string> stockItems, List<double> stockPrices, ref string currentMenu){

            // Used to return the user to the main menu early if they choose to do so
            bool returnToMain = false;

            // Menus other than main menu do not call eachother
            currentMenu = "Main";

            // If the database is empty, report this to the user and return to main menu
            if (stockItems.Count == 0){
                Console.WriteLine("No stock items in database." + Environment.NewLine);
                return;
            }

            // Take in item name, item should already exist in stock list
            string itemToEdit = GetItemNameFromUser(stockItems, "Old", ref returnToMain);
            if (returnToMain) { return; }

            // Find index of item in stock list
            int itemIndex = stockItems.IndexOf(itemToEdit);

            // Get updated price from user
            double updatedPrice = GetItemPriceFromUser(ref returnToMain);
            if (returnToMain) { return; }

            // Update price
            stockPrices[itemIndex] = updatedPrice;

        }

        // Allow user to update an item's stock level
        static void UpdateItemStock(List<string> stockItems, List<int> stockAmounts, ref string currentMenu){

            // Used to return the user to the main menu early if they choose to do so
            bool returnToMain = false;

            // Menus other than main menu do not call eachother
            currentMenu = "Main";

            // If the database is empty, report this to the user and return to main menu
            if (stockItems.Count == 0){
                Console.WriteLine("No stock items in database." + Environment.NewLine);
                return;
            }

            // Take in item name, item should already exist in stock list
            string itemToEdit = GetItemNameFromUser(stockItems, "Old", ref returnToMain);
            if (returnToMain) { return; }

            // Find index of item in stock list
            int itemIndex = stockItems.IndexOf(itemToEdit);

            string changeStockMode;

            // Ask user whether they would like to set the stock level or change it by an amount
            while (true) {

                Console.WriteLine("Select an option by number:");
                Console.WriteLine("1. Set the stock level to a specific quantity.");
                Console.WriteLine("2. Change the quantity by a certain amount.");

                // Get user input
                changeStockMode = Console.ReadLine();
                Console.WriteLine();

                // Allow user to return to main menu
                if (changeStockMode.ToLower() == "main") { return; }

                // Check user input is a valid option
                if (changeStockMode != "1" && changeStockMode != "2") { Console.WriteLine("Invalid input, please try again."); }
                else { break; }

            }

            int newStockAmount;

            switch (changeStockMode) {

                case "1":

                    // Get updated quantity from user
                    newStockAmount = GetItemQuantityFromUser(ref returnToMain);
                    if (returnToMain) { return; }

                    // Set new quantity
                    stockAmounts[itemIndex] = newStockAmount;
                    break;

                case "2":

                    // Get change in quantity from user, ensuring it won't make the stock level negative
                    newStockAmount = GetItemQuantityFromUser(ref returnToMain, stockAmounts[itemIndex]);
                    if (returnToMain) { return; }

                    // Set new quantity
                    stockAmounts[itemIndex] += newStockAmount;
                    break;

                default: Console.WriteLine("Unexpected changeStockMode value in UpdateItemStock method, exiting program."); Environment.Exit(1); break;

            }

        }

        // UTILITY METHODS

        // This method takes in an item name from the user.
        // expectedStatus determines whether the item should already exist in the stock list or not.
        // returnToMain is used to report to containing methods whether the user has chosen to return to the main menu.
        static string GetItemNameFromUser(List<string> stockItems, string expectedStatus, ref bool returnToMain){

            string itemName;

            while (true){

                // Get item name from user
                Console.WriteLine("Please enter the name of the item:");
                itemName = Console.ReadLine();
                Console.WriteLine();

                // Check if user wants to return to main menu
                if (itemName.ToLower() == "main"){ returnToMain = true; return null; }

                // Check if item name is valid, depending on expected status
                switch (expectedStatus) {

                    case "New": if (stockItems.Contains(itemName)) { Console.WriteLine("Item already exists."); break; }
                        else { return itemName; }

                    case "Old": if (!stockItems.Contains(itemName)) { Console.WriteLine("Item not found."); break; }
                        else { return itemName; }

                    default: Console.WriteLine("ERROR: Invalid action in GetItemName method, exiting program."); Environment.Exit(1); break; // debugging error

                }

            }

        }

        // This method takes in an item price from the user, also reporting whether the user has chosen to exit to the main menu
        static double GetItemPriceFromUser(ref bool returnToMain){

            double itemPrice;

            while (true){

                // Get item price from user
                Console.WriteLine("Please enter the price of the item:");
                string input = Console.ReadLine();
                Console.WriteLine();

                // Check if user wants to return to main menu
                if (input.ToLower() == "main"){ returnToMain = true; return 0; }

                // Check if item price is valid
                if (!double.TryParse(input, out itemPrice) || itemPrice < 0){
                    Console.WriteLine("Invalid price, please enter a positive number.");
                } else {
                    return itemPrice;
                }

            }

        }

        // This method takes in an item quantity from the user, 
        // currentQuantity is an optional parameter which when not provided a value indicates the stock is being set, rather than changed.
        // Also reports whether the user has chosen to exit to the main menu
        static int GetItemQuantityFromUser(ref bool returnToMain, int currentQuantity = -1){

            int itemQuantity;

            while (true){

                // Get item quantity from user
                Console.WriteLine("Please enter the quantity of the item. For sales or losses of stock, please enter a negative value:");
                string input = Console.ReadLine();
                Console.WriteLine();

                // Check if user wants to return to main menu
                if (input.ToLower() == "main"){ returnToMain = true; return 0; }

                // Check validity of item based on operationMode
                switch (currentQuantity) {

                    //Set stock level
                    case -1: 
                        if (!int.TryParse(input, out itemQuantity) || itemQuantity < 0){
                            Console.WriteLine("Invalid quantity, please enter a positive integer.");
                        } else {
                            return itemQuantity;
                        }
                        break;

                    //Change stock level
                    case >= 0:
                        if (!int.TryParse(input, out itemQuantity) || -itemQuantity > currentQuantity){
                            Console.WriteLine("Invalid quantity, please enter an integer amount that does not reduce current stock below 0. Current stock: " + currentQuantity);
                        } else {
                            return itemQuantity;
                        }
                        break;

                    default: Console.WriteLine("ERROR: Invalid currentQuantity value in GetItemQuantity method, exiting program."); Environment.Exit(1); break; // debugging error

                }

            }

        }

    }
    
}