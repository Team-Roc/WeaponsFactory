namespace WeaponsFactory.ConsoleClient
{
    using System;

    public static class WeaponsFactoryConsoleWriter
    {
        public static void StartProcess(string startProcessMessage)
        {
            Console.Write(startProcessMessage);
        }

        public static void Success(string successMessage)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(successMessage);
            Console.ResetColor();
        }

        public static void Error(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }
    }
}
