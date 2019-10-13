using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaternARI
{
    class Program
    {
        static Presenter presenter = new Presenter();

        static void Main(string[] args)
        {
            bool check1 = true;
            bool check2 = true;

            Console.WriteLine("Укажите, как выбрать размер массива:\n" +
                " 1-Автоматический выбор\n" +
                " 2-Выбор в ручную");

            int m = Convert.ToInt32(Console.ReadLine());
            switch (m)
            {
                case 1:
                    break;
                case 2:
                    Console.WriteLine("Укажите размер массив: ");
                    Console.Write("Столбцы: ");
                    int b = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Строки: ");
                    int a = Convert.ToInt32(Console.ReadLine());
                    presenter = new Presenter(a, b);
                    break;
                default:
                    Console.WriteLine("! ! ! Некорректный выбор значения ! ! !");
                    check1 = false;
                    break;
            }

            if (check1)
            {
                Console.WriteLine();
                Console.WriteLine("Укажите, как заполнить массив:\n" +
                    " 1-Автоматическое заполнение\n" +
                    " 2-Заполнить вручную");

                int k = Convert.ToInt32(Console.ReadLine());
                switch (k)
                {
                    case 1:
                        Print();
                        break;
                    case 2:
                        for (int i = 0; i < presenter.array.GetLength(0); i++)
                        {
                            for (int j = 0; j < presenter.array.GetLength(1); j++)
                            {
                                Console.Write("Введите {0} элемент {1} столбца: ", j + 1, i + 1);
                                int a = Convert.ToInt32(Console.ReadLine());
                                presenter.AddInMass(i, j, a);
                            }
                            Console.WriteLine();
                        }
                        Print();
                        break;
                    default:
                        Console.WriteLine("! ! ! Некорректный выбор значения ! ! !");
                        check2 = false;
                        break;
                }
            }

            if (check1 && check2)
            {
                for (; ; )
                {
                    Console.WriteLine("Выберите операцию:\n" +
                            " 1-Заменить элемент\n" +
                            " 2-Занулить элемент\n" +
                            " 3-Вывести массив\n" +
                            " 4-Задание по варианту\n");

                    int s = Convert.ToInt32(Console.ReadLine());
                    switch (s)
                    {
                        case 1:
                            {
                                Console.WriteLine("Какой элемент изменить?");
                                Console.Write("Столбец: ");
                                int b = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Строка: ");
                                int a = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Введите число, на которое необходимо заменить:");
                                int value = Convert.ToInt32(Console.ReadLine());
                                presenter.Add(a, b, value);
                                Print();
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Какой элемент занулить?");
                                Console.Write("Столбец: ");
                                int b = Convert.ToInt32(Console.ReadLine());
                                Console.Write("Строка: ");
                                int a = Convert.ToInt32(Console.ReadLine());
                                presenter.Remove(a, b);
                                Print();
                                break;
                            }
                        case 3:
                            Print();
                            break;
                        case 4:
                            presenter.DeleteAllNull();
                            Print();
                            break;
                        default:
                            Console.WriteLine("! ! ! Некорректный выбор значения ! ! ! \n \n ");
                            Console.WriteLine("\t\t ~ ~ ~ Повторите попытку ~ ~ ~");
                            break;
                    }
                    Console.ReadKey();
                }
            }
            else
            {
                Console.WriteLine("\t\t ~ ~ ~ Повторите попытку ~ ~ ~");
                Console.ReadKey();
            }

        }

        public static void Print()
        {
            for (int i = 0; i < presenter.array.GetLength(0); i++)
            {
                for (int j = 0; j < presenter.array.GetLength(1); j++)
                {
                    Console.Write(" " + presenter.array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }


    }

}
