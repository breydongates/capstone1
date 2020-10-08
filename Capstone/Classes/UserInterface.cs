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
        

        public void RunInterface()
        {
            files.LoadCateringItems(this.catering);

            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
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
        public void DisplayCateringItems()
        {
            Console.WriteLine("Our current items: ");
            foreach (CateringItem item in this.catering.DisplayCateringItems)
            {
                Console.WriteLine($"{item.Id} {item.Name} {item.Price} {item.Category} {item.Inventory}");
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
                Console.WriteLine("Current Account Balance: ");
                string orderItemsChoice = Console.ReadLine();
                switch (orderItemsChoice)
                {
                    case "1":
                        Console.WriteLine("Your current balance is: " + this.catering.Balance);
                        Console.WriteLine("How much would you like to add (balance can not exceed $5000)?: ");
                        string input = Console.ReadLine();
                        decimal moneyToAdd = decimal.Parse(input);
                        if (this.catering.Balance >= 5000 || (this.catering.Balance + moneyToAdd) > 5000 )
                        {
                            Console.WriteLine("Balance cannot exceed $5000");
                            break;
                        }
                        this.catering.AddMoney(moneyToAdd);
                        break;
                    case "2":
                        DisplayCateringItems();
                        Console.WriteLine("Please enter the product code to purchase: ");
                        string inputProductCode = Console.ReadLine();
                        if (catering.DisplayCateringItems.ToString().Contains(inputProductCode))
                        {
                            Console.WriteLine("Please enter the amount to purchase: ");
                            int amount = int.Parse(Console.ReadLine());
                            Console.WriteLine(this.catering.SelectProduct(inputProductCode, amount));
                        }
                        else
                        {
                            Console.WriteLine("This product code was not found. Please choose one that exists.");
                        }
                        break;
                    case "3":
                        exitMenu = true;
                        break;
                    default:
                        Console.WriteLine("Please select a number between 1 and 3.");
                        break;
                }
            }
        }

    }
}
