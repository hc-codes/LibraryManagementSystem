using LibraryManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class WrongInputException : Exception
    {
        public WrongInputException() { }

        public WrongInputException(string count) : base(String.Format($"Invalid Count For Books: {count} ")) { }
    }
    public class Actions
    {
        private List<Users> fullUsers;
        private List<Book> fullBooks;
        Screen screen = new Screen();

        public Actions(List<Users> userList, List<Book> bookList)
        {
            fullUsers = userList;
            fullBooks = bookList;
        }

        #region UserManagement

        internal void AddUser()
        {
            bool goBack = false;
            while (!goBack)
            {
                screen.ClearAndNewLine();
                screen.PrintLine();
                screen.PrintRow("ADD A NEW USER");
                screen.PrintLine();
                screen.NormalPrint("1. Add a new Admin", "2. Add a new Librarian", "3. Add a new Student");
                screen.RedPrint("4. Go Back");
                screen.ChoicePrint();
                string choice = Console.ReadLine();
                Console.WriteLine();
                switch (choice)
                {
                    case "1":
                        screen.ClearAndNewLine();
                        screen.PrintLine();
                        screen.PrintRow("ADD A NEW ADMIN: ");
                        screen.PrintLine();
                        var admin = new Admin();
                        SaveUser(admin);
                        screen.WaitAndClear();

                        break;
                    case "2":
                        screen.ClearAndNewLine();
                        screen.PrintLine();
                        screen.PrintRow("ADD A NEW LIBRARIAN: ");
                        screen.PrintLine();
                        var lib = new Librarian();
                        SaveUser(lib);
                        screen.WaitAndClear();
                        break;
                    case "3":
                        screen.ClearAndNewLine();
                        screen.PrintLine();
                        screen.PrintRow("ADD A NEW STUDENT: ");
                        screen.PrintLine();
                        var student = new Student();
                        SaveUser(student);
                        screen.WaitAndClear();
                        break;
                    case "4":
                        goBack = true;
                        break;
                    default:
                        screen.RedPrint("Invalid choice!!!... Try again");
                        screen.WaitAndClear();
                        break;
                }
            }

        }


        private void SaveUser(Users obj)
        {
            Console.WriteLine();
            screen.NormalPrint("Enter new username: ");
            var uName = Console.ReadLine();
            if (GetUserObject(uName) != null)
            {
                screen.RedPrint("Username already exists!");
                return;
            }
            obj.UserName = uName;
            screen.NormalPrint("Enter Name:- ");
            obj.Name = Console.ReadLine();
            screen.NormalPrint("Enter password:- ");
            var pass = screen.ReadPassword();
            obj.Password = pass;
            fullUsers.Add(obj);
            screen.SuccessPrint("Data Added");

        }
        Users GetUserObject(string uName)
        {
            foreach (var user in fullUsers)
            {
                if (uName == user.UserName)
                {
                    return user;
                }
            }
            return null;
        }
        internal void UpdateUser()
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("UPDATE USER DETAILS");
            screen.PrintLine();
            Console.Write("\n\n\t\tEnter the username to update: ");
            var uName = Console.ReadLine();
            if (GetUserObject(uName) == null)
            {
                screen.RedPrint("User doesn't exist!");
                return;
            }
            Users upUser = GetUserObject(uName);
            //SaveUser(upUser);
            UpdateOwnDetails(upUser);
        }



        internal void ViewAllUsers()
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("USER DATABASE");
            screen.PrintLine();
            Console.WriteLine("\n\n");
            screen.PrintLine();
            screen.PrintRow($"Name", "Username", "Designation");
            var res = fullUsers.OrderBy(m => m.Designation).ThenBy(m => m.Name).Distinct();
            foreach (var user in res)
            {
                user.DisplayDetails();
            }
            screen.PrintLine();
        }
        internal void DeleteUser()
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("DELETE USER MENU");
            screen.PrintLine();
            Console.Write("\n\n\t\tEnter the username to delete: ");
            var uName = Console.ReadLine();
            if (GetUserObject(uName) == null)
            {
                screen.RedPrint("\n\tUser doesn't exist!");
                return;
            }
            Users delUser = GetUserObject(uName);
            fullUsers.Remove(delUser);
        }

        //internal void UpdateOwnDetails(Users userObj)
        //{
        //    screen.ClearAndNewLine();
        //    screen.PrintLine();
        //    screen.PrintRow("UPDATE YOUR DETAILS");
        //    screen.PrintLine();
        //    screen.NormalPrint("Change username: ");
        //    userObj.UserName = Console.ReadLine();
        //    screen.NormalPrint("Change password: ");
        //    userObj.Password = Console.ReadLine();

        //    screen.SuccessPrint("Details updated");
        //}
        internal void UpdateOwnDetails(Users userObj)
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("UPDATE YOUR DETAILS");
            screen.PrintLine();
            screen.NormalPrint("Change username? (Y/N): ");
            screen.ChoicePrint();
            string ch = Console.ReadLine().ToLower();
            int f = 0;
            switch (ch)
            {
                case "y":
                    screen.NormalPrint("Enter new username: ");
                    var uName = Console.ReadLine();
                    if (GetUserObject(uName) != null)
                    {
                        screen.RedPrint("Can't Change Username... Username already exists!");
                        break;
                    }
                    userObj.UserName = uName;
                    f = 1;
                    break;
                case "n":
                    break;
                default:
                    screen.RedPrint("Invalid choice...Try again...");
                    screen.WaitAndClear();
                    UpdateOwnDetails(userObj);
                    break;

            }
            if (f == 1)
            {
                screen.SuccessPrint("Username updated");
                screen.WaitAndClear();
            }

            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("UPDATE YOUR DETAILS");
            screen.PrintLine();
            f = 0;
            screen.NormalPrint("Change Name? (Y/N): ");
            screen.ChoicePrint();
            ch = Console.ReadLine().ToLower();
            switch (ch)
            {
                case "y":
                    screen.NormalPrint("Enter new name:- ");
                    var name = Console.ReadLine();
                    userObj.Name = name;
                    f = 1;
                    break;
                case "n":
                    break;
                default:
                    screen.RedPrint("Invalid choice...Try again...");
                    screen.WaitAndClear();
                    break;

            }
            if (f == 1)
            {
                screen.SuccessPrint("Name updated");
                screen.WaitAndClear();
            }
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("UPDATE DETAILS");
            screen.PrintLine();
            screen.NormalPrint("Change password? (Y/N): ");
            screen.ChoicePrint();
            ch = Console.ReadLine().ToLower();
            switch (ch)
            {
                case "y":
                    screen.NormalPrint("Enter new password:- ");
                    var pass = screen.ReadPassword();
                    userObj.Password = pass;
                    break;
                case "n":
                    return;
                default:
                    screen.RedPrint("Invalid choice...Try again...");
                    screen.WaitAndClear();
                    return;

            }
            screen.SuccessPrint("Password updated");
        }




        #region StudentOperations
        internal void StudentOperations(string ch)
        {
            screen.ClearAndNewLine();
            switch (ch)
            {
                case "1":
                    screen.PrintLine();
                    screen.PrintRow("ADD A NEW STUDENT: ");
                    screen.PrintLine();
                    var student = new Student();
                    SaveUser(student);
                    break;
                case "2":
                    screen.PrintLine();
                    screen.PrintRow("UPDATE STUDENT MENU");
                    screen.PrintLine();
                    Console.Write("\n\n\t\tEnter the username to update details: ");
                    var uName = Console.ReadLine();
                    var up = fullUsers.Where(m => m.Designation == Designation.Student).Distinct();
                    bool done = false;
                    foreach (var item in up)
                    {
                        if (uName == item.UserName)
                        {
                            done = true;
                            Users upUser = GetUserObject(uName);
                            UpdateOwnDetails(upUser);
                            break;
                        }
                    }
                    if (!done)
                        screen.RedPrint("User doesn't exist!");
                    break;
                case "3":
                    screen.PrintLine();
                    screen.PrintRow("DELETE STUDENT MENU");
                    screen.PrintLine();
                    screen.NormalPrint("Enter the username to delete: ");
                    uName = Console.ReadLine();
                    var del = fullUsers.Select(m => m).Where(m => m.Designation == Designation.Student).Distinct();
                    done = false;
                    foreach (var item in del)
                    {
                        if (uName == item.UserName)
                        {
                            done = true;
                            fullUsers.Remove(item);
                            screen.SuccessPrint("Student Removed");
                            break;
                        }
                    }
                    if (!done)
                        screen.RedPrint("User doesn't exist!");

                    break;
                case "4":
                    screen.PrintLine();
                    screen.PrintRow("DISPLAYING STUDENTS");
                    screen.PrintLine();
                    screen.PrintRow($"Name", "Username", "Designation");
                    var res = fullUsers.Select(m => m).Where(m => m.Designation == Designation.Student).OrderBy(m => m.Name).Distinct();
                    foreach (var user in res)
                    {
                        user.DisplayDetails();
                    }
                    screen.PrintLine();
                    break;

                case "5":
                    screen.WaitAndClear();
                    return;
                default:
                    screen.RedPrint("Invalid choice");
                    break;

            }
        }  
        #endregion//Student operations for librarian

        #endregion


        #region BookManagement
        #region AddBooks
        internal void AddBooks()
        {

            try
            {
                screen.ClearAndNewLine();
                screen.PrintLine();
                screen.PrintRow("ADD A BOOK");
                screen.PrintLine();
                Console.WriteLine();
                var book = new Book();
                screen.NormalPrint("Enter name of the book: ");
                string bName = Console.ReadLine();
                screen.NormalPrint("Enter the number of books to be added: ");
                int c = int.Parse(Console.ReadLine());
                if (c <= 0)
                    throw new WrongInputException(c.ToString());
                foreach (var item in fullBooks)
                {
                    if (item.Name == bName)         //Check for existing book
                    {
                        screen.SuccessPrint("Book added");
                        item.Count += c;
                        return;
                    }

                }
                book.Count += c;
                book.Name = bName;
                screen.NormalPrint("Enter author name: ");
                book.Author = Console.ReadLine();
                fullBooks.Add(book);
                screen.SuccessPrint("Book added");
            }
            catch (WrongInputException e)
            {
                screen.RedPrint(e.Message);
            }
            catch (FormatException)
            {
                screen.RedPrint("Wrong Input Format...Try Again...");
            }

        }
        #endregion
        #region DeleteBooks
        internal void DeleteBooks()
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("DELETE A BOOK");
            screen.PrintLine();
            Console.WriteLine();
            Console.Write("\n\t\tEnter name of the book: ");
            var bName = Console.ReadLine();
            foreach (var book in fullBooks)
            {
                if (bName == book.Name)
                {
                    book.Count--;
                    if (book.Count == 0)
                        fullBooks.Remove(book);
                    screen.SuccessPrint("Book is removed");
                    //screen.WaitAndClear();
                    return;
                }
            }
            screen.RedPrint("Book not found");

        }
        #endregion
        #region ViewBooks
        internal void ViewAllBooks()
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("BOOKS IN THE LIBRARY");
            screen.PrintLine();
            Console.WriteLine("\n\n\n");
            screen.PrintLine();
            screen.PrintRow($"Title", "Author", "Status", "Student");
            var fb = fullBooks.Distinct().OrderBy(m => m.Name);
            foreach (var book in fb)
            {
                book.DisplayDetails();
            }
            screen.PrintLine();
        }
        #endregion
        //internal void SearchBook()
        //{
        //    screen.ClearAndNewLine();
        //    screen.PrintLine();
        //    screen.PrintRow("SEARCH A BOOK");
        //    screen.PrintLine();
        //    Console.WriteLine("\n\n");
        //    screen.NormalPrint("Enter name of the book in the library: ");
        //    var bName = Console.ReadLine();
        //    Console.WriteLine("\n\n");
        //    foreach (var book in fullBooks)
        //    {
        //        if (bName == book.Name)
        //        {
        //            screen.PrintLine();
        //            screen.PrintRow($"Title", "Author", "Status", "Count");
        //            book.DisplayDetails();
        //            screen.PrintLine();
        //            //BookOperations(book);
        //            //screen.WaitAndClear();
        //            return;
        //        }
        //    }
        //    screen.RedPrint("Book doesn't exist");
        //}
        #region SearchBooks
        internal Book SearchBook()
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("SEARCH A BOOK");
            screen.PrintLine();
            Console.WriteLine("\n\n");
            screen.NormalPrint("Enter name of the book in the library: ");
            var bName = Console.ReadLine();
            Console.WriteLine("\n\n");
            foreach (var book in fullBooks)
            {
                if (bName == book.Name)
                {
                    screen.PrintLine();
                    screen.PrintRow($"Title", "Author", "Status", "Student");
                    book.DisplayDetails();
                    screen.PrintLine();
                    //BookOperations(book);
                    //screen.WaitAndClear();
                    return book;
                }
            }
            screen.RedPrint("Book doesn't exist");
            return null;
        }
        #endregion
        #region BookOperations
        internal void BorrowRequests()
        {
            int f = 0;
            foreach (var book in fullBooks)
            {
                string ch;

                if (book.Status == EnumBookStatus.BorrowRequested)
                {
                    f = 1;
                    screen.ClearAndNewLine();
                    screen.PrintLine();
                    screen.PrintRow($"Title", "Author", "Status", "Count");
                    book.DisplayDetails();
                    screen.PrintLine();
                    Console.WriteLine();
                    screen.NormalPrint("Approve Request? y/n");
                    screen.ChoicePrint();
                    ch = Console.ReadLine();
                    if (ch == "y")
                    {

                        book.Status = EnumBookStatus.Borrowed;
                    }
                    else
                    {
                        continue;
                    }
                }

            }
            if (f == 0)
            {
                screen.RedPrint("No book requests");
                screen.WaitAndClear();
            }
        }
        internal void ReserveRequests()
        {
            int f = 0;
            foreach (var book in fullBooks)
            {
                foreach (var item in fullUsers)
                {
                    if (item.Designation != Designation.Student)
                        continue;
                    else if (item?.BookName == null)
                        continue;
                    string ch;
                    if (book.ReserveRequested == true && item.BookName == book.Name)
                    {
                        f = 1;
                        screen.ClearAndNewLine();
                        screen.PrintLine();
                        screen.PrintRow($"Title", "Author", "Status", "Student");
                        book.DisplayDetails();
                        screen.PrintLine();
                        Console.WriteLine();
                        screen.NormalPrint("Approve Request? y/n");
                        screen.ChoicePrint();
                        ch = Console.ReadLine();
                        if (ch == "y")
                        {
                            book.Status = EnumBookStatus.Reserved;

                            book.ReserveRequested = false;

                        }
                        else
                            continue;
                    }


                }
            }
            if (f == 0)
                screen.RedPrint("No more reserve requests!!!");
        }
        private void BorrowToReserved()
        {
            foreach (var book in fullBooks)
            {
                foreach (var item in fullUsers)
                {
                    if (item.Designation != Designation.Student)
                        continue;
                    else if (item?.BookName == null)
                        continue;
                    if (book.Status == EnumBookStatus.Reserved && item.BookName == book.Name)
                    {
                        book.Status = EnumBookStatus.Borrowed;
                        book.StudentName = item.Name;
                        screen.SuccessPrint("Issued to reserved student");

                    }
                }
            }
        }
        internal void Borrow(Users obj)
        {
            obj = (Student)obj;
            var book = SearchBook();
            string ch;
            if (book != null)
            {
                if (book.Status == EnumBookStatus.Available || book.Status == EnumBookStatus.Reserved)
                {
                    screen.NormalPrint("Confirm Borrow Request (y/n)");
                    screen.ChoicePrint();
                    ch = Console.ReadLine();

                    if (ch == "y")
                    {
                        book.Status = EnumBookStatus.BorrowRequested;
                        book.StudentName = obj.Name;
                        obj.Borrowed = true;
                        screen.SuccessPrint("Book requested");
                        screen.WaitAndClear();
                        return;
                    }
                }

                else
                {
                    screen.RedPrint("Book already Borrowed/Requested");
                    Console.Write("\n\t\tReserve the book (Y/N)? ");
                    var reserve = Console.ReadLine();
                    screen.NormalPrint("Checking the current status of book ...");
                    if (reserve.ToLower() == "n")
                        return;

                    //if (book.Status==EnumBookStatus.BorrowRequested)
                    //{
                    //    screen.RedPrint("Book already requested by another student");
                    //    return;
                    //}

                    else if (book.Status == EnumBookStatus.Reserved && book.ReserveRequested == true)
                    {

                        screen.RedPrint("Book already reserved...Try again later");
                        return;
                    }
                    else if (reserve.ToLower() == "y" && book.StudentName != obj.Name)
                    {
                        book.ReserveRequested = true;
                        obj.BookName = book.Name;
                        screen.SuccessPrint("Reserve Requested");
                    }
                    else
                        screen.RedPrint("Cannot Borrow/ Reserve until you return the book");

                }
            }
            else
            {
                screen.RedPrint("Book not found!!! Try again");
            }

        }
        internal void Return(Users obj)
        {
            var book = SearchBook();
            if (book != null)
            {
                if (book.Status == EnumBookStatus.Borrowed && obj.Borrowed == true)
                {
                    obj.Borrowed = false;
                    book.Status = EnumBookStatus.Available;
                    book.StudentName = default;
                    screen.SuccessPrint("Returned");
                    return;
                }


                else if (book.Status == EnumBookStatus.BorrowRequested)
                    screen.RedPrint("Cannot Return borrow requested book");
                else if (book.Status == EnumBookStatus.Reserved && obj.BookName == book.Name)
                    screen.RedPrint("Cannot Return the book you reserved");
                else
                {
                    BorrowToReserved();
                }


            }
            else
            {
                screen.RedPrint("Book not found!!! Try again");
            }
        }

        #endregion

        //private void BookOperations(Book book)
        //{
        //    Console.WriteLine("\n\n\n");
        //    screen.PrintRow("1. Borrow", "2. Return", "3. Go Back");
        //    Console.WriteLine();
        //    screen.ChoicePrint();
        //    var choice = Console.ReadLine();
        //    switch (choice)
        //    {
        //        case "1":
        //            if (book.Count == 1)
        //            {
        //                book.Status = EnumBookStatus.Borrowed;
        //                book.Count--;
        //                screen.SuccessPrint("Borrow");
        //                return;
        //            }
        //            else if (book.Count == 0)
        //            {
        //                screen.RedPrint("This book currently unavailable.");
        //                break;
        //            }
        //            book.Count--;
        //            screen.SuccessPrint("Borrowed");
        //            return;
        //        case "2":
        //            screen.SuccessPrint("Returned");
        //            if (book.Status == EnumBookStatus.Reserved)
        //            {
        //                book.Status = EnumBookStatus.Borrowed;
        //                return;
        //            }
        //            book.Status = EnumBookStatus.Available;
        //            book.Count++;
        //            return;
        //        case "3":
        //            //screen.WaitAndClear();
        //            return;
        //        default:
        //            screen.RedPrint("Invalid choice!!! Try again");
        //            return;
        //    }
        //    if (book.Status == EnumBookStatus.Reserved)
        //    {
        //        screen.RedPrint("Book already reserved...Try again later");
        //        return;
        //    }
        //    Console.Write("\n\t\tReserve the book (Y/N)? ");
        //    var reserve = Console.ReadLine();
        //    if (reserve.ToLower() == "y")
        //    {
        //        book.Status = EnumBookStatus.Reserved;
        //        screen.SuccessPrint("Reserved");
        //    }

        //}

        #endregion




    }
}
