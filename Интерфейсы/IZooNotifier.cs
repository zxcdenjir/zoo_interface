public interface IZooNotifier
{
    public event Action<string> AnimalFed;
    public event Action<string> AnimalReproduced;
    public event Action<string> AnimalHealthChanged;

    public void NotifyAnimalFed(string obj);
    public void NotifyAnimalReprodusced(string obj);
    public void NotifyAnimalHealthChanged(string obj);

}