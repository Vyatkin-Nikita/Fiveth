using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiveth
{
    class Program
    {
        /*
        Программа создаёт квадратную матрицу с указанной размерностью,
        заполняет её случайными элементами (-10 до 10)
        и высчитывает суммы элементов в тех строках, которые начинаются с отрицательного числа.
        вСуммы элементов выше, ниже и по главной диагонали
        */
        static int n;//число n
        static int SummAbove = 0, SummUnder = 0, SummMain = 0;//Сумма чисел выше, ниже и по главной диагонали соответственно
        static int[,] matrix;
        static int VvodProverka(int mogr = 0, int bogr = 0)//Проверка вводимых с клавиатуры чисел, mogr и bogr - минимально и максимально возможные значения числа
        {
            bool ok;
            int n;
            do
            {
                ok = int.TryParse(Console.ReadLine(), out n);
                if (!ok) { Console.WriteLine("Ошибка. Неверный формат данных. Повторите ввод."); continue; }
                if ((n < mogr) && (bogr < mogr)) { Console.WriteLine("Ошибка. Число должно быть больше или равно {0} . Повторите ввод.", mogr); ok = false; continue; }
                if ((n < mogr) && (mogr != 0) || ((n > bogr) && (bogr != 0))) { Console.WriteLine("Ошибка. Число должно находится в пределах от {0} до {1} . Повторите ввод.", mogr, bogr); ok = false; }

            } while (!ok);
            Console.WriteLine();
            return n;
        }
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.WriteLine("Введите n");
            n = VvodProverka(1);//Проверка n
            matrix = new int[n, n];//Создание матрицы

            for (int i = 0; i < n; i++)//Определение и вывод на экран элементов матрицы
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = rnd.Next(-10, 11);
                    Console.Write("{0,5}", matrix[i, j] + " ");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < n; i++)//Вычисление сумм
            {
                if (matrix[i, 0] < 0)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (i == j) { SummMain += matrix[i, j]; }
                        if (i < j) { SummAbove += matrix[i, j]; }
                        if (i > j) { SummUnder += matrix[i, j]; }
                    }
                }                
            }
            Console.WriteLine("Суммы элементов в строках, начинающихся с отрицательного числа:\nВыше главной диагонали: {0}\nПо главной диагонали: {1}\nНиже главной диагонали: {2}", SummAbove, SummMain, SummUnder);
            Console.ReadLine();

        }
    }
}
