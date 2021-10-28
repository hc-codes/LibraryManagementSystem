using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
   public class Librarian: Users,ICommon
    {
        ICommon admin=new Admin();
        private List<Users> fullusers;
        private List<Book> fullbooks;
        public override Designation Designation { get; set; } = Designation.Librarian;
        Screen screen = new Screen();
        public override void Dashboard(List<Users> users, List<Book> books)
        {
            fullusers = users;
            fullbooks = books;
            var action = new Actions(fullusers, fullbooks);
            bool logout = false;
            while (!logout)
            {
                screen.PrintLine();
                screen.PrintRow("Welcome to Librarian Section");
                screen.PrintLine();
                screen.NormalPrint("1. Manage Students", "2. Manage Books","3. Update your details");
                screen.RedPrint("4. Logout");
                screen.ChoicePrint();
                string ch = Console.ReadLine();
                switch (ch)
                {
                    case "1":
                        ManageStudents(action);
                        break;
                    case "2":
                        ManageBooks(users, books);
                        break;
                    case "3":
                        UpdateDetails(this,action);
                        break;
                    case "4":
                        screen.SuccessPrint("Logged out");
                        logout = true;
                        break;
                    default:
                        screen.RedPrint("Invalid Input... Try Again...");
                        break;
                }

            }
        }

        public void UpdateDetails( Users obj,Actions action)
        {
            //admin.UpdateDetails(user, books, obj,action);
            admin.UpdateDetails(obj, action);

        }

        private void ManageStudents(Actions action)
        {
            bool exit = false;
            while (!exit)
            {
                screen.ClearAndNewLine();
                ManageStudentsMenu();
                screen.ChoicePrint();
                string ch = Console.ReadLine();
                if (ch == "5")
                    exit = true;
                action.StudentOperations(ch);
               // screen.WaitAndClear();
            }
        }
        public void ManageBooks(List<Users> user, List<Book> books)
        {
            admin.ManageBooks(user, books);
        }
        private void ManageStudentsMenu()
        {
            screen.PrintLine();
            screen.PrintRow("Welcome to manage student window");
            screen.PrintLine();
            screen.NormalPrint("1. Press 1 to Add new student", "2. Press 2 to Update a student", "3. Press 3 to Delete a student", "4. Press 4 to View all studnets");
            screen.RedPrint("5. Press  to Go back");
            Console.ResetColor();
        }
    }
}
