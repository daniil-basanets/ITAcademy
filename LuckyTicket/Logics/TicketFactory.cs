using System;
using LuckyTicket.Models;
using LuckyTicket.Implementation;

namespace LuckyTicket.Logics
{
    static class TicketFactory
    {
        public static Ticket Build(LuckyType luckyType, int ticketNumber = 0)
        {
            switch (luckyType)
            {
                case LuckyType.Petersberg:
                    return new PitersbergTicket(ticketNumber);
                case LuckyType.Moscow:
                    return new MoscowTicket(ticketNumber);
                default:
                    throw new ArgumentException("Unknown LuckyType!");
            }
        }
    }
}
