using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem
{
    public enum Designation
    {
        Admin,
        Librarian,
        Student
    }
   public enum EnumBookStatus
    {
        Available,
        BorrowRequested,
        Borrowed,
        Reserved
    }
}
