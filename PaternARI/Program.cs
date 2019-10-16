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
            bool check1, check2;
            for (; ; )
            {
                check1 = false;
                check2 = false;

                Console.WriteLine("Укажите, как желаете выбрать размер массива:\n" +
                    " 1-Довериться программе\n" +
                    " 2-Сделать выбор вручную");

                if (Int32.TryParse(Console.ReadLine(), out int keyCheck1))
                {
                    switch (keyCheck1)
                    {
                        case 1:
                            check1 = true;
                            break;
                        case 2:
                            Console.WriteLine("Укажите размер массив: ");
                            Console.Write("Количество столбцов: ");
                            string column = Console.ReadLine();
                            Console.Write("Количество строк: ");
                            string rows = Console.ReadLine();
                            if (Int32.TryParse(column, out int col) && Int32.TryParse(rows, out int row))
                            {
                                presenter = new Presenter(row, col);
                                check1 = true;
                            }
                            else
                            {
                                Error();
                            }
                            break;
                        default:
                            ErrorCheck();                           
                            break;
                    }
                }
                else
                {
                    Error();
                }

                if (check1)
                {
                    for (; ; )
                    {
                        check2 = false;
                        Console.WriteLine();
                        Console.WriteLine("Укажите, как желаете заполнить массив:\n" +
                            " 1-Доверить заполнение программе\n" +
                            " 2-Заполнить массив самостоятельно");

                        if (Int32.TryParse(Console.ReadLine(), out int keyCheck2))
                        {
                            switch (keyCheck2)
                            {
                                case 1:
                                    check2 = true;
                                    break;
                                case 2:
                                    for (int i = 0; i < presenter.array.GetLength(0); i++)
                                    {
                                        for (int j = 0; j < presenter.array.GetLength(1); j++)
                                        {
                                            Console.Write("Введите {0} элемент {1} столбца: ", j + 1, i + 1);
                                            if (Int32.TryParse(Console.ReadLine(), out int num))
                                            {
                                                presenter.AddInMass(i, j, num);
                                                check2 = true;
                                            }
                                            else
                                            {
                                                Error();
                                                break;
                                            }
                                            if (check2 == false) break;
                                        }
                                        Console.WriteLine();
                                        if (check2 == false) break;
                                    }
                                    break;
                                default:
                                    ErrorCheck();
                                    break;
                            }
                            Print();
                        }
                        else
                        {
                            Error();
                        }
                        if (check2) break;
                    }
                }

                if (check1 && check2)
                {
                    for (; ; )
                    {
                        Console.WriteLine("Выберите операцию, которую произвести над массивом:\n" +
                                " 1-Заменить элемент\n" +
                                " 2-Удалить строку\n" +
                                " 3-Удалить столбец\n" +
                                " 4-Вывести текущий массив\n" +
                                " 5-Выполнить задание по варианту\n" + 
                                " 6-Добавить строку\n");

                        if (Int32.TryParse(Console.ReadLine(), out int keyCheck3))
                        {
                            switch (keyCheck3)
                            {
                                case 1:
                                    {
                                        Console.WriteLine("Какой элемент изменить?");
                                        Console.Write("Столбец: ");
                                        string column = Console.ReadLine();
                                        Console.Write("Строка: ");
                                        string rows = Console.ReadLine();
                                        Console.WriteLine("Введите число, на которое необходимо заменить:");
                                        string number = Console.ReadLine();
                                        if (Int32.TryParse(column, out int col)&& Int32.TryParse(rows, out int row)&& Int32.TryParse(number, out int num))
                                        {
                                            presenter.Add(row, col, num);
                                        }
                                        else
                                        {
                                            Error();
                                        }
                                        break;
                                    }
                                case 2:
                                    {
                                        Console.WriteLine("Какую строку удалить?");
                                        if (Int32.TryParse(Console.ReadLine(), out int row))
                                        {
                                            presenter.Delete(1,row);
                                        }
                                        else
                                        {
                                            Error();
                                        }
                                        break;
                                    }
                                case 3:
                                    {
                                        Console.WriteLine("Какой столбец удалить?");
                                        if (Int32.TryParse(Console.ReadLine(), out int col))
                                        {
                                            presenter.Delete(2, col);
                                        }
                                        else
                                        {
                                            Error();
                                        }
                                        break;
                                    }
                                case 4:
                                    break;
                                case 5:
                                    presenter.DeleteMin();
                                    break;
                                case 6:
                                    {
                                        Console.WriteLine("Какую строку добавить?");
                                        if (Int32.TryParse(Console.ReadLine(), out int row))
                                        {
                                            presenter.AddRow(row);
                                        }
                                        else
                                        {
                                            Error();
                                        }
                                        break;
                                    }
                                default:
                                    ErrorCheck();
                                    break;
                            }
                            Print();
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

        public static void ErrorCheck()
        {
            Console.WriteLine("! ! ! Некорректный выбор значения ! ! ! \n \n ");
            Console.WriteLine("Пожалуйста, выберете из предложенного диапазона");
        }
    }
}
