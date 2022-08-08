namespace Byteology.Website.Pages;

using System.Text.Json;

public class BasePage<TModel> : ComponentBase
{
    private readonly JsonSerializerOptions _serializerOptions = new(JsonSerializerDefaults.Web);

    public TModel Model { get; private set; }

    public BasePage(string dataFilename)
    {
        string? ns = GetType().Assembly.GetName().Name;

        if (string.IsNullOrEmpty(ns))
            throw new InvalidOperationException("Assembly name is null or empty.");

        using Stream? stream = GetType().Assembly.GetManifestResourceStream($"{ns}.Data.{dataFilename}");

        if (stream == null)
            throw new ArgumentException("Data file not found.", nameof(dataFilename));

        using StreamReader sr = new (stream);
        string dataText = sr.ReadToEnd();
        TModel? model = JsonSerializer.Deserialize<TModel>(dataText, _serializerOptions);

        if (model == null)
            throw new InvalidOperationException("Data failed to deserialize.");

        Model = model;
    }
}
