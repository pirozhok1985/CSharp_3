using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace AsyncFactorialAndSum
{
    class Program
    {
        static void Main(string[] args)
        {
            //--------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"Main method is running in the thread number {Thread.CurrentThread.ManagedThreadId}");
            //--------------------------------------------------------------------------------------------------------------------

            Console.Write("Введите число, для которого нужно вычислить факториал: ");
            if (!int.TryParse(Console.ReadLine(), out int x))
                throw new InvalidCastException("Could not cast entered value to int");
            Console.Write("Введите первое слогаемое: ");
            if (!int.TryParse(Console.ReadLine(), out int a))
                throw new InvalidCastException("Could not cast entered value to int");
            Console.Write("Введите второе слогаемое: ");
            if (!int.TryParse(Console.ReadLine(), out int b))
                throw new InvalidCastException("Could not cast entered value to int");
            int[] arr = { a, b };

            Thread tr1 = new Thread(new ParameterizedThreadStart(Factorial));
            tr1.Name = "Factorial Thead";
            Thread tr2 = new Thread(new ParameterizedThreadStart(Sum));
            tr2.Name = "Sum Thead";
            tr1.Start(x);
            tr2.Start(arr);

            Console.ReadLine();
        }

        private static void Factorial(object x)
        {
            Thread.Sleep(1000);
            int value = (int)x;
            int factorial = new int();
            //--------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"Factorial method is running in the thread number {Thread.CurrentThread.ManagedThreadId} with name {Thread.CurrentThread.Name}");
            //--------------------------------------------------------------------------------------------------------------------
            for (var i = 0; i <= value; i++)
            {
                factorial = (i == 0) ? 1 : factorial * i;
            }
            Console.WriteLine($"Факториал числа {value} равен {factorial}");
        }

        private static void Sum(object obj)
        {
            int[] arr = (int[])obj;
            Thread.Sleep(1000);
            //--------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"Sum method is running in the thread number {Thread.CurrentThread.ManagedThreadId} with name {Thread.CurrentThread.Name}");
            //--------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"Сумма 2-х введённых чисел равна {arr[0] + arr[1]}"); 
        }
    }
}
