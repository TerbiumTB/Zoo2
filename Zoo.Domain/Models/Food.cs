namespace Zoo.Domain.Models;

using System.Text.Json.Serialization;



// [JsonConverter(typeof(JsonStringEnumConverter))]
// public enum Food
// {
//     Carrot,
//     Meat,
//     Fish,
//     Corn,
// }

public record Food(string Name, AnimalType Type);
// {
//     public string Name { get; }
//     public AnimalType Type { get; }
//     public _Food(string name)
//     {
//         
//     }
// }