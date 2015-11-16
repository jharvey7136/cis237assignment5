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
        private string searchString;
       




        BeverageJHarveyEntities beveragesJHarveyEntities = new BeverageJHarveyEntities();



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
            //beveragesJHarveyEntities.SaveChanges();

        }

        public void UpdateWine()
        {

        }

        public void DeleteWine()
        {

        }


    }
}
