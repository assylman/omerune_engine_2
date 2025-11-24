public interface IHealthComponent
{
    float Health { get; }
    float MaxHealth { get; }
    void SetDemage(int damage);
}
