using gtn750_fpl_installer.lib;

const string GTN750_FOLDER = "pms50-instrument-gtn750";
const string GTN750_FPL_FILENAME = "fpl.pln";

Console.Title = "GTN750 Flightplan Installer";

try
{
    if (!Community.Exists)
        throw new DirectoryNotFoundException("Could not determine location of community folder.");

    if (args.Length == 0)
        throw new ArgumentException("Please drag a flightplan onto the executable.");

    Flightplan flightplan = new(args[0]);
    if (flightplan.Extension != ".pln")
        throw new ArgumentException("Provided file must have the .pln extension.");

    var outputDirectory = Path.Combine(Community.Location, GTN750_FOLDER, "fpl", "gtn750");
    if (!Directory.Exists(outputDirectory))
        throw new DirectoryNotFoundException("Could not determine location of GTN750 folder.");

    var fplOutPath = Path.Combine(outputDirectory, GTN750_FPL_FILENAME);
    flightplan.WriteTo(fplOutPath);

    var fplCopyPath = Path.Combine(outputDirectory, flightplan.FileName);
    flightplan.WriteTo(fplCopyPath);

    Log.Positive($"Activated flightplan: {flightplan.FileName}");
}
catch (ArgumentException e)
{
    Log.Negative(e.Message);
}
catch (DirectoryNotFoundException e)
{
    Log.Negative(e.Message);
}
catch (FileNotFoundException e)
{
    Log.Negative(e.Message);
}
catch (Exception e)
{
    Log.Negative(e.ToString());
}
finally
{
    Log.Exit();
}
