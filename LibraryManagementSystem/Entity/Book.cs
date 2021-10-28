using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
   public class Book
    {
        public string Name { get; set; }
        public string Author { get; set; }
        public EnumBookStatus Status { get; set; }
        public int Count { get; set; } = 1;
        Screen screen = new Screen();
        public string StudentName { get; set; }
        public bool ReserveRequested { get; set; }
        public void DisplayDetails()
        {
            screen.PrintLine();
            screen.PrintRow($"{this.Name}",$"{this.Author}",$"{this.Status}",$"{this.StudentName}");
        }
    }   
}
