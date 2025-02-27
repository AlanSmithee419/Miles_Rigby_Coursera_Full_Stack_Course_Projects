/*
The class User contains a list keeping track of the books a user is currently borrowing from the library,
as well as methods to handle the borrowing and returning of books.
*/

using System;
using System.Collections.Generic;

public static class User{

    //Store user's borrowed books.
    static List<string> books = new List<string>();

    //Method to borrow a book from the library
    public static void BorrowBook(string book)
    {
        //Limit borrowed books to 3
        if(books.Count < 3) {
            if (Library.SwitchAvailability(book, false)) { books.Add(book); }
        }

        else {Console.WriteLine("You may not borrow more than 3 books at once, please return some before borrowing more."); }
    }

    //Method to return a book to the library
    public static void ReturnBook(string book)
    {
        //Make sure user currently has possession of the book before trying to return it
        if (books.Contains(book)) {
            if (Library.SwitchAvailability(book, true)) { books.Remove(book); } 
        } 
        
        else {Console.WriteLine($"You are not borrowing {book}, failed to return."); }
    }

}