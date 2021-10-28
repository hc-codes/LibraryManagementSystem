using LibraryManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace LibraryManagementSystem
{
    class LoginPanel
    {

        static List<Users> fullUsers = new List<Users>(); 
        static List<Book> books = new List<Book>();
        Screen screen = new Screen();

        #region LoginMenu
        public void LoginMenu()
        {
            //Default users in the list
            fullUsers.Add(new Admin { Name = "Admin", UserName = "admin", Password = "admin" });
            fullUsers.Add(new Librarian { Name = "Librarian1", UserName = "lib", Password = "lib" });
            fullUsers.Add(new Student { Name = "student1", UserName = "s1", Password = "s1" });
            fullUsers.Add(new Student { Name = "student2", UserName = "s2", Password = "s2" });
            fullUsers.Add(new Student { Name = "student3", UserName = "s3", Password = "s3" });
            books.Add(new Book { Name = "b1", Author = "b1", Status = EnumBookStatus.Available, Count = 1 });
            books.Add(new Book { Name = "b2", Author = "b2", Status = EnumBookStatus.Available, Count = 1 });
            books.Add(new Book { Name = "b3", Author = "b3", Status = EnumBookStatus.Available, Count = 1 });
            while (true)
            {
                Thread.Sleep(1500);
                screen.ClearAndNewLine();
                screen.PrintLine();
                screen.PrintRow("Login Page");
                screen.PrintLine();
                Users currentUser = default;
                Console.Write("\n\n\n\n\n\t\t\t\tEnter Username:- ");
                string uname = Console.ReadLine();
                Console.WriteLine();
                bool exist = false;
                foreach (var user in fullUsers)
                {
                    if (uname == user.UserName)
                    {
                        currentUser = user;
                        exist = true;
                        break;
                    }


                }
                if (!exist)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\tUser Does not exists...");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("\n\t\t\t\tPassword:- ");
                    var pass = screen.ReadPassword();
                    Console.ResetColor();
                    bool valid = false;
                    if (pass == currentUser.Password)
                    {
                        valid = true;
                    }

                    if (!valid)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n\n\tInvalid Password...\n\n\tTry Again...");
                        Console.ResetColor();
                    }
                    else
                    {
                        screen.SuccessPrint("Logged in");
                        screen.WaitAndClear();
                        currentUser.Dashboard(fullUsers, books);
                    }

                }

            }
        } 
        #endregion

    }
}
