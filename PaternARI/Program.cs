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
            bool check1;
            bool check2;
            for (; ; )
            {
                check1 = true;
                check2 = true;
                Console.WriteLine("Укажите, как желаете выбрать размер массива:\n" +
                    " 1-Довериться программе\n" +
                    " 2-Сделать выбор вручную");
                int m;
                string str = Console.ReadLine();
                if (Cheks(str))
                {
                    m = Number(str);
                    switch (m)
                    {
                        case 1:
                            break;
                        case 2:
                            Console.WriteLine("Укажите размер массив: ");
                            Console.Write("Количество столбцов: ");
                            string str1 = Console.ReadLine();
                            Console.Write("Количество строк: ");
                            string str2 = Console.ReadLine();
                            if (Cheks(str1) && Cheks(str2))
                            {
                                int b = Number(str1);
                                int a = Number(str2);
                                presenter = new Presenter(a, b);
                            }
                            else
                            {
                                Error();
                                check1 = false;
                            }
                            break;
                        default:
                            Console.WriteLine("! ! ! Некорректный выбор значения ! ! !");
                            Console.WriteLine("Пожалуйста, выберете из предложенного диапазона");
                            check1 = false;
                            break;
                    }
                }
                else
                {
                    Error();
                    check1 = false;
                }

                if (check1)
                {
                    for (; ; )
                    {
                        check2 = true;
                        Console.WriteLine();
                        Console.WriteLine("Укажите, как желаете заполнить массив:\n" +
                            " 1-Доверить заполнение программе\n" +
                            " 2-Заполнить массив самостоятельно");
                        int k;
                        str = Console.ReadLine();
                        if (Cheks(str))
                        {
                            k = Number(str);
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
                                            string str1 = Console.ReadLine();
                                            if (Cheks(str1))
                                            {
                                                int num = Number(str1);
                                                presenter.AddInMass(i, j, num);
                                            }
                                            else
                                            {
                                                Error();
                                                check2 = false;
                                                break;
                                            }

                                            if (check2 == false) break;
                                        }
                                        Console.WriteLine();
                                        if (check2 == false) break;
                                    }
                                    if (check2) Print();
                                    break;
                                default:
                                    Console.WriteLine("! ! ! Некорректный выбор значения ! ! !");
                                    check2 = false;
                                    break;
                            }
                        }
                        else
                        {
                            Error();
                            check2 = false;
                        }
                    }
                }

                if (check1 && check2)
                {
                    for (; ; )
                    {
                        Console.WriteLine("Выберите операцию, которую произвести над массивом:\n" +
                                " 1-Заменить элемент\n" +
                                " 2-Занулить элемент\n" +
                                " 3-Вывести текущий массив\n" +
                                " 4-Выполнить задание по варианту\n");

                        int s;
                        str = Console.ReadLine();
                        if (Cheks(str))
                        {
                            s = Number(str);
                            switch (s)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Какой элемент изменить?");
                                        Console.Write("Столбец: ");
                                        string str1 = Console.ReadLine();
                                        Console.Write("Строка: ");
                                        string str2 = Console.ReadLine();
                                        Console.WriteLine("Введите число, на которое необходимо заменить:");
                                        string str3 = Console.ReadLine();
                                        if (Cheks(str1) && Cheks(str2) && Cheks(str3))
                                        {
                                            int b = Number(str1);
                                            int a = Number(str2);
                                            int value = Number(str3);
                                            presenter.Add(a, b, value);
                                            Print();
                                        }
                                        else
                                        {
                                            Error();
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Какой элемент занулить?");
                                        Console.Write("Столбец: ");
                                        string str1 = Console.ReadLine();
                                        Console.Write("Строка: ");
                                        string str2 = Console.ReadLine();
                                        if (Cheks(str1) && Cheks(str2))
                                        {
                                            int b = Number(str1);
                                            int a = Number(str2);
                                            presenter.Remove(a, b);
                                            Print();
                                        }
                                        else
                                        {
                                            Error();
                                        }
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
                                    break;
                            }
                        }
                        else
                        {
                            Error();
                        }
                    }
                }
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
        public static void Error()
        {
            Console.WriteLine("\tВы ввели неверное значение.\n \t ~~~Повторите попытку ~~~");
        }
        public static bool Cheks(string str)
        {
            int k;
            if (Int32.TryParse(str, out k))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static int Number(string str)
        {
            int k;
            Int32.TryParse(str, out k);
            return k;
        }
    }
}
