using System;
using UnityEngine;

public class ImmortalHealthComponent : IHealthComponent
{
    private Character selfCharacter;
    public float Health => 100;

    public float MaxHealth => 100;

    [Obsolete("Immortal character can't die, so this event will never be invoked.")]
    public event Action<Character> OnCharacterDeath;

    public void Initialize(Character selfCharacter)
    {
        this.selfCharacter = selfCharacter;
    }

    public void SetDemage(int damage)
    {
        Debug.Log("Immortal character. Can't take damage");
    }
}
