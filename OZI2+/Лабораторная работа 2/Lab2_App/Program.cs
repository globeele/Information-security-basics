using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lib_Lab_2;

namespace Lab2_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string getString = Console.ReadLine();
            string key = Console.ReadLine();

            ExsponentialCipher exsponentialCipher = new ExsponentialCipher();
            int[] Encode = exsponentialCipher.encode(getString, key);
            string Decode = exsponentialCipher.decode(Encode, key);

            Console.WriteLine(Decode);
            Console.ReadKey();
        }
    }
}
