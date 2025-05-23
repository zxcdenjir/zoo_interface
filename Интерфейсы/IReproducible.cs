public interface IReproducible<T> 
{
    T Reproduce(int id, string name);
}