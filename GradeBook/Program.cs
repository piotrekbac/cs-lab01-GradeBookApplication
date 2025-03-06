using System;
using GradeBook.UserInterfaces;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            //Zadanie - Piotr Bacior - 15 722 - Informatyka stosowana - I rok - WSEI Kraków
            Console.WriteLine("#=======================#");
            Console.WriteLine("# Welcome to GradeBook! #");
            Console.WriteLine("#=======================#");

            StartingUserInterface.CommandLoop();
            
            Console.WriteLine("Thank you for using GradeBook!");
            Console.WriteLine("Have a nice day!");
            Console.Read();
        }
    }
}