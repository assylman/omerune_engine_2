using System;
using NUnit.Framework.Constraints;
using UnityEngine;

public class HealthComponent : IHealthComponent
{
    private Character selfCharacter;
    private float currentHealth = 25;
    private float maxHealth = 40;

    public event Action<Character> OnCharacterDeath;

    public float Health
    { 
        get => currentHealth;
        private set
        {
            currentHealth = value;
            if (currentHealth > MaxHealth)
                currentHealth = MaxHealth;
            if (currentHealth <= 0) 
            {
                currentHealth = 0;
                SetDeath();
            }
        }
    }

    public float MaxHealth => maxHealth;

    private void SetDeath()
    {
        OnCharacterDeath?.Invoke(selfCharacter);
        Debug.Log("Character " + selfCharacter.name + " is dead.");
    }

    public void SetDemage(int damage)
    {
        Health -= damage;
        Debug.Log("Took damage: " + damage + ". Current health: " + Health);
    }

    public void Initialize(Character selfCharacter)
    {
        Debug.Log("Initializing HealthComponent for " + selfCharacter.name);
        this.selfCharacter = selfCharacter;
        Health = MaxHealth;
    }
}
