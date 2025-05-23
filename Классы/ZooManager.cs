class ZooManager
{
    public static List<Enclosure<IAnimal>> enclosures = [];

    public static void AddEnclosure(Enclosure<IAnimal> enclosure)
    {
        enclosures.Add(enclosure);
        Console.WriteLine("Вольер добавлен в список вольеров");
    }
    public static void RemoveEnclosure<T>(Enclosure<IAnimal> enclosure)
    {
        enclosures.Remove(enclosure);
        Console.WriteLine("Вольер убран из списка вольеров");
    }
    
    public static void PrintPopulationStatistic()
    {
        Console.WriteLine("Количество животных в зоопарке: ");
        foreach (Enclosure<IAnimal> enclosure in enclosures)
        {
            Console.WriteLine($"{enclosure.EnclosureType}: {enclosure.GetAnimals().Count} животных");
        }
    }
    
}