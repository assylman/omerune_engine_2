using UnityEngine;

public class DefaultControlsComponent : IControlsComponent
{
    private Character character;

    public void Initialize(Character character)
    {
        this.character = character;
    }

    public void OnUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(horizontalInput, 0, verticalInput).normalized;

        character.MovementComponent.Move(moveDirection);
        character.MovementComponent.Rotate(moveDirection);
    }
}
