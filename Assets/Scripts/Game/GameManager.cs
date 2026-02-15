using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameData gameData;
    [SerializeField] private CharactorFactory charactorFactory;
    public CharactorFactory CharactorFactory => charactorFactory;

    private ScoreSystem scoreSystem;

    private float gameSessionTime;
    private float timeBetweenEnemySpawns;
    private int maxEnemyOnScreen;
    private bool isGameActive;

    public static GameManager Instance { get; private set; }


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Initialize();
        }
        else
        {
            Destroy(this);
        }
    }

    private void Initialize()
    {
        scoreSystem = new ScoreSystem();
        isGameActive = false;
    }

    public void StartGame()
    {
        if (isGameActive)
        {
            return;
        }

        Character player = charactorFactory.GetCharacter(CharacterType.Player);
        player.transform.position = Vector3.zero;
        player.gameObject.SetActive(true);
        player.Initialize();
        player.HealthComponent.OnCharacterDeath += CharacterDeathHandler;


        scoreSystem.StartGame();

        gameSessionTime = 0;
        maxEnemyOnScreen = 0;
        timeBetweenEnemySpawns = gameData.TimeBetweenEnemySpawns;

        isGameActive = true;
    }

    private void Update()
    {
        if (!isGameActive)
        {
            return;
        }

        gameSessionTime += Time.deltaTime;
        timeBetweenEnemySpawns -= Time.deltaTime;

        if (timeBetweenEnemySpawns <= 0)
        {
            timeBetweenEnemySpawns = gameData.TimeBetweenEnemySpawns;
            SpawnEnemy();
        }

        if (gameSessionTime >= gameData.SessionTimeSeconds)
        {
            GameVictory();
            return;
        }
    }

    private void CharacterDeathHandler(Character deadCharacter)
    {
        Debug.Log("[CharacterDeathHandler] Character " + deadCharacter.name + " is dead. Type: " + deadCharacter.CharacterType);
        switch (deadCharacter.CharacterType)
        {
            case CharacterType.Player:
                GameOver();
                break;
            case CharacterType.Enemy:
                maxEnemyOnScreen -= 1;
                scoreSystem.AddScore(deadCharacter.CharacterData.ScoreCost);
                break;
        }
        deadCharacter.gameObject.SetActive(false);
        charactorFactory.ReturnCharacter(deadCharacter);
        deadCharacter.HealthComponent.OnCharacterDeath -= CharacterDeathHandler;
    }

    private void SpawnEnemy()
    {
        if (maxEnemyOnScreen >= gameData.MaxEnemyOnScreen)
        {
            return;
        }

        Character enemy = charactorFactory.GetCharacter(CharacterType.Enemy);
        Vector3 playerPosition = charactorFactory.Player.transform.position;
        enemy.transform.position = new Vector3(playerPosition.x + GetOffset(), 0, playerPosition.z + GetOffset());
        enemy.gameObject.SetActive(true);
        enemy.Initialize();
        maxEnemyOnScreen += 1;
        enemy.HealthComponent.OnCharacterDeath += CharacterDeathHandler;

        float GetOffset()
        {
            bool isPlus = Random.Range(0, 100) % 2 == 0;
            float offset = Random.Range(gameData.MinEnemySpawnOffset, gameData.MaxEnemySpawnOffset);
            return isPlus ? offset : -offset;
        }
    }

    private void GameVictory()
    {
        Debug.Log("Victory!");
        isGameActive = false;
        scoreSystem.EndGame();
    }

    private void GameOver()
    {
        Debug.Log("Game Over!");
        isGameActive = false;
        scoreSystem.EndGame();
    }
}
