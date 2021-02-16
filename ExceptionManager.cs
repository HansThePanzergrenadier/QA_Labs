using System;

namespace Lab_1_ExceptionManager
{
    class ExceptionManager
    {
        private Exception[] criticalExceptionsArray;
        private int criticalExceptionsCounter;
        private int commonExceptionsCounter;


        public ExceptionManager(Exception[] criticalExceptionsArray)
        {
            SetCriticalExceptionsArray(criticalExceptionsArray);
            ResetCounters();
        }

        /*
         * Обнулює значення лічильників
         */
        public void ResetCounters()
        {
            criticalExceptionsCounter = 0;
            commonExceptionsCounter = 0;
        }

        /*
         * Повертає значення лічильника критичних виключних ситуацій
         */
        public int GetCriticalExceptionsCount()
        {
            return criticalExceptionsCounter;
        }

        /*
         * Повертає значення лічильника звичайних виключних ситуацій
         */
        public int GetCommonExceptionsCount()
        {
            return commonExceptionsCounter;
        }

        /*
         * Встановлює масив критичних виключних ситуацій
         */
        public void SetCriticalExceptionsArray(Exception[] criticalExceptionsArray)
        {
            this.criticalExceptionsArray = new Exception[criticalExceptionsArray.Length];
            criticalExceptionsArray.CopyTo(this.criticalExceptionsArray, 0);
        }

        /*
         * Повертає масив критичних виключних ситуацій
         */
        public Exception[] GetCriticalExceptionsArray()
        {
            return criticalExceptionsArray;
        }

        /*
         * Перевіряє чи є виключна ситуація критичною. Повертає bool
         */
        public bool IsExceptionCritical(Exception exception)
        {
            if (Contains(exception))
            {
                criticalExceptionsCounter++;

                return true;
            }

            return false;
        }

        /*
         * Аналізує виключні ситуації та інкрементує відповідні лічильники
         */
        public void AnalyzeExceptions(params Exception[] exceptions)
        {
            foreach (var ex in exceptions)
            {
                if (Contains(ex))
                {
                    criticalExceptionsCounter++;
                }
                else
                {
                    commonExceptionsCounter++;
                }
            }
        }

        /*
         * Перевантаження методу ToString(). Повертає рядок зі значеннями лічильників
         */
        public override string ToString()
        {
            string criticalExceptionsArrayStr = "";

            foreach (Exception criticalException in criticalExceptionsArray)
            {
                criticalExceptionsArrayStr += $"\n\t{criticalException.GetType()}";
            }

            return $"[Critical Exceptions Array]: {criticalExceptionsArrayStr} \n\n" +
                $"[Critical Exceptions]: {GetCriticalExceptionsCount()} \n" +
                $"[Common Exceptions]: {GetCommonExceptionsCount()}";
        }

        /*
         * Перевірка на входження виключної ситуації у масив критичних виключних ситуацій. Повертає bool
         */
        private bool Contains(Exception exception)
        {
            foreach (Exception criticalException in criticalExceptionsArray)
            {
                if (exception.GetType() == criticalException.GetType())
                {
                    return true;
                }
            }

            return false;
        }
    }
}
