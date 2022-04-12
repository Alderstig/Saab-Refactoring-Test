using EmailService;
using System;
using TicketManagementSystem.Interfaces;

namespace TicketManagementSystem
{
    public enum Priority
    {
        High,
        Medium,
        Low
    }
    public class TicketService : ITicketService
    {
        public bool PriorityRaised { get; set; } = false;
        public int CreateTicket(string title, Priority prio, string userName, string desc, DateTime dt, bool isPayingCustomer)
        {
            if (title == null || desc == null || title == "" || desc == "") throw new InvalidTicketException("Title or description were null");

            User user = GetUserByUserName(userName);

            if (user == null) throw new UnknownUserException("User " + userName + " not found");

            if (dt < DateTime.UtcNow - TimeSpan.FromHours(1)) prio = SetPriority(prio, true);

            if ((title.Contains("Crash") || title.Contains("Important") || title.Contains("Failure")) && !PriorityRaised) prio = SetPriority(prio, false);

            if (prio == Priority.High)
            {
                var emailService = new EmailServiceProxy();
                emailService.SendEmailToAdministrator(title, userName);
            }

            double price = 0;
            User accountManager = null;

            if (isPayingCustomer)
            {
                accountManager = new UserRepository().GetAccountManager();
                if (prio == Priority.High)
                {
                    price = 100;
                }
                else
                {
                    price = 50;
                }
            }

            var ticket = new Ticket()
            {
                Title = title,
                AssignedUser = user,
                Priority = prio,
                Description = desc,
                Created = dt,
                PriceDollars = price,
                AccountManager = accountManager
            };

            var id = TicketRepository.CreateTicket(ticket);

            return id;
        }

        public void AssignTicket(int id, string username)
        {
            User user = GetUserByUserName(username);

            if (user == null) throw new UnknownUserException("User not found");

            var ticket = TicketRepository.GetTicket(id);

            if (ticket == null) throw new ApplicationException("No ticket found for id " + id);

            ticket.AssignedUser = user;

            TicketRepository.UpdateTicket(ticket);
        }

        private User GetUserByUserName(string userName)
        {
            User user = null;
            using (var ur = new UserRepository())
            {
                if (userName != null) user = ur.GetUser(userName);
            }

            return user;
        }
        private Priority SetPriority(Priority prio, bool raisePrio)
        {
            if (prio == Priority.Low)
            {
                prio = Priority.Medium;
                if (raisePrio) PriorityRaised = true;
            }
            else if (prio == Priority.Medium)
            {
                prio = Priority.High;
                if(raisePrio) PriorityRaised = true;
            }

            return prio;
        }
    }
}
