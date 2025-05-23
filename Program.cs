class Program
{
    static void Main()
    {
        Enclosure<Mammals> mammalEnclosure = new Enclosure<Mammals>("Вольер для млекопитающих");
        Enclosure<Birds> birdEnclosure = new Enclosure<Birds>("Вольер для птиц");
        Enclosure<Aquatic> aquaticEnclosure = new Enclosure<Aquatic>("Вольер для водных животных");


        mammalEnclosure.AddAnimal(new Lion(mammalEnclosure.GetAnimals().Count, "Leo", "Лев", 5, false, true));
        mammalEnclosure.AddAnimal(new Lion(mammalEnclosure.GetAnimals().Count, "Simba", "Лев", 3, false, true));

        birdEnclosure.AddAnimal(new Birds(birdEnclosure.GetAnimals().Count, "Aquila", "Орел", 2, false, true));
        birdEnclosure.AddAnimal(new Birds(birdEnclosure.GetAnimals().Count, "Sky", "Попугай", 1, false, true));

        aquaticEnclosure.AddAnimal(new Dolphin(aquaticEnclosure.GetAnimals().Count, "Flipper", "Дельфин", 4, false, true));
        aquaticEnclosure.AddAnimal(new Dolphin(aquaticEnclosure.GetAnimals().Count, "Splash", "Дельфин", 2, false, true));

        Console.WriteLine();
        ZooManager.AddEnclosure(mammalEnclosure);
        ZooManager.AddEnclosure(birdEnclosure);
        ZooManager.AddEnclosure(aquaticEnclosure);

        Console.WriteLine();
        ZooManager.PrintPopulationStatistic();

        Console.WriteLine();
        Console.WriteLine("\nСодержимое вольеров:");
        Console.WriteLine(mammalEnclosure.EnclosureType);
        mammalEnclosure.PrintEnclosure();

        Console.WriteLine("\n" + birdEnclosure.EnclosureType);
        birdEnclosure.PrintEnclosure();

        Console.WriteLine("\n" + aquaticEnclosure.EnclosureType);
        aquaticEnclosure.PrintEnclosure();

        Console.WriteLine();
        Console.WriteLine("\nПоиск животных по возрасту (0-5):");
        List<Mammals> foundMammals = mammalEnclosure.FindAnimalsByAge(0, 5);
        Console.WriteLine(mammalEnclosure.EnclosureType + ": найдено " + foundMammals.Count + " животных");
        List<Birds> foundBirds = birdEnclosure.FindAnimalsByAge(0, 5);
        Console.WriteLine(birdEnclosure.EnclosureType + ": найдено " + foundBirds.Count + " животных");
        List<Aquatic> foundAquatics = aquaticEnclosure.FindAnimalsByAge(0, 5);
        Console.WriteLine(aquaticEnclosure.EnclosureType + ": найдено " + foundAquatics.Count + " животных");

        Console.WriteLine("\nДемонстрация возможностей животных:");
        mammalEnclosure.GetAnimals()[0].Move();
        birdEnclosure.GetAnimals()[0].Fly();
        aquaticEnclosure.GetAnimals()[0].Swim();
    }
}