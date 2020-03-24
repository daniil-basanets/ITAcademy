using LuckyTicket.Models;

namespace LuckyTicket.Implementation
{
    class MoscowTicket : Ticket
    {
        private readonly int ticketNumber;

        public MoscowTicket(int ticketNumber) :
         base(ticketNumber)
        {

        }

        public override bool IsLucky(int ticketNumber)
        {
            int leftPart;
            int rightPart;

            leftPart = ticketNumber % 10 + (ticketNumber / 10) % 10 + (ticketNumber / 100) % 10;
            rightPart = (ticketNumber / 1000) % 10 + (ticketNumber / 10000) % 10 + (ticketNumber / 100000) % 10;

            return leftPart == rightPart;
        }

    }
}
