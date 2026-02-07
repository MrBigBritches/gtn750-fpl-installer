using gtn750_fpl_installer.lib;
using System.Text;

const string GTN750_FOLDER = "pms50-instrument-gtn750";
const string GTN750_FPL_FILENAME = "fpl.pln";

Console.OutputEncoding = Encoding.UTF8;
Console.Title = "GTN750 Flightplan Installer";

try
{
    if (!Community.Exists)
        throw new DirectoryNotFoundException("community");

    var outputDirectory = Path.Combine(Community.Location, GTN750_FOLDER, "fpl", "gtn750");
    if (!Directory.Exists(outputDirectory))
        throw new DirectoryNotFoundException("GTN750");

    if (args.Length == 0)
        throw new ArgumentException("Please drag a flightplan (*.pln) onto the executable.");

    Flightplan flightplan = new (args[0]);
    if (flightplan.Extension != ".pln")
        throw new FlightplanException(flightplan, "Provided file must have the .pln extension.");

    var fplOutPath = Path.Combine(outputDirectory, GTN750_FPL_FILENAME);
    flightplan.WriteTo(fplOutPath);

    Result.Positive(flightplan);
}
catch (DirectoryNotFoundException ex)
{
    Result.Negative($"Could not determine location of ${ex.Message} folder.");
}
catch (FlightplanException ex)
{
    Result.Negative(ex);
}
catch (Exception ex)
{
    Result.Negative(ex);
}
finally
{
    Result.Exit();
}
