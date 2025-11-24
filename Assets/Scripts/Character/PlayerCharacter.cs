using UnityEngine;

public class PlayerCharacter : Character
{
    public override Character Target => throw new System.NotImplementedException();

    public override void Initialize()
    {
        base.Initialize();
        HealthComponent = new ImmortalHealthComponent();

        ControlsComponent = new DefaultControlsComponent();
        ControlsComponent.Initialize(this);
    }

    protected override void Update()
    {
        if (HealthComponent.Health <= 0)
            return;

        ControlsComponent.OnUpdate();
    }
}
