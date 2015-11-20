//Author: John Harvey
//CIS 237
//Assignment 5
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        private int mainMenuSelection;
        private int updateSelection;
        private int deleteSelection;
        private string searchString;

        BeverageJHarveyEntities1 beveragesJHarveyEntities = new BeverageJHarveyEntities1();

        public UserInterface()
        {
        }

        public void MainMenu()
        {
            Console.WriteLine("Welcome To The Wine Collection Database\n");

            while (mainMenuSelection != 1 || mainMenuSelection != 2 || mainMenuSelection != 3 || mainMenuSelection != 4 ||
                mainMenuSelection != 5 || mainMenuSelection != 6)
            {
                Console.WriteLine("1: Print Entire Wine Item List");
                Console.WriteLine("2: Search By Wine ID");
                Console.WriteLine("3: Add Wine Item To List");
                Console.WriteLine("4: Update Existing Wine Item");
                Console.WriteLine("5: Delete Existing Wine Item");
                Console.WriteLine("6: Exit\n");
                Console.Write("Enter Selection: ");

                try
                {
                    mainMenuSelection = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (mainMenuSelection == 1)
                        PrintWineList();

                    if (mainMenuSelection == 2)
                        SearchForWine();

                    if (mainMenuSelection == 3)
                        AddWine();

                    if (mainMenuSelection == 4)
                        UpdateWine();

                    if (mainMenuSelection == 5)
                        DeleteWine();

                    if (mainMenuSelection == 6)
                        Environment.Exit(0);

                    if (mainMenuSelection > 6 || mainMenuSelection < 0)
                        Console.WriteLine("Input Must Be Integer Between 1 - 6\n");

                }
                catch
                {
                    Console.WriteLine("Input Must Be Integer Between 1 - 6\n");
                }
            }
        }


        public void PrintWineList()
        {
            foreach (Beverage beverage in beveragesJHarveyEntities.Beverages)
            {
                Console.WriteLine(beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price);
            }
            Console.WriteLine();
        }



        public void SearchForWine()
        {
            Console.Write("Enter Wine ID: ");
            try
            {
                searchString = Console.ReadLine();
                Console.WriteLine();
                Beverage beverageToFind = beveragesJHarveyEntities.Beverages.Where(c => c.id == searchString).First();
                Console.WriteLine(beverageToFind.id + " " + beverageToFind.name + " " + beverageToFind.pack + " " + beverageToFind.price);
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Error - Wine Not Found\n");
            }
        }

        public void AddWine()
        {
            Beverage newBevToAdd = new Beverage();
            try
            {
                Console.Write("Enter Wine ID: ");
                newBevToAdd.id = Console.ReadLine();

                Console.Write("Enter Wine Name: ");
                newBevToAdd.name = Console.ReadLine();

                Console.Write("Enter Wine Pack: ");
                newBevToAdd.pack = Console.ReadLine();

                Console.Write("Enter Wine Price: ");
                newBevToAdd.price = int.Parse(Console.ReadLine());

                Console.WriteLine();
                beveragesJHarveyEntities.Beverages.Add(newBevToAdd);
                beveragesJHarveyEntities.SaveChanges();
                Console.WriteLine("Wine Add Successful\n");
            }
            catch
            {                
                Console.WriteLine("Error - Bad Input, Wine ID Already Exists -  Wine Add Unsuccessful\n");
            }
        }

        public void UpdateWine()
        {
            Console.Write("Enter Wine ID To Update: ");
            try
            {
                Beverage bevToUpdate = beveragesJHarveyEntities.Beverages.Find(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Wine To Update: " + bevToUpdate.id + " " + bevToUpdate.name + " " + bevToUpdate.pack + " " + bevToUpdate.price);
                Console.WriteLine();

                Console.WriteLine("Correct Wine To Update?");
                Console.WriteLine();
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No, Go Back");
                Console.WriteLine("3: Exit To Main Menu\n");
                Console.Write("Enter Number: ");
                try
                {
                    updateSelection = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    while (updateSelection != 1 || updateSelection != 2 || updateSelection != 3)
                    {
                        if (updateSelection == 1)
                        {
                            try
                            {
                                Console.Write("Enter New Wine Name: ");
                                bevToUpdate.name = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("Enter New Wine Pack: ");
                                bevToUpdate.pack = Console.ReadLine();
                                Console.WriteLine();

                                Console.Write("Enter New Wine Price: ");
                                bevToUpdate.price = int.Parse(Console.ReadLine());
                                Console.WriteLine();
                                Console.WriteLine("Wine Update Successful\n");
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Bad Input - Wine Update Unsuccessful\n");
                            }

                        }
                        if (updateSelection == 2)
                            UpdateWine();

                        if (updateSelection == 3)
                            MainMenu();
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Input Must Be Integer Between 1 - 3\n");
                }
            }
            catch
            {
                Console.WriteLine("Error - Wine ID Not Found\n");
                MainMenu();
            }

            beveragesJHarveyEntities.SaveChanges();

        }

        public void DeleteWine()
        {
            Console.Write("Enter Wine ID To Delete: ");
            try
            {
                Beverage bevToDelete = beveragesJHarveyEntities.Beverages.Find(Console.ReadLine());
                Console.WriteLine();

                Console.WriteLine("Wine To Delete: " + bevToDelete.id + " " + bevToDelete.name + " " + bevToDelete.pack + " " + bevToDelete.price);
                Console.WriteLine();

                Console.WriteLine("Correct Wine To Delete?");
                Console.WriteLine();
                Console.WriteLine("1: Yes");
                Console.WriteLine("2: No, Go Back");
                Console.WriteLine("3: Exit To Main Menu\n");
                Console.Write("Enter Number: ");

                try
                {
                    deleteSelection = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    while (deleteSelection != 1 || deleteSelection != 2 || deleteSelection != 3)
                    {
                        if (deleteSelection == 1)
                        {
                            beveragesJHarveyEntities.Beverages.Remove(bevToDelete);
                            Console.WriteLine("Delete Successful");
                            break;
                        }
                        if (deleteSelection == 2)
                            DeleteWine();

                        if (deleteSelection == 3)
                            MainMenu();
                    }
                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Input Must Be Integer Between 1 - 3\n");
                }

            }
            catch
            {
                Console.WriteLine("Error - Wine ID Not Found\n");
            }
            beveragesJHarveyEntities.SaveChanges();
        }
    }
}
