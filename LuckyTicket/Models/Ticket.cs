using System;

namespace LuckyTicket.Models
{
    abstract class Ticket
    {
        private readonly int ticketNumber;

        abstract public bool IsLucky(int ticketNumber);

        public Ticket(int ticketNumber)
        {
            if (ticketNumber < 0)
            {
                throw new ArgumentException("Negative ticket number!");
            }

            this.ticketNumber = ticketNumber;
        }

        public int GetLuckyCount()
        {
            int count = 0;

            for (int i = 0; i < 999999; i++)
            {
                if (IsLucky(i))
                {
                    ++count;
                }
            }

            return count;
        }

        public bool IsLucky()
        {
            return IsLucky(this.ticketNumber);
        }
    }
}
