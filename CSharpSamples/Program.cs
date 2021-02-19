using CSharpSamples.Models;
using System;

namespace CSharpSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassBase parent = new ClassChild();
            parent.Print();
            parent.Print2();

            Console.WriteLine();

            ClassChild child = parent as ClassChild;
            child.Print();
            child.Print2();

            Console.WriteLine("Hello World!");

            var key = Console.ReadKey();
        }
    }
}
