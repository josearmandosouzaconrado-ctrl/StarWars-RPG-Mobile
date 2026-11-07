using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieGameManager : MonoBehaviour
{
    public static ZombieGameManager Instance { get; private set; }

    [Header("Progression")]
    [SerializeField] private int currentWave = 1;
    [SerializeField] private int score = 0;
    [SerializeField] private int playerLives = 3;
    [SerializeField] private float waveDelay = 2.5f;

    [Header("Spawn")]
    [SerializeField] private ZombieWaveSpawner zombieWaveSpawner;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private int zombiesPerWave = 6;

    private readonly List<ZombieEnemy> activeZombies = new();
    private bool isWaveRunning;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        if (playerTransform == null)
        {
            var player = FindObjectOfType<MobilePlayerController>();
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }

        StartCoroutine(SpawnWaveRoutine());
    }

    public void RegisterPlayer(Transform player)
    {
        playerTransform = player;
    }

    public void RegisterZombie(ZombieEnemy zombie)
    {
        if (!activeZombies.Contains(zombie))
        {
            activeZombies.Add(zombie);
        }
    }

    public void OnZombieKilled(ZombieEnemy zombie)
    {
        if (activeZombies.Contains(zombie))
        {
            activeZombies.Remove(zombie);
        }

        score += 10;

        if (activeZombies.Count == 0 && !isWaveRunning)
        {
            StartCoroutine(SpawnWaveRoutine());
        }
    }

    public void OnPlayerDefeated()
    {
        playerLives--;
        Debug.Log("Jogador foi atingido! Vidas restantes: " + playerLives);

        if (playerLives <= 0)
        {
            Debug.Log("Game Over - o exército zumbi venceu.");
            Time.timeScale = 0f;
        }
        else
        {
            if (playerTransform != null)
            {
                playerTransform.position = Vector3.zero;
            }
        }
    }

    private IEnumerator SpawnWaveRoutine()
    {
        isWaveRunning = true;
        yield return new WaitForSeconds(waveDelay);

        if (zombieWaveSpawner != null)
        {
            zombieWaveSpawner.SpawnWave(currentWave, zombiesPerWave, playerTransform);
        }
        else if (zombiePrefab != null)
        {
            SpawnFallbackWave();
        }

        currentWave++;
        isWaveRunning = false;
    }

    private void SpawnFallbackWave()
    {
        int count = zombiesPerWave + currentWave;

        for (int i = 0; i < count; i++)
        {
            Transform spawn = spawnPoints != null && spawnPoints.Length > 0
                ? spawnPoints[Random.Range(0, spawnPoints.Length)]
                : null;

            Vector3 position = spawn != null
                ? spawn.position + new Vector3(Random.Range(-2f, 2f), 0f, Random.Range(-2f, 2f))
                : new Vector3(Random.Range(-10f, 10f), 0f, Random.Range(-10f, 10f));

            var zombieObject = Instantiate(zombiePrefab, position, Quaternion.identity);
            var zombie = zombieObject.GetComponent<ZombieEnemy>();
            if (zombie != null)
            {
                zombie.Initialize(playerTransform, 1f + (currentWave * 0.15f));
                RegisterZombie(zombie);
            }
        }
    }

    public int Score => score;
    public int CurrentWave => currentWave;
    public int PlayerLives => playerLives;
}
