using System;

namespace Lab_1_ExceptionManager
{
    class Program
    {
        static void Main(string[] args)
        {
            //Масив критичних виключних ситуацій
            Exception[] criticalExceptionsArray = new Exception[]
            {
                new IndexOutOfRangeException(),
                new DivideByZeroException(),
                new NullReferenceException(),
            };

            //Створення об'єкту ExceptionManager
            ExceptionManager exceptionManager = new ExceptionManager(criticalExceptionsArray);

            //Метод, який перевіряє чи є виключна ситуація критичною. Повертає bool
            exceptionManager.IsExceptionCritical(new IndexOutOfRangeException());

            //Метод, який аналізує виключні ситуації та інкрементує відповідні лічильники
            exceptionManager.AnalyzeExceptions(
                new NullReferenceException(),
                new InvalidCastException(),
                new ArgumentOutOfRangeException()
            );

            //Вивід результатів
            Console.WriteLine(exceptionManager.ToString());

            Console.ReadLine();
        }
    }
}
