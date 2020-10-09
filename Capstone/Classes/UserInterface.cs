using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// ALL instances of Console.ReadLine and Console.WriteLine should 
    /// be in this class.
    /// </summary>
    public class UserInterface
    {
        private FileAccess files = new FileAccess();
        private Catering catering = new Catering();
        

        /// <summary>
        /// Runs interface
        /// </summary>
        public void RunInterface()
        {
            files.LoadCateringItems(this.catering); //Calls the method to load csv into catering items

            bool done = false;
            while (!done)
            {
                Console.WriteLine();
                Console.WriteLine("This is the Catering System User Interface");
                Console.WriteLine();
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine();
                Console.WriteLine("(2) Order");
                Console.WriteLine();
                Console.WriteLine("(3) Quit");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        this.DisplayCateringItems();
                        break;
                    case "2":
                        this.OrderItems();
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please choose a number between 1 and 3.");
                        break;

                }
            }
        }

        // Displays all items and stock level
        public void DisplayCateringItems()
        {
            Console.WriteLine("Our current items: ");
            foreach (CateringItem item in this.catering.DisplayCateringItems)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Price} {item.Category} {item.Quantity}");
                Console.WriteLine();
            }
        }
        public void OrderItems()
        {
            bool exitMenu = false;
            while (!exitMenu)
            {
                Console.WriteLine("(1) Add Money");
                Console.WriteLine("(2) Select Products");
                Console.WriteLine("(3) Complete Transaction");
                Console.WriteLine("Current Account Balance: " + this.catering.Balance.ToString("C"));
                string orderItemsChoice = Console.ReadLine();
                switch (orderItemsChoice)
                {
                    case "1": //Checks to see if balance is over 5000, calls AddMoney from catering class to add amount entered
                        Console.WriteLine("Your current balance is: " + this.catering.Balance.ToString("C"));
                        Console.WriteLine("How much would you like to add (balance can not exceed $5000)?: ");
                        string input = Console.ReadLine();
                        decimal moneyToAdd = decimal.Parse(input);
                        
                        Console.WriteLine(this.catering.AddMoney(moneyToAdd));
                        files.TransactionLog(moneyToAdd, this.catering.Balance); //Logs the add money transaction
                        break;
                    case "2":
                        DisplayCateringItems();
                        Console.WriteLine("Please enter the product code to purchase: ");
                        string inputProductCode = Console.ReadLine().ToUpper();
                        if (catering.ItemExists(inputProductCode)) // Calls item exists method in catering to check if item exists
                        {
                            Console.WriteLine("Please enter the amount to purchase: ");
                            int amount = int.Parse(Console.ReadLine());
                            Console.WriteLine(this.catering.SelectProduct(inputProductCode, amount));
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine("This product code was not found. Please choose one that exists.");
                        }
                        
                        break;
                    case "3":
                        decimal total = 0;
                        foreach(CateringItem item in catering.purchasedItems) //Iterated thru purchased items list and spits out total
                        {

                            Console.WriteLine($"{item.Quantity} {item.Category} {item.Name} {item.Price.ToString("C")} {(item.Quantity * item.Price).ToString("C")} ");
                            total += item.Quantity * item.Price;
                            Console.WriteLine();
                            files.PurchaseLog(item.Quantity, item.Name, item.Id, item.Price, catering.Balance - (item.Quantity * item.Price)); // Logs the purchase info

                        }
                        Console.WriteLine("Your total is: " + total.ToString("C"));
                        if (catering.CheckBalanceIsEnough(total))
                        {
                            decimal change = catering.Balance - total;
                            Console.WriteLine("Your change is: ");
                            Console.WriteLine($"${change}");
                            Console.WriteLine(catering.Change(change)); // Calls the change method on catering class to get the dollar/cents denomination
                            catering.purchasedItems.Clear();
                            files.ChangeLog(change, catering.Balance); // Logs the change

                            exitMenu = true;

                            break;
                        }
                        else
                        {
                            Console.WriteLine("Your balance is not enough to purchase items, please add more money.");
                            
                            break;

                        }
                        
                    default:
                        Console.WriteLine("Please select a number between 1 and 3.");
                        break;
                }
            }
        }

    }
}
