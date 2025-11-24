using UnityEngine;

public class DefaultAiControlsComponent : IControlsComponent
{
    private Character character;

    public void Initialize(Character character)
    {
        this.character = character;
    }

    public void OnUpdate()
    {
        Vector3 moveDirection = character.Target.transform.position - character.transform.position;
        moveDirection.Normalize();
        character.MovementComponent.Move(moveDirection);
        character.MovementComponent.Rotate(moveDirection);
    }
}
