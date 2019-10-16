using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaternARI
{
    public class Presenter
    {
        private static int START_VALUE_A = 3;
        private static int START_VALUE_B = 5;
        static Random rnd = new Random();
        public int[,] array;

        public Presenter()
        {
            array = new int[START_VALUE_A, START_VALUE_B];
            for (int i = 0; i < START_VALUE_A; i++)
            {
                for (int j = 0; j < START_VALUE_B; j++)
                {
                    array[i, j] = rnd.Next(0, 10);
                }
            }
        }

        public Presenter(int a, int b)
        {
            array = new int[a, b];
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < b; j++)
                {
                    array[i, j] = rnd.Next(0, 10);
                }
            }
        }

        public void AddInMass(int i, int j, int item)
        {
            array[i, j] = item;
        }

        public void Add(int a, int b, int item)
        {
            a--; b--;
            if (array.GetLength(0) > a && array.GetLength(1) > b)
            {
                array[a, b] = item;
            }
            else
            {
                Miss();
            }
        }

        public void Delete(int check, int number)
        {
            if (check == 1)
            {
                if (array.GetLength(0) > (number - 1))
                {
                    int N1 = array.GetLength(0);
                    int N2 = array.GetLength(1);
                    int[,] temp = new int[N1, N2];
                    temp = array;
                    array = new int[N1 - 1, N2];
                    int indexRow;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        indexRow = i;
                        if (i >= (number - 1))
                        {
                            indexRow++;
                        }
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            array[i, j] = temp[indexRow, j];
                        }
                    }
                }
                else
                {
                    Miss();
                }
            }
            if (check == 2)
            {
                if (array.GetLength(1) > (number - 1))
                {
                    int N1 = array.GetLength(0);
                    int N2 = array.GetLength(1);
                    int[,] temp = new int[N1, N2];
                    temp = array;
                    array = new int[N1, N2 - 1];
                    int indexCol;
                    for (int i = 0; i < array.GetLength(0); i++)
                    {
                        for (int j = 0; j < array.GetLength(1); j++)
                        {
                            indexCol = j;
                            if (j >= (number - 1))
                            {
                                indexCol++;
                            }
                            array[i, j] = temp[i, indexCol];
                        }
                    }
                }
                else
                {
                    Miss();
                }
            }
        }

        public void DeleteMin()
        {
            int indexJ = 10;
            int min = 10;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (array[i, j] < min)
                    {
                        min = array[i, j];
                        indexJ = j + 1;
                    }
                }
            }
            Delete(2, indexJ);
        }

        public void AddRow(int row)
        {
            int N1 = array.GetLength(0);
            int N2 = array.GetLength(1);
            int[,] temp = new int[N1, N2];
            temp = array;
            array = new int[N1 + 1, N2];
            int indexRow;
            bool flagNew = false;
            bool flagAfter = false;
            for (int i = 0; i < array.GetLength(0); i++)
            {
                indexRow = i;
                if (i == (row - 1))
                {
                    flagNew = true;
                }
                if(flagAfter)
                {
                    indexRow--;
                }
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    if (flagNew)
                    {
                        array[i, j] = rnd.Next(0, 10);
                        flagAfter = true;
                    }
                    else
                    {
                        array[i, j] = temp[indexRow, j];
                    }
                }
                flagNew = false;
            }
        }

        public void Miss()
        {
            Console.WriteLine("! ! ! Вы указали элемент, выходящий за размер массива ! ! !");
        }
    }

}


