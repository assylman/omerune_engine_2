using System;
using NUnit.Framework.Constraints;
using UnityEngine;

public class HealthComponent : IHealthComponent
{
    private float health = 25;
    private float maxHealth = 100;

    public float Health
    {
        get => health;
        private set
        {
            health = Mathf.Clamp(value, 0, MaxHealth);
            if (health == 0)
                SetDeath();
        }
    }

    public float MaxHealth => maxHealth;

    private void SetDeath()
    {
        throw new NotImplementedException();
    }

    public void SetDemage(int damage)
    {
        Health -= damage;
    }
}
