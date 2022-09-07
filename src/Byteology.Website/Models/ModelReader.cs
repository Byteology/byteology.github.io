namespace Byteology.Website.Models;

using System.Reflection;
using System.Text.Json;

public class ModelReader
{
    private readonly Assembly _assembly;
    private readonly JsonSerializerOptions _serializerOptions;

    public ModelReader(Assembly assembly, JsonSerializerOptions serializerOptions)
    {
        _assembly = assembly;
        _serializerOptions = serializerOptions;
    }

    public TModel ReadJson<TModel>(string dataFilename)
    {
        string dataText = readData(dataFilename);
        TModel? model = JsonSerializer.Deserialize<TModel>(dataText, _serializerOptions);

        if (model == null)
            throw new InvalidOperationException("Data failed to deserialize.");

        return model;
    }

    public string ReadPlainText(string dataFilename)
    {
        string dataText = readData(dataFilename);
        return dataText;
    }

    private string readData(string dataFilename)
    {
        string? ns = _assembly.GetName().Name;

        if (string.IsNullOrEmpty(ns))
            throw new InvalidOperationException("Assembly name is null or empty.");

        using Stream? stream = _assembly.GetManifestResourceStream($"{ns}.Data.{dataFilename}");

        if (stream == null)
            throw new ArgumentException("Data file not found.", nameof(dataFilename));

        using StreamReader sr = new(stream);
        string dataText = sr.ReadToEnd();
        return dataText;
    }
}
