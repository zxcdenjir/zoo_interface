public interface IAnimal
{
    int Id { get; set; }
    string? Name { get; set; }
    string? Species { get; set; }
    int Age { get; set; }
    bool IsFed { get; set; }
    bool IsHealthy { get; set; }
    FoodType FoodType { get; set; }
}