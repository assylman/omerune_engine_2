using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private Transform characterTransform;

    [SerializeField]
    private float defaultSpeed;

    public Transform CharacterTransform => characterTransform;
    public CharacterController CharacterController => characterController;
    public float DefaultSpeed => defaultSpeed;
}
