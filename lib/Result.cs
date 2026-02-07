using Spectre.Console;
using Spectre.Console.Rendering;
using System;

namespace gtn750_fpl_installer.lib
{
    internal static class Result
    {
        internal static void Negative(string content)
        {
            Negative(new Markup($"[red]{content}[/]"));
        }


        internal static void Negative(FlightplanException exception)
        {;

            var errPath = ResultPath(exception.Flightplan.Fullpath, Color.Red);
            var errText = new Markup($"[red]{exception.Message}[/]");

            Negative(new Rows(errText, errPath));
        }

        internal static void Negative(Exception exception)
        {
            Negative(exception.Message);
        }

        internal static void Negative(IRenderable content)
        {
            var panel = new Panel(content)
                .Header("[red bold] ✗ Error [/]")
                .BorderColor(Color.Red)
                .Expand();

            AnsiConsole.Write(panel);
        }


        internal static void Positive(Flightplan flightplan)
        {
            var positiveColor = Color.PaleGreen3;

            var path = ResultPath(flightplan.Fullpath, positiveColor);

            var panel = new Panel(path)
                .Header("[PaleGreen3 bold] ✓ Success [/]")
                .BorderColor(positiveColor)
                .Expand();

            AnsiConsole.Write(panel);
        }

        internal static void Exit()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }

        private static TextPath ResultPath(string path, Color color)
        {
            return new TextPath(path)
                .RootColor(color)
                .StemColor(color)
                .LeafStyle(color)
                .SeparatorColor(color);
        }
    }

    
}
