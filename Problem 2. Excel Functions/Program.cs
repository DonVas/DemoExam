using System;
using System.Linq;

namespace Problem_2._Excel_Functions
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());                
            string[][] table = new string[rows][];

            for (int i = 0; i < rows; i++)
            {                                 
                    table[i]= Console.ReadLine()
                        .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                        .ToArray();
            }

            string[] command = Console.ReadLine()
                .Split()
                .ToArray();

            string header = command[1];
            string[] headerRow = table[0];
            int index = Array.IndexOf(table[0], header);

            if (command[0] == "hide")
            {              
                table.Where((x, i) => Array.IndexOf(x, i) != index);

                for (int row = 0; row < table.Length; row++)
                {
                    Console.WriteLine(string.Join(" | ", table[row]
                        .Where((x, i) => i != index).ToArray()));
                }

            }
            else if (command[0] == "sort")
            {
                table = table.OrderBy(x => x[index]).ToArray();
                
                Console.WriteLine(string.Join(" | ", headerRow));

                foreach (var row in table)
                {
                    if (row != headerRow)
                    {
                        Console.WriteLine(string.Join(" | ", row));
                    }
                }
            }
            else if(command[0] == "filter")
            {
                string value = command[2];

                Console.WriteLine(string.Join(" | ", headerRow));

                for (int i = 1; i < table.Length; i++)
                {
                    if (table[i][index] == value)
                    {
                        Console.WriteLine(string.Join(" | ", table[i]));
                    }
                }
            }
        }
    }
}
