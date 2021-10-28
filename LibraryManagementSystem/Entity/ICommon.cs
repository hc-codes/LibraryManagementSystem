using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagementSystem.Entity
{
    public interface ICommon
    {
         void ManageBooks(List<Users> users, List<Book> books);
         void UpdateDetails(Users obj, Actions action);

    }
}
