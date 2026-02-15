using UnityEngine;

[CreateAssetMenu(fileName = "GameData")]
public class GameData : ScriptableObject
{
    [SerializeField] private int sessionTimeMinutes = 15;
    [SerializeField] private float timeBetweenEnemySpawns = 1.5f;
    [SerializeField] private float minEnemySpawnOffset = 7;
    [SerializeField] private float maxEnemySpawnOffset = 18;
    [SerializeField] private int maxEnemyOnScreen = 5;


    public int SessionTimeMinutes => sessionTimeMinutes;
    public int SessionTimeSeconds => sessionTimeMinutes * 60;
    public float TimeBetweenEnemySpawns => timeBetweenEnemySpawns;
    public float MinEnemySpawnOffset => minEnemySpawnOffset;
    public float MaxEnemySpawnOffset => maxEnemySpawnOffset;
    public int MaxEnemyOnScreen => maxEnemyOnScreen;
}
