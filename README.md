# Assignment 5 - Update the Assignment 1 with Wines to use a database instead of a CSV

## Due 11-24-2015

## Author
John Harvey

## New Description
This program will connect to a Beverage/Wine database using the Entity Framework model. Upon running the program, the user will be prompted with a main menu offering six selection choices. The user will be able to print the entire wine item list, search for a wine by ID, add a wine item to the list, update an existing wine item, delete an existing wine item, or exit the program. 

Main Menu: (Loops until user decides to exit)
1. Print list: If 1 is selected, the entire wine item list will be printed to the screen.

2. Search: If 2 is selected, the user will be prompted to enter a Wine ID. If the wine item is found, it will be printed to screen along with its name, pack, and price. The user will get an error message if the wine ID is not found within the database.

3. Add Wine: If 3 is selected, the user will be prompted with a series of questions regarding the wine ID, name, pack, and price to add to database.

4. Update Wine: If 4 is selected, the user will be prompted to enter the wine ID of the wine item they would like to update. If found, the user will have a chance to confirm they entered the correct wine ID. The user will then be able to update the wine name, pack, and price. The user will get an error message if the wine ID is not found within the database.

5. Delete Wine: If 5 is selected, the user will be prompted to enter the wine ID of the wine item they would like to delete. The user will have a chance to confirm they entered the correct wine ID. The user will get an error message if the wine ID is not found within the database.

6. Exit: If 6 is selected, the program will close.

## Description

Either modify what I have in my Asignment1 key, which is included here, or bring in your files and use that to do the work.

You are going to take the Assignment 1 we did with the Wine List .CSV and update it to work with a database in place of the CSV. In addition, the UI must be updated to accomodate some new fields for a Wine Item.

The program should continually run until the user decides to exit (entering a certain character on the keyboard).

The program should allow the following functionality:

1. Loads the information about the Wines (Beverages) from the database. This achived by making the connection to the database.
2. Allow the user to print the entire list of items.
3. Allow the user to search for an item by the item id, and print out the item if found. Error message if not. This can be done with either Find, or Where.
4. Allow the user to add a new wine item to the list. It should show a nice error message if the user tries to add a wine witha primary id that is already in the DB.
5. Allow the user to update an existing wine item.
6. Allow the user to delete an existing wine item. It should show a nice error if the delete can not complete.

Replace the class called WineItem with an Entity Framework Model based on the data in the database. We will do an example of this in class.

Replace the WineItemCollection class with an Entity Framework collection based on the data in the database. We will do an example of this in class.

Update the class called User Interface to include any new methods that are required to facilitate the above funcitonality.

CSVProcessor can either be removed or left. It will not be used though.

The old WineItem and WineItemCollection can be removed if desired since the Entity Framework versions will be used instead.

To connect to the database you will use the following information.

Sever address / name: barnesbrothers.homeserver.com,443 //Remember that the comma denotes that the port number follows.

Sql Server Authentication (Not Windows Auth):

Username: FirstInial + LastName (All lowercase) (ie. John Smith would be jsmith)

Password: password (If you would like me to change your password to something else for you, I can)

DatabaseName: Beverage + FirstInital + LastName

********************************************************************************************
*NOTE: There is a database for each person. Use the one that is for you. Don't be a troll. If I hear about you trolling on someone elses database, you will get a zero for the assignment!
********************************************************************************************

Solution Requirements:

* 4 classes (Main, Beverage (EF Version), Beverages (EF Version), and UserInterface. The names can differ, and might due to database names and EF setup.)
* EntityFramework Model and Collection
* Read functionality
* Insert functionality
* Update functionality
* Delete functionality
* UI Class to handle I/O

### Notes
All solution requirements met. 

## Outside Resources Used
I referred to my assignment 1, along with our in class assignment 5. I did not use anybody elses code or any online resources. 

## Known Problems, Issues, And/Or Errors in the Program
I have attempted to break the program with bad input in every situation but so far haven't been able to. The program seems to be fully functional and user friendly.

