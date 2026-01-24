namespace gtn750_fpl_installer.lib
{
    internal static class Community
    {
        const string PACKAGE_NAME = "Microsoft.Limitless_8wekyb3d8bbwe";

        const string CONFIG_FILE = "UserCfg.opt";
        const string CONFIG_KEY = "InstalledPackagesPath";


        private static string LocalCache
        {
            get
            {
                var localAppDataPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(localAppDataPath, "Packages", PACKAGE_NAME, "LocalCache");
            }
        }

        private static string? InstalledPackagesPath
        {
            get
            {
                var userConfigPath = Path.Combine(LocalCache, CONFIG_FILE);
                if (!File.Exists(userConfigPath)) return null;

                var configOption = File.ReadLines(userConfigPath).First(str => str.StartsWith(CONFIG_KEY));
                return configOption.Split(' ').Last().Trim('"');
            }
        }

        internal static string Location
        {
            get
            {
                var packagesPath = InstalledPackagesPath ?? Path.Combine(LocalCache, "Packages");
                return Path.Combine(packagesPath, "Community");
            }
        }

        internal static bool Exists => Directory.Exists(Location);
    }
}
