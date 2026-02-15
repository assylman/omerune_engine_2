using UnityEngine;

public class EnemyCharacter : Character
{
    [SerializeField]
    private AiState aiState;

    public override Character CharacterTarget => GameManager.Instance.CharactorFactory.Player;


    public override void Initialize()
    {
        Debug.Log("Initializing EnemyCharacter: " + name);
        base.Initialize();
        HealthComponent = new HealthComponent();
        HealthComponent.Initialize(this);

        ControlsComponent = new DefaultAiControlsComponent();
        ControlsComponent.Initialize(this);
    }

    protected override void Update()
    {
        if (HealthComponent.Health <= 0)
            return;

        float distance = Vector3.Distance(CharacterTarget.transform.position, transform.position);
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
                AttackComponent.MakeDamage(CharacterTarget);
                return;
        }
    }
}
