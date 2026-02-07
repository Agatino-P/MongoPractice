using System.Text.Json;

namespace Ag.Api.Extension;

public class CustomJson
{
    public static string Serialize<T>(T t)=>
        JsonSerializer.Serialize(t, options: new() { WriteIndented = true });
}