using System;

namespace project_unad_mayelin
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, user access successful!");

            Handler handler = new Handler();
            handler.init();
        }
    }
}
