using UnityEngine;

public interface IMovementComponent
{
    float Speed { get; set; }
    Vector3 Position { get; }

    public void Initialize(Character character);

    void Move(Vector3 direction);
    void Rotate(Vector3 direction);
}
