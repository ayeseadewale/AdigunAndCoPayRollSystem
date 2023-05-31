using System.Text.Json.Serialization;

namespace AdigunAndCoPayRollSystem.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum PayrollComponentType
    {
        Earnings,
        Deductions
    }
}
