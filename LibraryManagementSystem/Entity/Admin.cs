using LibraryManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public class Admin : Users, ICommon
    {
        Screen screen = new Screen();
        public override Designation Designation { get; set; } = Designation.Admin;
        private List<Users> users;
        private List<Book> books;

        public override void Dashboard(List<Users> user, List<Book> book)
        {

            users = user;
            books = book;
            bool logout = false;
            var action = new Actions(users, books);
            while (!logout)
            {
                screen.ClearAndNewLine();
                screen.PrintLine();
                screen.PrintRow("Welcome to Admin Section");
                screen.PrintLine();
                screen.NormalPrint("1. Manage Users", "2. Manage Books", "3. Update your details");
                screen.RedPrint("4. Logout");
                screen.ChoicePrint();
                string ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        ManageUser( action);
                        break;
                    case "2":
                        ManageBooks(users, books);
                        break;
                    case "3":
                        UpdateDetails(this, action);
                        break;
                    case "4":
                        screen.SuccessPrint("Logged out");
                        logout = true;
                        break;
                    default:
                        screen.RedPrint("Invalid Choice... Try Again...");
                        break;
                }

            }
        }

        public void UpdateDetails(Users obj, Actions action)
        {
            action.UpdateOwnDetails(obj);
            screen.WaitAndClear();
        }
        private void ManageUser(Actions action)
        {
            bool exit = false;
            while (!exit)
            {
                ManageUserMenu();
                screen.ChoicePrint();
                string ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        action.AddUser();
                        break;
                    case "2":
                        action.UpdateUser();
                        break;
                    case "3":
                        action.DeleteUser();
                        break;
                    case "4":
                        action.ViewAllUsers();
                        break;
                    case "5":
                        exit = true;
                        break;
                    default:
                        screen.RedPrint("Invalid choice!!!... Try again");
                        break;
                }
                screen.WaitAndClear();

            }
        }

        public void ManageBooks(List<Users> users, List<Book> books)
        {
            Actions action = new Actions(users, books);
            bool exit = false;
            while (!exit)
            {
                ManageBooksMenu();
                screen.ChoicePrint();
                string ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        action.AddBooks();
                        break;
                    case "2":
                        action.DeleteBooks();
                        break;
                    case "3":
                        action.ViewAllBooks();
                        break;
                    case "4":
                        action.SearchBook();
                        break;
                    case "7":
                        exit = true;
                        break;
                    case "5":
                        action.BorrowRequests();
                        break;
                    case "6":
                        action.ReserveRequests();
                        break;
                    default:
                        screen.RedPrint("Invalid choice!!! Try again...");
                        break;
                }
                screen.WaitAndClear();
            }

        }
        private void ManageBooksMenu()
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("Welcome to manage book window");
            screen.PrintLine();
            screen.NormalPrint("1. Add a book", "2. Delete a book", "3. View all books", "4. Search a book","5. View Requests","6. View Reserve Requests");
            screen.RedPrint("7. Go back");
            Console.WriteLine();
            Console.ResetColor();
        }
        private void ManageUserMenu()
        {
            screen.ClearAndNewLine();
            screen.PrintLine();
            screen.PrintRow("Welcome to manage user window");
            screen.PrintLine();
            screen.NormalPrint("1. Press 1 to Add new user", "2. Press 2 to Update a user", "3. Press 3 to Delete a user", "4. Press 4 to View all users");
            screen.RedPrint("5. Press 5 to Go back");
            Console.WriteLine();
            Console.ResetColor();
        }
    }


}
