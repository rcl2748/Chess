using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(get('h'));
            Console.WriteLine((int)'1');
            Console.Read();
        }

        private static int get(char c)
        {
            return c - 96;
        }
    }
}
