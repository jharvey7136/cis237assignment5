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
    class Program
    {
        static void Main(string[] args)
        {
            int windowheight = 60;
            int windowwidth = 160;

            UserInterface MainMenu = new UserInterface();

            Console.BufferHeight = 8000;
            Console.BufferWidth = 100;
            Console.SetWindowSize(windowwidth, windowheight);

            MainMenu.MainMenu();



        }
    }
}
