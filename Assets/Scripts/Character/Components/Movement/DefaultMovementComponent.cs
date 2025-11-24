using UnityEngine;

public class DefaultMovementComponent : IMovementComponent
{
    private Character character;
    private float speed;
    public float Speed
    {
        get => speed;
        set
        {
            if (value < 0)
                speed = 0;
            else
                speed = value;
        }
    }

    public Vector3 Position => character.transform.position;

    public void Initialize(Character character)
    {
        this.character = character;
        speed = character.CharacterData.DefaultSpeed;
    }

    public void Move(Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;

        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        Vector3 movement = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
        character.CharacterData.CharacterController.Move(movement * Speed * Time.deltaTime);
    }

    public void Rotate(Vector3 direction)
    {
        if (direction == Vector3.zero)
            return;

        float turnSmoothTime = 0.1f;
        float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(
            character.CharacterData.CharacterTransform.eulerAngles.y,
            targetAngle,
            ref turnSmoothTime,
            turnSmoothTime
        );
        character.CharacterData.CharacterTransform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
