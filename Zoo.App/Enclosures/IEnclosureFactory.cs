namespace Zoo.App.Enclosures;

using Domain.Models;
using Domain.Enclosures;



public interface IEnclosureFactory
{ 
    IEnclosure Create(AnimalType type, int capacity);
}