using System;
using System.Threading.Tasks;

namespace HTTPClient
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            Starter starter = new Starter();
            Console.WriteLine("Start");
            await starter.Run();
            Console.WriteLine("End");
        }
    }
}
