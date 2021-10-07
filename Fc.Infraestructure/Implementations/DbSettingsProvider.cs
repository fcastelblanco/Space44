using Fc.Infraestructure.Definitions;

namespace Fc.Infraestructure.Implementations
{
    public class DbSettingsProvider : IDbSettingsProvider
    {
        public DbSettingsProvider(string databaseName)
        {
            DatabaseName = databaseName;
        }

        public string DatabaseName { get; }
    }
}