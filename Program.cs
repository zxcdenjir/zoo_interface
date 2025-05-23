class Program
{
    static void Main()
    {
        Enclosure<IAnimal> mammalEnclosure = new("Вольер для млекопитающих");
        Enclosure<IAnimal> birdEnclosure = new("Вольер для птиц");
        Enclosure<IAnimal> aquaticEnclosure = new("Вольер для водных животных");


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

        Console.WriteLine("\nСодержимое вольеров:");
        Console.WriteLine(mammalEnclosure.EnclosureType);
        mammalEnclosure.PrintEnclosure();

        Console.WriteLine("\n" + birdEnclosure.EnclosureType);
        birdEnclosure.PrintEnclosure();

        Console.WriteLine("\n" + aquaticEnclosure.EnclosureType);
        aquaticEnclosure.PrintEnclosure();

        Console.WriteLine();
        Console.WriteLine("\nПоиск животных по возрасту (1-3):");
        List<IAnimal> foundMammals = mammalEnclosure.FindAnimalsByAge(1, 3);
        Console.WriteLine(mammalEnclosure.EnclosureType + ": найдено " + foundMammals.Count + " животных");
        foreach (Animal a in foundMammals)
            Console.WriteLine(a);
        Console.WriteLine();

        List<IAnimal> foundBirds = birdEnclosure.FindAnimalsByAge(1, 3);
        Console.WriteLine(birdEnclosure.EnclosureType + ": найдено " + foundBirds.Count + " животных");
        foreach (Animal a in foundBirds)
            Console.WriteLine(a);
        Console.WriteLine();

        List<IAnimal> foundAquatics = aquaticEnclosure.FindAnimalsByAge(1, 3);
        Console.WriteLine(aquaticEnclosure.EnclosureType + ": найдено " + foundAquatics.Count + " животных");
        foreach (Animal a in foundAquatics)
            Console.WriteLine(a);
        Console.WriteLine();

        Console.WriteLine("\nДемонстрация возможностей животных:");
        if (mammalEnclosure.GetAnimals()[0] is Lion lion)
        {
            lion.Move();
            lion.Feed(FoodType.Мясо);
            lion.Feed(FoodType.Рыба);
        }
        if (birdEnclosure.GetAnimals()[0] is Birds bird)
        {
            bird.Fly();
        }
        if (aquaticEnclosure.GetAnimals()[0] is Dolphin dolphin)
        {
            dolphin.Swim();
        }
    }
}   