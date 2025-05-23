class Enclosure<T> : IEnclosure<T> where T : IAnimal
{
    public string EnclosureType { get; }
    public List<T> Animals { get; } = [];

    public Enclosure(string enclosureType)
    {
        EnclosureType = enclosureType;
    }

    public void AddAnimal(T animal)
    {
        Animals.Add(animal);
        Console.WriteLine($"Добавлено новое животное в {EnclosureType}");
    }
    public void RemoveAnimal(T animal)
    {
        Animals.Remove(animal);
        Console.WriteLine($"Животное было убрано из {EnclosureType}");
    }
    public List<T> GetAnimals()
    {
        return Animals;
    }
    public List<T> FindAnimalsByAge(int minAge, int maxAge)
    {
        List<T> tmp = [];
        foreach (T animal in Animals)
        {
            if (animal.Age >= minAge && animal.Age <= maxAge)
            {
                tmp.Add(animal);
            }
        }
        return tmp;
    }

    public void PrintEnclosure()
    {
        Console.WriteLine($"|----|-----------------|-------------------|---------|-----------|--------|---------|");
        Console.WriteLine($"| ID | {"Имя",15} | {"Вид",17} | Возраст | Накормлен | Здоров | Тип еды |");
        Console.WriteLine($"|----|-----------------|-------------------|---------|-----------|--------|---------|");
        foreach (T animal in Animals)
        {
            Console.Write($"| {animal.Id,2} ");
            Console.Write($"| {animal.Name,15} ");
            Console.Write($"| {animal.Species,17} ");
            Console.Write($"| {animal.Age,7} ");
            Console.Write($"| {(animal.IsFed ? "Да" : "Нет"),9} ");
            Console.Write($"| {(animal.IsHealthy ? "Да" : "Нет"),6} ");
            Console.WriteLine($"| {animal.FoodType,7} |");
        }
        Console.WriteLine($"|----|-----------------|-------------------|---------|-----------|--------|---------|");
    }
}