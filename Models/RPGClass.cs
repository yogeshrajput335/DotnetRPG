using System.Text.Json.Serialization;

namespace DotnetRPG.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum RPGClass
    {
        Knight,Mage,Cleric
    }
}