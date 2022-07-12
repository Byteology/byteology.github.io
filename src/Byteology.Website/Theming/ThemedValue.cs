namespace Byteology.Website.Theming;

public class ThemedValue
{
    private readonly Func<Theme> _themeProvider;

    private readonly string _lightValue;
    private readonly string _darkValue;

    public string Value =>
        _themeProvider() switch
        {
            Theme.Light => _lightValue,
            Theme.Dark => _darkValue,
            _ => throw new InvalidOperationException($"Unknown theme: '{_themeProvider()}'")
        };

    public ThemedValue(Func<Theme> themeProvider, string light, string dark)
    {
        _themeProvider = themeProvider;
        _lightValue = light;
        _darkValue = dark;
    }
}
