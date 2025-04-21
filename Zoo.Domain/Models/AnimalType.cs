using System.Text.Json.Serialization;

namespace Zoo.Domain.Models;



[JsonConverter(typeof(JsonStringEnumConverter))]
public enum AnimalType
{
    Herbo,
    Predator,
    Aquatic,
    Flying
}