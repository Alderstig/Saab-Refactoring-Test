using System.Collections.Generic;
using System.Linq;
using TicketManagementSystem.Interfaces;

namespace TicketManagementSystem
{
    public static class TicketRepository
    {
        private static readonly List<Ticket> Tickets = new List<Ticket>();

        public static int CreateTicket(Ticket ticket)
        {
            var currentHighestTicket = Tickets.Any() ? Tickets.Max(i => i.Id) : 0;
            var id = currentHighestTicket + 1;
            ticket.Id = id;

            Tickets.Add(ticket);

            return id;
        }

        public static void UpdateTicket(Ticket ticket)
        {
            var outdatedTicket = Tickets.FirstOrDefault(t => t.Id == ticket.Id);

            if (outdatedTicket != null)
            {
                Tickets.Remove(outdatedTicket);
                Tickets.Add(ticket);
            }
        }

        public static Ticket GetTicket(int id)
        {
            return Tickets.FirstOrDefault(a => a.Id == id);
        }
    }
}
