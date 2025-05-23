public interface IEnclosure<T>
{
    string EnclosureType { get; }
    void AddAnimal(T animal);
    void RemoveAnimal(T animal);
    List<T> GetAnimals();
}   