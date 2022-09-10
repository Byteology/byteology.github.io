namespace Byteology.Website;

using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

public static class ComponentExtensionMethods
{
    private static readonly JsonSerializerOptions _jsonSerializerOptions = new(JsonSerializerDefaults.Web)
    {
        Converters = { new JsonStringEnumConverter(JsonNamingPolicy.CamelCase) }
    };

    public static TModel ReadJsonModel<TModel>(this ComponentBase component)
    {
        string data = readModelData(component, ".json");

        TModel? model = JsonSerializer.Deserialize<TModel>(data, _jsonSerializerOptions);

        if (model == null)
            throw new InvalidOperationException("Data failed to deserialize.");

        return model;
    }

    public static string ReadMarkdownModel(this ComponentBase component)
    {
        string dataText = readModelData(component, ".md");
        return dataText;
    }

    private static string readModelData(ComponentBase component, string extension)
    {
        Type type = component.GetType();
        Assembly assembly = type.Assembly;
        string? ns = type.Namespace;

        if (string.IsNullOrEmpty(ns))
            throw new InvalidOperationException("The component must have a namespace.");

        string filename = $"{type.FullName}.razor{extension}";

        using Stream? stream = assembly.GetManifestResourceStream(filename);

        if (stream == null)
            throw new InvalidOperationException($"Data file not found: '{filename}'");

        using StreamReader sr = new(stream);
        string dataText = sr.ReadToEnd();
        return dataText;
    }
}
