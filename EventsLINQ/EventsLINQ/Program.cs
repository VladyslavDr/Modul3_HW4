using System;

namespace EventsLINQ
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var task1 = new Task1();

            task1.Run(() => Console.WriteLine(task1.Res(2, 4)));

            var task2 = new Task2();

            task2.Run();
        }
    }
}
