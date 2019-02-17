using System;
using System.Collections.Generic;
using System.Linq;

namespace Socks
{
    public class Program
    {
        public static void Main()
        {
            int[] leftInts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] rightInts = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Queue<int> rightSocks = new Queue<int>(rightInts);
            Stack<int> leftSocks = new Stack<int>();
            Queue<int> result= new Queue<int>();

            for (int i = 0; i < leftInts.Length; i++)
            {
                leftSocks.Push(leftInts[i]);
            }

            while (leftSocks.Any() && rightSocks.Any())
            { 

                if (rightSocks.Peek() == leftSocks.Peek())
                {
                    rightSocks.Dequeue();
                    leftSocks.Reverse();
                    leftSocks.Push(leftSocks.Pop() + 1);
                    rightSocks.Reverse();
                }
                else if (leftSocks.Peek() < rightSocks.Peek())
                {
                    leftSocks.Pop();
                }
                else if (leftSocks.Peek() > rightSocks.Peek())
                {
                    result.Enqueue(leftSocks.Pop() + rightSocks.Dequeue());
                }
            }

            Console.WriteLine(result.Max());
            Console.WriteLine(string.Join(" ",result));
        }
    }
}
