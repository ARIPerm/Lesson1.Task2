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
                Console.WriteLine("! ! ! Вы указали элемент, выходящий за размер массива ! ! !");
            }
        }

        public void Remove(int a, int b)
        {
            a--;b--;
            if (array.GetLength(0) > a && array.GetLength(1) > b )
            {
                array[a, b] = 0;
            }
            else
            {
                Console.WriteLine("! ! ! Вы указали элемент, выходящий за размер массива ! ! !");
            }
        }

        public void DeleteAllNull()
        {
            int min=0;
            int index=0;
             for (int i = 0; i < array.GetLength(0); i++)
             {
                for(int j=0;j<array.GetLength(1);j++)
                {
                    if (array[i, j] <min)
                    {
                        min = array[i,j];
                        index = j;
                    }
                }
             }
            Console.WriteLine(index);

        }

    }

}
