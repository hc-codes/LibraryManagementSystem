using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
    public class Student : Users
    {

        private List<Book> fullBooks;

        Screen screen = new Screen();
        public override Designation Designation { get; set; } = Designation.Student;

        public override void Dashboard(List<Users> users, List<Book> books)
        {
            fullBooks = books;

            var action = new Actions(users, fullBooks);
            var logout = false;
            while (!logout)
            {
                Console.Clear();
                Console.WriteLine();
                screen.PrintLine();
                screen.PrintRow("Welcome to Student Menu!");
                screen.PrintLine();
                screen.NormalPrint("1. View all books", "2. Search a book", "3. Borrow a book", "4. Return a book", "5. Update your own details");
                screen.RedPrint("6. Log out");
                Console.WriteLine();
                screen.ChoicePrint();
                var choice = Console.ReadLine();
                
                switch (choice)
                {
                    case "1":
                      
                        action.ViewAllBooks();
                        Console.WriteLine();
                        break;
                    
                    case "2":
                        action.SearchBook();
                        Console.WriteLine();
                        break;
                    case "3":
                        action.Borrow(this);
                        break;
                    case "4":
                        action.Return(this);
                        break;

                    case "5":
                        action.UpdateOwnDetails(this);
                        break;
                    case "6":
                        logout = true;
                        screen.SuccessPrint("Logged out");
                        break;
                   
                    default:
                        break;
                }
                screen.WaitAndClear();
            }

        }
    }
   
}
//internal void UpdateOwnDetails(Users userObj)
//{
//    screen.ClearAndNewLine();
//    screen.PrintLine();
//    screen.PrintRow("UPDATE YOUR DETAILS");
//    screen.PrintLine();
//    screen.NormalPrint("Change username? (Y/N): ");
//    screen.ChoicePrint();
//    string ch = Console.ReadLine().ToLower();
//    switch (ch)
//    {
//        case "y":
//            screen.NormalPrint("Enter new username: ");
//            string uName = Console.ReadLine();
//            if (GetUserObject(uName) != null)
//            {
//                screen.RedPrint("Username already exists!");
//                return;
//            }
//            userObj.UserName = uName;
//            break;
//        case "n":
//            break;
//        default:
//            screen.RedPrint("Invalid choice...Try again...");
//            break;

//    }
//    screen.NormalPrint("Change password? (Y/N): ");
//    screen.ChoicePrint();
//    ch = Console.ReadLine().ToLower();
//    switch (ch)
//    {
//        case "y":
//            screen.NormalPrint("Change password:- ");
//            var pass = screen.ReadPassword();
//            userObj.Password = pass;
//            break;
//        case "n":
//            break;
//        default:
//            screen.RedPrint("Invalid choice...Try again...");
//            break;

//    }
//    screen.SuccessPrint("Details updated");
//}