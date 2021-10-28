using LibraryManagementSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public abstract class Users
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string BookName { get; set; }
        public bool Borrowed { get; set; }
        public abstract Designation Designation { get; set; }
        Screen screen = new Screen();
        public void DisplayDetails()
        {
            screen.PrintLine();
            screen.PrintRow($"{this.Name}",$"{this.UserName}",$"{this.Designation}");
        }
        public abstract void Dashboard(List<Users> users, List<Book> books);
    }
}
