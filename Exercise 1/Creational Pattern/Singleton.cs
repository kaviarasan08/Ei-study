using System;

class AppSettings
{
    private static AppSettings _instance;
    private static readonly object _lock = new object();

    public string Theme { get; set; }

    private AppSettings() { }

    public static AppSettings Instance
    {
        get
        {
            lock (_lock)
            {
                if (_instance == null)
                    _instance = new AppSettings();
                return _instance;
            }
        }
    }
}

// Demo
class Program4
{
    static void Main()
    {
        var settings1 = AppSettings.Instance;
        settings1.Theme = "Dark";

        var settings2 = AppSettings.Instance;
        Console.WriteLine(settings2.Theme); // Prints "Dark"
    }
}
