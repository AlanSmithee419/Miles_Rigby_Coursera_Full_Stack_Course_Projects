The Library Manager is a C# project which implements a text-based UI for managing books in a library, and
book borrowing for a single user. It allows for adding and removing books from the library, borrowing and
returning for a user, as well as an option to diplays all books in the library, and lookup functionality 
to check whether a particular book exists in the library or is available for borrowing.

Program.cs - Contains the Main() method, allowing user input and ensuring the program does not end until
the user exits. This method handles all user control, calling other classes to excecute user requests.

Library.cs - Contains the Library class, which stores the available books and whether they are currently
held within the library or being borrowed by the user. Has methods for retrieving and modifying the
Library's data, including adding and removing books, searching for specific books, displaying all books, 
and checking a particular book's availability. It also contains a method for verifying a User's attempts 
to borrow books from the Library, verifying the existence and availability of the book requested.
The library is limited to holding up to five books at a time.

User.cs - Contains the User class, which stores the user's borrowed books, and contains methods for
borrowing and returning books from the Library making use of the Library class to do so.
The user is allowed to borrow up to three books from the library at a time.

Project developed using Visual Studio Code V17.5.2.0, and .NET 9