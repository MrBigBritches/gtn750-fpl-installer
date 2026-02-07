namespace gtn750_fpl_installer.lib
{
    internal class Flightplan(string path)
    {
        private readonly FileStream _reader = File.OpenRead(path);

        internal string FileName => Path.GetFileName(path);
        internal string Extension => Path.GetExtension(path);


        internal void WriteTo(string path)
        {
            _reader.Position = 0;

            using FileStream writer = File.Open(path, FileMode.Create, FileAccess.Write);
            _reader.CopyTo(writer);
        }

        ~Flightplan() { _reader.Dispose(); }
    }
}
