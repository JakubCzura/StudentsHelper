namespace Advice.Domain.SettingsOptions.Database;

public class DatabaseOptions
{
    public const string AppsettingsKey = "Database";

    public string ConnectionString { get; set; } = string.Empty;

    public string DatabaseName { get; set; } = string.Empty;
}