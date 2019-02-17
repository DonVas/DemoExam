using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Problem_2._Excel_Functions
{
    public class Program
    {
        public static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            int cols = 0;
                
            string[][] table = new string[rows][];

            List<string>valus=new List<string>();

            for (int i = 0; i < rows; i++)
            {
                valus = Console.ReadLine()
                        .Split(", ",StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                    cols = valus.Count;
               
                table[i] = new string[cols];

                for (int j = 0; j < cols; j++)
                {                  
                    table[i][j] = valus[j];
                }
            }

            string[] command = Console.ReadLine()
                .Split()
                .ToArray();
            if (command[0] == "hide")
            {
                int indexHead = -1;
                
                string[][] result= new string[rows][];
               
                    for (int col = 0; col < cols; col++)
                    {
                        if (table[0][col] == command[1])
                        {
                            indexHead = col;
                        }
                    }

                for (int row = 0; row < rows; row++)
                {
                    result[row] = new string[cols-1];
                    int rCol = 0;
                    for (int col = 0; col < cols; col++)
                    {
                        if (indexHead!=col)
                        {
                            result[row][rCol] = table[row][col];
                            rCol++;
                        }
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    Console.WriteLine(string.Join(" | ",result[row]));
                }
                
            }
            else if (command[0] == "sort")
            {
                int indexHead = -1;
                
                    for (int col = 0; col < cols; col++)
                    {
                        if (table[0][col] == command[1])
                        {
                            indexHead = col;
                        }
                    }
                    Console.WriteLine(string.Join(" | ", table[0]));
                    string[][] modArray = new string[rows-1][];
                    for (int row = 1; row < rows; row++)
                    {
                        modArray[row - 1]=new string[cols];
                        for (int col = 0; col < cols; col++)
                        {
                            modArray[row-1][col] = table[row][col];
                        }
                    }

                var result = modArray.OrderBy(row => row[indexHead]).ToArray();
                    
                for (int row = 0; row < rows-1; row++)
                {
                    Console.WriteLine(string.Join(" | ", result[row]));
                }

            }
            else if(command[0] == "filter")
            {
                int indexHead =-1;
                int indexRow = -1;


               var res= table.Where(x => x.ToString() == command[2]);
                string[][] result = new string[rows][];
                for (int row = 0; row < rows; row++)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (table[row][col] == command[1])
                        {
                            indexHead = col;
                        }
                    }
                }

                for (int row = 0; row < rows; row++)
                {
                    if (table[row][indexHead]==command[2])
                    {
                        Console.WriteLine(string.Join(" | ", table[0]));
                        Console.WriteLine(string.Join(" | ", table[row]));
                    }
                }
            }
        }
    }
}
