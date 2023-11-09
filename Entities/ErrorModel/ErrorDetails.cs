using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Entities;
public class ErrorDetails
{
    public int StatusCode { get; set; }
    public string? Message { get; set; }

    public override string ToString() => JsonSerializer.Serialize(this);
}
