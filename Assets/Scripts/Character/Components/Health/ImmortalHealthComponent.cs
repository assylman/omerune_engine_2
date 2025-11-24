using UnityEngine;

public class ImmortalHealthComponent : IHealthComponent
{
    public float Health => 100;

    public float MaxHealth => 100;

    public void SetDemage(int damage)
    {
        Debug.Log("Immortal character. Can't take damage");
    }
}
