/*
The class Library stores the library's books and their availability (whether they are being borrowed)
Also provides methods for altering these states, including adding and removing books, diplaying inventory,
searching for books, and handling availability changes when books are borrowed/returned.
*/

using System;
using System.Collections.Generic;

public static class Library{

    //Lists containing books and whether they are currently being borrowed from the library
    static List<string> books = new List<string>();
    static List<bool> availability = new List<bool>();

    //Adds a book to the list by name, setting availability to true by default
    public static void AddBook(string book)
    {
        //prevent adding multiple books of same name
        if(books.Contains(book)) { Console.WriteLine("Cannot add book, already in database."); return; }

        //limit library storage to 5 books
        if (books.Count < 5)
        {
            books.Add(book);
            availability.Add(true);
            Console.WriteLine($"Book '{book}' added to the library.");
        }
        else
        {
            Console.WriteLine("Cannot add more books. The library already has 5 books.");
        }
    }

    //Permanently remove a book from the library by name
    public static void RemoveBook(string book)
    {
        if (books.Contains(book))
        {
            int bookIndex = books.IndexOf(book);

            //Prevent book from being removed from the library until it is returned by a borrowing user
            if(availability[bookIndex] == false) {Console.WriteLine("Book currently being borrowed, cannot remove."); return; }

            books.Remove(book);
            availability.RemoveAt(bookIndex);
            Console.WriteLine($"Book '{book}' removed from the library.");
        }
        else
        {
            Console.WriteLine($"Book '{book}' not found in the library.");
        }
    }

    //Displpay all stored books and whether they are available for borrowing
    public static void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("The library is empty.");
        }
        else
        {
            Console.WriteLine("Books in the library:");
            for (var i = 0; i < books.Count; i++)
            {
                Console.WriteLine($"- {books[i]}; Available: {availability[i]}");
            }
        }
    }

    //Lookup a book for availablity in the library
    public static void LookUp(string book)
    {
        //Check if book exists
        if (!books.Contains(book)){ Console.WriteLine("Book not found in database."); return; }

        int bookIndex = books.IndexOf(book);

        if (availability[bookIndex]) {Console.WriteLine($"Book {book} available to borrow."); }
        else { Console.WriteLine("Book currently in use, unavailable to borrow."); }
    }

    //Switch state of a book's availability when user borrows/returns a book
    public static bool SwitchAvailability(string book, bool targetState)
    {
        //Check book exists
        if ( !books.Contains(book) ){Console.WriteLine($"Book {book} does not exist."); return false; }

        int bookIndex = books.IndexOf(book);

        //Taking out a book
        if (!targetState && availability[bookIndex]) {
            availability[bookIndex] = false;
            Console.WriteLine($"Book {book} borrowed from library.");
            return true;
        } else if (!targetState && !availability[bookIndex]) { Console.WriteLine("Book not available to borrow."); return false; }

        //Returning a book
        else if (targetState && !availability[bookIndex]){
            availability[bookIndex] = true;
            Console.WriteLine($"Book {book} returned to library.");
            return true;
        }

        //It should not be possible for the program to try to return a book that hasn't been taken out
        else { Console.WriteLine("Error: unexpected state in SwitchAvailability method in Library class"); return false; }

    }

}