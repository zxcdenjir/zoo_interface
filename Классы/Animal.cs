public abstract class Animal : IAnimal, IMovable, ISoundMaker, IFeedable, IReproducible<Animal>, IZooNotifier
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public int Age { get; set; }
    public bool IsFed { get; set; }
    public bool IsHealthy { get; set; }
    public FoodType FoodType { get; set; }

    public event Action<string> AnimalFed;

    public event Action<string> AnimalReproduced;

    public event Action<string> AnimalHealthChanged;

    public void NotifyAnimalFed(string obj)
    {
        Console.WriteLine(obj);
    }
    public void NotifyAnimalReprodusced(string obj)
    {
        Console.WriteLine(obj);
    }
    public void NotifyAnimalHealthChanged(string obj)
    {
        Console.WriteLine(obj);
    }

    protected Animal(int id, string? name, string? species, int age, bool isFed, bool isHealthy, FoodType foodType)
    {
        Id = id;
        Name = name;
        Species = species;
        Age = age;
        IsFed = isFed;
        IsHealthy = isHealthy;
        FoodType = foodType;
        AnimalFed += NotifyAnimalFed;
        AnimalReproduced += NotifyAnimalReprodusced;
        AnimalHealthChanged += NotifyAnimalHealthChanged;
    }

    public void Move()
    {
        Console.WriteLine($"{Name} двигается");
    }
    public virtual void MakeSound()
    {
        Console.WriteLine($"{Name} издает звук");
    }
    public void Feed(FoodType foodType)
    {
        if (foodType != FoodType)
            AnimalFed.Invoke($"Животное {Name} не ест тип еды {foodType}");
        else
        {
            IsFed = true;
            AnimalFed.Invoke($"Животное {Name} накормлено {foodType}");
        }
    }
    public abstract Animal Reproduce(int id, string name);

    public void SetHealth(bool newHealth)
    {
        if (IsHealthy != newHealth)
        {
            IsHealthy = newHealth;
            AnimalHealthChanged.Invoke($"Животное {Name} стало {(newHealth ? "здоровым" : "больным")}");
        }
    }

    public override string ToString()
    {
        return $"Id: {Id}, Имя: {Name}, Вид: {Species}, Возраст: {Age}, Накормлен: {(IsFed ? "Да" : "Нет")}, Здоров: {(IsHealthy ? "Да" : "Нет")}, Тип еды: {FoodType}";
    }
}

class Mammals : Animal
{
    private event Action<string> AnimalReproduced;
    public Mammals(int id, string? name, string? species, int age, bool isFed, bool isHealthy)
    : base(id, name, species, age, isFed, isHealthy, FoodType.Мясо)
    {
        AnimalReproduced += NotifyAnimalReprodusced;
    }

    public override void MakeSound()
    {
        Console.WriteLine($"{Name} издает звук, характерный для млекопитающих");
    }
    public override Mammals Reproduce(int id, string name)
    {
        AnimalReproduced.Invoke($"Животное {Name} родило детёныша");
        return new Mammals(id, name, Species, 0, false, true);
    }
}

class Birds : Animal, IFlyable
{
    public event Action<string> AnimalReproduced;

    public Birds(int id, string? name, string? species, int age, bool isFed, bool isHealthy)
    : base(id, name, species, age, isFed, isHealthy, FoodType.Зерно)
    {
        AnimalReproduced += NotifyAnimalReprodusced;
    }

    public void Fly()
    {
        Console.WriteLine($"{Name} летает");
    }
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} издает звук, характерный для птиц");
    }
    public override Birds Reproduce(int id, string name)
    {
        AnimalReproduced.Invoke($"Животное {Name} родило детёныша");
        return new Birds(id, name, Species, 0, false, true);
    }
}

class Aquatic : Animal, ISwimmable
{
    public event Action<string> AnimalReproduced;

    public Aquatic(int id, string? name, string? species, int age, bool isFed, bool isHealthy)
    : base(id, name, species, age, isFed, isHealthy, FoodType.Рыба)
    {
        AnimalReproduced += NotifyAnimalReprodusced;
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} плавает");
    }
    public override void MakeSound()
    {
        Console.WriteLine($"{Name} издает звук, характерный для водных обитателей");
    }
    public override Aquatic Reproduce(int id, string name)
    {
        AnimalReproduced.Invoke($"Животное {Name} родило детёныша");
        return new Aquatic(id, name, Species, 0, false, true);
    }
}

class Lion : Mammals
{
    public Lion(int id, string name, string? species, int age, bool isFed, bool isHealthy) : base(id, name, species, age, isFed, isHealthy)
    {
        AnimalReproduced += NotifyAnimalReprodusced;
    }
    public event Action<string> AnimalReproduced;
    public override Lion Reproduce(int id, string name)
    {
        AnimalReproduced.Invoke($"Животное {Name} родило детёныша");
        return new Lion(id, name, Species, 0, false, true);
    }
}

class Eagle : Birds
{
    public Eagle(int id, string name, string? species, int age, bool isFed, bool isHealthy) : base(id, name, species, age, isFed, isHealthy)
    {
        AnimalReproduced += NotifyAnimalReprodusced;
    }

    public event Action<string> AnimalReproduced;
    public override Eagle Reproduce(int id, string name)
    {
        AnimalReproduced.Invoke($"Животное {Name} родило детёныша");
        return new Eagle(id, name, Species, 0, false, true);
    }
}
class Dolphin : Aquatic
{
    public Dolphin(int id, string name, string? species, int age, bool isFed, bool isHealthy) : base(id, name, species, age, isFed, isHealthy)
    {
        AnimalReproduced += NotifyAnimalReprodusced;
    }

    public event Action<string> AnimalReproduced;
    public override Dolphin Reproduce(int id, string name)
    {
        AnimalReproduced.Invoke($"Животное {Name} родило детёныша");
        return new Dolphin(id, name, Species, 0, false, true);
    }
}