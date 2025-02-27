/*
The class Program contains the Main method handling user interface, input, and control.
*/

using System;

class Program
{
    public static void Main()
    {
        string command;

        //Inform user of available functionality
        Console.WriteLine("Welcome to the Library! You can use the following commands:");
        Console.WriteLine("Add [bookname]");
        Console.WriteLine("Remove [bookname]");
        Console.WriteLine("Display");
        Console.WriteLine("Lookup [bookname]");
        Console.WriteLine("Borrow [bookname]");
        Console.WriteLine("Return [bookname]");
        Console.WriteLine("Exit");

        do
        {
            //Prompt user for a command
            Console.Write("\nEnter a command: ");
            command = Console.ReadLine() ?? "";

            //Add a book to the library by name
            if (command.ToLower().StartsWith("add "))
            {
                string bookName = command.Substring(4);
                Library.AddBook(bookName);
            }

            //Remove a book from the library by name
            else if (command.ToLower().StartsWith("remove "))
            {
                string bookName = command.Substring(7);
                Library.RemoveBook(bookName);
            }

            //Check availability of a book by name
            else if (command.ToLower().StartsWith("lookup ")) 
            {
                string bookName = command.Substring(7);
                Library.LookUp(bookName);
            }

            //Allow user to borrow a book from the library by name
            else if (command.ToLower().StartsWith("borrow ")) 
            {
                string bookName = command.Substring(7);
                User.BorrowBook(bookName);
            }

            //Allow user to return a book to the library by name
            else if (command.ToLower().StartsWith("return ")) 
            {
                string bookName = command.Substring(7);
                User.ReturnBook(bookName);
            }

            //Display all books in the libary and their availability to the user
            else if (command.ToLower().Equals("display", StringComparison.OrdinalIgnoreCase))
            {
                Library.DisplayBooks();
            }

            //Inform user if their command does not match a valid command option
            else if (!command.ToLower().Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                Console.WriteLine("Invalid command. Please try again.");
            }

        //Continue until user enters the Exit command
        } while (!command.ToLower().Equals("exit", StringComparison.OrdinalIgnoreCase));

        Console.WriteLine("Shutting down.");
    }
}