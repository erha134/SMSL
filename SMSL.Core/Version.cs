namespace SMSL.Core;

public class Version
{
    public static readonly string CurrentVersion = LoadVersion();

    private static string LoadVersion()
    {
        return File.ReadAllLines("Resources/version.properties")[0].Split("=")[1];
    }
}