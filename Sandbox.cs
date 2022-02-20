using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TestProject1
{
    internal class Sandbox
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello world");
            Console.WriteLine("Here you can write console prints to test your implementation outside the testing environment");

            Random R1 = new Random();

            Stack<int> testStack = new Stack<int>();

            for (int i = 0; i < 5; i++)
            {
                testStack.Push(R1.Next(1, 100));
            }

            //TestMethods.GetNextGreaterValue(testStack);

            Console.WriteLine("Source elements");
            foreach (int stackElements in testStack)
            {

                Console.WriteLine("\n " + stackElements);
            }

            Console.WriteLine("Result: ");
            foreach (int item in TestMethods.GetNextGreaterValue(testStack))
            {
                Console.WriteLine("\n " + item);
            }

        }
    }
}