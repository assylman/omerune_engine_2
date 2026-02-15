using UnityEngine;

public class AttackComponent : IAttackComponent
{
    private Character character;
    public float Damage => 10;

    public float AttackRange => 0.2f;

    public void Initialize(Character character)
    {
        this.character = character;
    }

    public void MakeDamage(Character attackTarget)
    {
        character.HealthComponent.SetDemage((int)Damage);
    }
}
