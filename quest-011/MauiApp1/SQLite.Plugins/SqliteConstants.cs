namespace SQLite.Plugins
{
    internal class SqliteConstants
    {
        public const string FileName = "Planets.SQLite.db3";

        public static string DatabasePath =>
        Path.Combine(FileSystem.AppDataDirectory, FileName);
    }
}
