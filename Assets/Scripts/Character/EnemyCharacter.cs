using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField]
    private Character characterTarget;

    public override Character Target => characterTarget;

    [SerializeField]
    private AiState aiState;

    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new HealthComponent();

        ControlsComponent = new DefaultAiControlsComponent();
        ControlsComponent.Initialize(this);
    }

    protected override void Update()
    {
        if (HealthComponent.Health <= 0)
            return;

        float distance = Vector3.Distance(characterTarget.transform.position, transform.position);
        if (distance <= AttackComponent.AttackRange)
        {
            aiState = AiState.Attack;
        }
        else
        {
            aiState = AiState.MoveToTarget;
        }

        switch (aiState)
        {
            case AiState.MoveToTarget:
                ControlsComponent.OnUpdate();
                return;
            case AiState.Attack:
                AttackComponent.MakeDamage(characterTarget);
                return;
        }
    }
}
