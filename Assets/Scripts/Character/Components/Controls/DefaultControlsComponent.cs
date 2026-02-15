using UnityEngine;
using UnityEngine.InputSystem;

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

        if (character.CharacterTarget == null)
        {
            character.MovementComponent.Rotate(moveDirection);
        }
        else
        {
            Vector3 rotationDirection = character.CharacterTarget.transform.position - character.transform.position;
            character.MovementComponent.Rotate(rotationDirection);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Attacking target: " + character.CharacterTarget.name);
                character.CharacterTarget.AttackComponent.MakeDamage(character.CharacterTarget);
            }
        }

        character.MovementComponent.Move(moveDirection);
    }
}
