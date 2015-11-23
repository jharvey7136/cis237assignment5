//Author: John Harvey
//CIS 237
//Assignment 5
//Due: 11/24/15
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment1
{
    class UserInterface
    {
        //Working Variables
        private int mainMenuSelection;
        private int updateSelection;
        private int deleteSelection;
        private string searchString;

        //Create new instance of the Beverages Database
        BeverageJHarveyEntities1 beveragesJHarveyEntities = new BeverageJHarveyEntities1();

        //Empty public constructor
        public UserInterface()
        {
        }

        //********************************************MAIN MENU METHOD**********************************************//
        public void MainMenu()
        {
            Console.WriteLine("Welcome To The Wine Collection Database\n");

            //Menu sits in a while loop to keep program running until the user chooses to exit
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

                try  //Try Catch used to handle bad input
                {
                    mainMenuSelection = int.Parse(Console.ReadLine());
                    Console.WriteLine();

                    if (mainMenuSelection == 1) //If 1 is selected, the entire wine list will be printed
                        PrintWineList();   

                    if (mainMenuSelection == 2) //If 2 is selected, the user will be able to search for a wine by the Wine ID
                        SearchForWine();

                    if (mainMenuSelection == 3) //If 3 is selected, the user will be able to add a new wine to the collection
                        AddWine();

                    if (mainMenuSelection == 4) //If 4 is selected, the user will be able to update a currently existing wine
                        UpdateWine();

                    if (mainMenuSelection == 5) //If 5 is selected, the user will be able to delete a wine currently in the collection
                        DeleteWine();

                    if (mainMenuSelection == 6) //If 6 is selected, the program will close
                        Environment.Exit(0);

                    if (mainMenuSelection > 6 || mainMenuSelection < 1) //Error message in case the user enters a digit lower than 1 or higher than 6
                        Console.WriteLine("Input Must Be Integer Between 1 - 6\n");

                }
                catch
                {
                    Console.WriteLine();
                    Console.WriteLine("Input Must Be Integer Between 1 - 6\n");
                }
            }
        }
        //********************************************END MAIN MENU METHOD**********************************************//


        //********************************METHOD TO PRINT WINE COLLECTION***********************************************//
        public void PrintWineList()
        {
            //For each beverage in the beverage collection, print out the beverage id, pack, and price
            foreach (Beverage beverage in beveragesJHarveyEntities.Beverages)
            {
                Console.WriteLine(beverage.id + " " + beverage.name + " " + beverage.pack + " " + beverage.price);
            }
            Console.WriteLine();
        }
        //********************************END METHOD TO PRINT WINE COLLECTION***********************************************//


        //********************************METHOD TO SEARCH FOR WINE***********************************************//
        public void SearchForWine()
        {
            Console.Write("Enter Wine ID: ");
            try
            {
                //Allows the user to search for an item by ID using ".Where"
                searchString = Console.ReadLine();
                Console.WriteLine();
                Beverage beverageToFind = beveragesJHarveyEntities.Beverages.Where(c => c.id == searchString).First();
                Console.WriteLine(beverageToFind.id + " " + beverageToFind.name + " " + beverageToFind.pack + " " + beverageToFind.price); //Output formatted beverage if found
                Console.WriteLine();
            }
            catch
            {
                Console.WriteLine("Error - Wine Not Found\n"); //Error message if wine ID is not found
            }
        }
        //********************************END METHOD TO SEARCH FOR WINE***********************************************//

        //********************************METHOD TO ADD NEW WINE***********************************************//
        public void AddWine()
        {
            Beverage newBevToAdd = new Beverage(); //Create new beverage instance for new wine being added
            try
            {
                Console.Write("Enter Wine ID: ");        //Adds new Wine ID
                newBevToAdd.id = Console.ReadLine();

                Console.Write("Enter Wine Name: ");      //Adds new Wine Name
                newBevToAdd.name = Console.ReadLine();

                Console.Write("Enter Wine Pack: ");      //Adds new Wine Pack
                newBevToAdd.pack = Console.ReadLine();

                Console.Write("Enter Wine Price: ");     //Adds new Wine Price
                newBevToAdd.price = int.Parse(Console.ReadLine());

                Console.WriteLine();
                beveragesJHarveyEntities.Beverages.Add(newBevToAdd); //Beverage is added to collection using ".Add"
                beveragesJHarveyEntities.SaveChanges();              //Save changes to wine collection if all input is valid and Wine ID doesnt already exist
                Console.WriteLine("Wine Add Successful\n");
            }
            catch
            {   //Error message if Wine ID already exists in collection, or if input is bad             
                Console.WriteLine("Error - Bad Input, Wine ID Already Exists -  Wine Add Unsuccessful\n");
            }
        }
        //********************************END METHOD TO ADD NEW WINE***********************************************//

        //********************************METHOD TO UPDATE EXISTING WINE***********************************************//
        public void UpdateWine()
        {
            Console.Write("Enter Wine ID To Update: ");
            try
            {
                Beverage bevToUpdate = beveragesJHarveyEntities.Beverages.Find(Console.ReadLine()); //Create new beverage instance for Wine to update
                Console.WriteLine();

                Console.WriteLine("Wine To Update: " + bevToUpdate.id + " " + bevToUpdate.name + " " + bevToUpdate.pack + " " + bevToUpdate.price);
                Console.WriteLine();

                //Small menu which asks the user if the Wine ID entered matches the Wine they would like to udpate
                Console.WriteLine("Correct Wine To Update?");
                Console.WriteLine();
                Console.WriteLine("1: Yes");                      //If Wine ID is correct, continue with update
                Console.WriteLine("2: No, Go Back");              //If Wine ID is NOT correct, then go back and re-enter Wine ID
                Console.WriteLine("3: Exit To Main Menu\n");      //Allows the user to exit back to main menu if needed
                Console.Write("Enter Number: ");
                try
                {   //Try Catch to handle bad input
                    updateSelection = int.Parse(Console.ReadLine());
                    Console.WriteLine();
                    //While loop to loop update menu until selectin is valid
                    while (updateSelection != 1 || updateSelection != 2 || updateSelection != 3)
                    {
                        if (updateSelection == 1)
                        {
                            try
                            {   //The following lines update existing Wine if 1 is selected from menu
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
                                break; //Will break out of loop if update is successful
                            }
                            catch
                            {
                                Console.WriteLine("Bad Input - Wine Update Unsuccessful\n");
                            }

                        }
                        if (updateSelection == 2)
                            UpdateWine();          //Restarts update process if the user incorrectly entered the Wine ID and wants to start over

                        if (updateSelection == 3)
                            MainMenu();            //Takes the user back to the main menu if they want out of the udpate process
                    }
                }
                catch
                {
                    //Error message in case input is not valid
                    Console.WriteLine();
                    Console.WriteLine("Input Must Be Integer Between 1 - 3\n");
                }
            }
            catch
            {
                //Error message in case Wine ID is not found in collection
                Console.WriteLine("Error - Wine ID Not Found\n");
                MainMenu();
            }
            beveragesJHarveyEntities.SaveChanges();  //Save changed to database
        }
        //********************************END METHOD TO UPDATE EXISTING WINE***********************************************//



        //********************************METHOD TO DELETE WINE***********************************************//
        public void DeleteWine()
        {
            Console.Write("Enter Wine ID To Delete: ");
            try
            {   //Try Catch to handle bad input
                Beverage bevToDelete = beveragesJHarveyEntities.Beverages.Find(Console.ReadLine()); //Create a new beverage instance based on user's Wine ID input
                Console.WriteLine();

                Console.WriteLine("Wine To Delete: " + bevToDelete.id + " " + bevToDelete.name + " " + bevToDelete.pack + " " + bevToDelete.price);
                Console.WriteLine();

                //Small menu to verify Wine ID was correctly entered by user
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
                            //If Wine ID is correctly entered, it will now be deleted from the database
                            beveragesJHarveyEntities.Beverages.Remove(bevToDelete);
                            Console.WriteLine("Delete Successful\n");  //Confirm wine has been deleted successfully
                            break;                                   //Break out of loop   
                        }
                        if (deleteSelection == 2)
                            DeleteWine();                            //Restart delete process if Wine ID was entered incorrectly

                        if (deleteSelection == 3)
                            MainMenu();                              //Takes the user back to the main menu if they would like to exit the delete process
                    }
                }
                catch
                {
                    //Error message if menu selection is not 1, 2 or 3
                    Console.WriteLine();
                    Console.WriteLine("Input Must Be Integer Between 1 - 3\n");
                }

            }
            catch
            {
                //Error message if Wine ID entered is not found in database
                Console.WriteLine("Error - Wine ID Not Found\n");
            }
            beveragesJHarveyEntities.SaveChanges();
        }
        //********************************END METHOD TO DELETE WINE***********************************************//

    }
}
