using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManagementSystem.Interfaces
{
    public interface ITicketService
    {
        int CreateTicket(string title, Priority prio, string userName, string desc, DateTime dt, bool isPayingCustomer);
        void AssignTicket(int id, string username);
    }
}
