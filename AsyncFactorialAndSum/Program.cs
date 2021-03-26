using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Messaging;
using System.Threading;

namespace AsyncFactorialAndSum
{
    class Program
    {
        public delegate int FactorialDelegate(int x);
        public delegate int NumbersSum(int x, int y);
        static void Main(string[] args)
        {
            FactorialDelegate fd = new FactorialDelegate(Factorial);
            NumbersSum ns = new NumbersSum(Sum);
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


            IAsyncResult resF = fd.BeginInvoke(x, new AsyncCallback(FinishFactorial), x);
            IAsyncResult resS = ns.BeginInvoke(a, b, new AsyncCallback(FinishSum), arr);
            Console.ReadLine();
        }

        private static void FinishSum(IAsyncResult ar)
        {
            //--------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"FinishFactorial method is running in the thread number {Thread.CurrentThread.ManagedThreadId}");
            //--------------------------------------------------------------------------------------------------------------------
            AsyncResult res = (AsyncResult)ar;
            NumbersSum deleg = (NumbersSum)res.AsyncDelegate;
            int[] nums = (int[])ar.AsyncState;
            Console.WriteLine($"Сумма 2-х чисел {nums[0]} и {nums[1]} равна: {deleg.EndInvoke(ar)}");
        }

        private static void FinishFactorial(IAsyncResult ar)
        {
            //--------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"FinishFactorial method is running in the thread number {Thread.CurrentThread.ManagedThreadId}");
            //--------------------------------------------------------------------------------------------------------------------
            AsyncResult res = (AsyncResult)ar;
            FactorialDelegate del = (FactorialDelegate)res.AsyncDelegate;
            Console.WriteLine($"Факториал {res.AsyncState} равен {del.EndInvoke(ar)}");
        }

        private static int Factorial(int x)
        {
            Thread.Sleep(1000);
            //--------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"Factorial method is running in the thread number {Thread.CurrentThread.ManagedThreadId}");
            //--------------------------------------------------------------------------------------------------------------------
            if (x == 0) return 1;
            return x * Factorial(x - 1);
        }

        private static int Sum(int x, int y)
        {
            Thread.Sleep(1000);
            //--------------------------------------------------------------------------------------------------------------------
            Console.WriteLine($"Sum method is running in the thread number {Thread.CurrentThread.ManagedThreadId}");
            //--------------------------------------------------------------------------------------------------------------------
            return x + y;
        }
    }
}
