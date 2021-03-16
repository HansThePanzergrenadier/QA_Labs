using OpenQA.Selenium;
using System;

namespace Lab3_Selenium
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = null;
            bool isRunned = false;

            Console.WriteLine("Press Enter to start...");

            while (true)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Enter:
                        if (isRunned)
                        {
                            break;
                        }
                        Console.WriteLine();
                        driver = new OpenQA.Selenium.Chrome.ChromeDriver();
                        start(driver, "http://todomvc.com/examples/angularjs/");
                        isRunned = true;
                        Console.WriteLine();
                        Console.WriteLine("Press Escape to exit...");
                        break;

                    case ConsoleKey.Escape:
                        quit(driver);
                        Environment.Exit(0);
                        break;
                }
            }
        }

        static void start(IWebDriver driver, string url)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);

            TodosPage site = new TodosPage(driver);

            site.AddTodo("Practice guitar");
            site.AddTodo("Do exercises");
            site.AddTodo("Go outside");
            site.AddTodo("Do Lab3 for SQ");
            site.AddTodo("Sleep 8 hours");

            site.DeleteTodo(3);

            site.CheckTodo(1);
            site.CheckTodo(2);

            site.ShowActive();
            site.ShowCompleted();
            site.ClearCompleted();
        }

        static void quit(IWebDriver driver)
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
