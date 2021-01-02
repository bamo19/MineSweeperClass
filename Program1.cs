using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace minesweeper
{
    class Program1
    {
        static int constrain(int amt, int min, int max)
        {
            if (amt < min)
                amt = min;
            if (amt > max)
                amt = max;
            return amt;
        }

        static void mineInfo(int minenum, int length, int[,] a)
        {
            Random rnd = new Random();
            for (int x = 0; x <= minenum; x++)
            {
                int i = rnd.Next(length);
                int j = rnd.Next(length);

                a[i, j] = 1;
            }
        }

        static void initializeArray(int[,] b)
        {
            for (int a = 0; a < 5; a++)
            {
                for (int c = 0; c < 5; c++)
                {
                    b[a, c] = 0;
                }
            }
        }

        static void initializeArray(char[,] c)
        {
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    c[a, b] = '-';
                }
            }
        }

        static void rewrite(char[,] c)
        {
            for (int a = 0; a < 5; a++)
            {
                for (int b = 0; b < 5; b++)
                {
                    Console.Write(Convert.ToString(c[a, b]) + " ");
                }
                Console.Write("\n");
            }
        }

        static void Main(string[] args)
        {
            int row, column;

            int minesCount = 0;

            int guess = 0;

            char[,] show = new char[5, 5];

            initializeArray(show);

            int[,] arr = new int[5, 5];

            initializeArray(arr);

            mineInfo(6, 5, arr);

            rewrite(show);

            while (guess <= 18)
            {
                Console.WriteLine(" enter row:\n");

                row = Convert.ToInt16(Console.ReadLine()) - 1;
              
                Console.WriteLine(" enter column:\n");

               
                column = Convert.ToInt16(Console.ReadLine()) - 1;

                guess++;

                if (arr[row, column] == 1)
                {
                    show[row, column] = '*';

                    rewrite(show);

                    Console.WriteLine("***Game Over***\n" + "Press enter to exit");

                    break;
                }

                else
                {

                    for (int x = constrain(row - 1, 0, 4); x <= constrain(row + 1, 0, 4); x++)
                        for (int y = constrain(column - 1, 0, 4); y <= constrain(column + 1, 0, 4); y++)
                            if (arr[x, y] == 1)
                                minesCount++;

                    show[row, column] = Convert.ToChar(minesCount.ToString());
                }

                rewrite(show);

                minesCount = 0;
            }
            Console.ReadLine();
        }
    }
}
