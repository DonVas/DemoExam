using System;
using System.Linq;

namespace multiArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] myJaggedArray = new int[][]
            {
                new int[] { 2, 7, 0, 4 },
                new int[] { 3, 12, 0, 6 },
                new int[] { 1, 15, 0, 7 },
                new int[] { 4, 7, 0, 8 },
                new int[] { 5, 1, 0, 9 },
            };

            Console.WriteLine(string.Join(Environment.NewLine,myJaggedArray.Select(x=>string.Join(" ",x))));
            Console.WriteLine();

            //sort by colon row[0] then row[1]
            var result = myJaggedArray
                .OrderBy(row => row[0])
                .ThenBy(row => row[1])
                .Select((row, idx) =>
                {
                    row[2] = idx;
                    return row;
                })
                .ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, result.Select(x => string.Join(" ", x))));
            Console.WriteLine();
            //remove colon i=0 ore i!=0
            int[][] newArray = myJaggedArray.Select(a => a.Where((s, i) => i != 0).ToArray()).ToArray();

            newArray=AddRow(newArray,5,new int[] {1, 5, 6, 6});
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, newArray.Select(x => string.Join(" ", x))));

            newArray = AddColumn(newArray, 2,new int[] { 1, 5, 6, 6 });
            Console.WriteLine();
            Console.WriteLine(string.Join(Environment.NewLine, newArray.Select(x => string.Join(" ", x))));
        }
        static int[][] AddRow(int[][] original,int ofset, int[] added)
        {
            int lastRow = original.Length+1;
            int lastColumn = 0;

            int[][] result = new int[lastRow][];

            int rowOrg = 0;
            bool flag = false;
            for (int row = 0; row <= lastRow-1; row++)
            {
                
                if (row != lastRow - 1 && flag==false)
                {
                    lastColumn = original[row].Length;
                    result[row] = new int[lastColumn];
                }
                else if(flag==true && row != lastRow - 1)
                {
                    lastColumn = original[row].Length;
                    result[row+1] = new int[lastColumn];
                }

                for (int col = 0; col < lastColumn; col++)
                {
                    if (rowOrg==ofset)
                    {
                        result[ofset] = added;
                        if (result.Length-1!=ofset)
                        {
                            rowOrg++;
                            result[rowOrg] = new int[lastColumn];
                            col--;
                        }                       
                        flag = true;
                    }
                    else if(row != lastRow - 1)
                    {                       
                        result[rowOrg][col] = original[row][col];
                    }                  
                }
                rowOrg++;
            }                     
            return result;
        }

        static int[][] AddColumn(int[][] original,int ofset, int[] added)
        {
            int lastRow = original.Length;
            int lastColumn = 0;
            // Create new array.
            int[][] result = new int[lastRow][];
            // Copy the array.
            bool flag = false;
            for (int row = 0; row < lastRow; row++)
            {
                lastColumn = original[row].Length + 1;                
                int colsRes = 0;
                flag = false;
                for (int col = 0; col < lastColumn-1; col++)
                {
                    
                    if (col==ofset&& flag == false && added.Length>row)
                    {
                        result[row] = new int[lastColumn];
                        result[row][ofset] = added[row];
                        //colsRes++;
                        flag = true;
                        col--;
                    }
                    else
                    {
                        result[row] = new int[lastColumn];
                        result[row][colsRes] = original[row][col];
                    }
                    colsRes++;
                }

               
            }
            // Add the new column.
            //for (int i = 0; i < added.Length; i++)
            //{
            //    lastColumn = original[i].Length;
            //    result[i][lastColumn] = added[i];
            //}
            return result;
        }
    }
}
