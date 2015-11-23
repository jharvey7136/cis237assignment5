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
    class Program
    {
        static void Main(string[] args)
        {
            //Variables for windows size
            int windowheight = 60;
            int windowwidth = 160;

            //Create a new instance of the UserInterface class
            UserInterface MainMenu = new UserInterface();

            //Set window height and width large enough to see wine list
            Console.BufferHeight = 8000;
            Console.BufferWidth = 100;
            Console.SetWindowSize(windowwidth, windowheight);

            //Call MainMenu method from UI class to begin program
            MainMenu.MainMenu();
        }
    }
}
