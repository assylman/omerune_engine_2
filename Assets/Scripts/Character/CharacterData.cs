using UnityEngine;

public class CharacterData : MonoBehaviour
{
    [SerializeField]
    private CharacterController characterController;

    [SerializeField]
    private Transform characterTransform;

    [SerializeField]
    private int scoreCost;

    [SerializeField]
    private float defaultSpeed;

    public Transform CharacterTransform => characterTransform;
    public CharacterController CharacterController => characterController;
    public float DefaultSpeed => defaultSpeed;
    public int ScoreCost => scoreCost;
}
