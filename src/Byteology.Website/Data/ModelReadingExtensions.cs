namespace Byteology.Website.Data;

using System.Text.Json;
using System.Text.Json.Serialization;

public static class ModelReader
{
    private static JsonSerializerOptions _serializerOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    public static TModel Read<TModel>(string dataFilename)
    {
        string? ns = typeof(TModel).Assembly.GetName().Name;

        if (string.IsNullOrEmpty(ns))
            throw new InvalidOperationException("Assembly name is null or empty.");

        using Stream? stream = typeof(TModel).Assembly.GetManifestResourceStream($"{ns}.Data.{dataFilename}");

        if (stream == null)
            throw new ArgumentException("Data file not found.", nameof(dataFilename));

        using StreamReader sr = new(stream);
        string dataText = sr.ReadToEnd();
        TModel? model = JsonSerializer.Deserialize<TModel>(dataText, _serializerOptions);

        if (model == null)
            throw new InvalidOperationException("Data failed to deserialize.");

        return model;
    }
}
