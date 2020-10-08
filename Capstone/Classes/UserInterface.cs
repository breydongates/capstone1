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

            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
                Console.ReadLine();
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
                        this.AddMoney();
                        break;
                    case "2":
                        this.SelectProduct();
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
