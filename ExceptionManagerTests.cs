using NUnit.Framework;
using System;

namespace Lab_1_ExceptionManager
{
    [TestFixture]
    class ExceptionManagerTests
    {
        private ExceptionManager exceptionManager;
        private Exception[] criticalExceptionsArray;
        private Exception[] exceptionsArray;


        [SetUp]
        public void Setup()
        {
            Exception commonException = new Exception();
            Exception criticalException = new IndexOutOfRangeException();

            exceptionsArray = new Exception[]
            {
                commonException,
                criticalException,
            };

            criticalExceptionsArray = new Exception[]
            {
                criticalException,
                new DivideByZeroException(),
                new NullReferenceException(),
            };

            exceptionManager = new ExceptionManager(criticalExceptionsArray);
        }


        [TestCase(0, ExpectedResult = false)] //commonException
        [TestCase(1, ExpectedResult = true)] //criticalException
        public bool IsExceptionCriticalTest(int exceptionIndex)
        {
            // Arrange
            exceptionManager.ResetCounters();

            // Act
            bool result = exceptionManager.IsExceptionCritical(exceptionsArray[exceptionIndex]);

            // Assert
            return result && exceptionManager.GetCriticalExceptionsCount() == 1;
        }


        [TestCase(1, 0, 0, ExpectedResult = true)] //commonException
        [TestCase(0, 1, 1, ExpectedResult = true)] //criticalException
        [TestCase(1, 1, 0, 1, ExpectedResult = true)] //commonException and criticalException
        [TestCase(0, 1, 0, 1, ExpectedResult = false)] //commonException and criticalException
        [TestCase(1, 0, 0, 1, ExpectedResult = false)] //commonException and criticalException
        [TestCase(0, 0, 0, 1, ExpectedResult = false)] //commonException and criticalException
        public bool AnalyzeExceptionsTest(int commonExceptionExpectedResult, int criticalExceptionExpectedResult, params int[] exceptionIndices)
        {
            // Arrange
            Exception[] exceptions = new Exception[exceptionIndices.Length];
            for(int i = 0; i < exceptionIndices.Length; i++)
            {
                exceptions[i] = exceptionsArray[exceptionIndices[i]];
            }
            exceptionManager.ResetCounters();

            // Act
            exceptionManager.AnalyzeExceptions(exceptions);

            // Assert
            return exceptionManager.GetCommonExceptionsCount() == commonExceptionExpectedResult &&
                exceptionManager.GetCriticalExceptionsCount() == criticalExceptionExpectedResult;
        }
    }
}
