using LuckyTicket.Implementation;
using LuckyTicket.Logics;
using LuckyTicket.Models;
using System;

namespace LuckyTicket
{
    class Program
    {
        static void Main(string[] args)
        {

            FileParser file = new FileParser("t.txt");
            file.GetLuckyType();
            Ticket ticket = new PitersbergTicket(000000);
            var b = ticket.IsLucky();
            var c = ticket.GetLuckyCount();

            Ticket ticket1 = new MoscowTicket(000000);
            var b1 = ticket1.IsLucky();
            var c1 = ticket1.GetLuckyCount();
            Console.WriteLine("Hello World!");
        }
    }
}
