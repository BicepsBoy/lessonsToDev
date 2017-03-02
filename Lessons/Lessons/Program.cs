using System;
using System.Threading;
using PlayerLib;

namespace Lessons
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Super player from Andrew Alp!!!\nTell me, what you want to do?");
            Player player = new Player();
            player.Execute();
            Console.WriteLine("Thank you for using my player :)");
            Thread.Sleep(1000);
        }
    }
}