namespace gtn750_fpl_installer.lib
{
    internal static class Log
    {
        public static void Negative(string logline)
        {
            WriteLine(ConsoleColor.Red, logline);
        }

        public static void Positive(string logline)
        {
            WriteLine(ConsoleColor.Green, logline);

        }

        public static void Exit()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static void WriteLine(ConsoleColor color, string logline)
        {
            ConsoleColor DefaultColor = Console.ForegroundColor;

            Console.ForegroundColor = color;
            Console.WriteLine(logline);

            Console.ForegroundColor = DefaultColor;
        }
    }
}
