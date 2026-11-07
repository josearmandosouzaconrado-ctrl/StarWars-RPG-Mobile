using UnityEngine;

public class ZombieWaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject zombiePrefab;
    [SerializeField] private Transform[] spawnPoints;

    public void SpawnWave(int waveNumber, int baseZombies, Transform playerTarget)
    {
        if (zombiePrefab == null)
        {
            return;
        }

        int totalZombies = baseZombies + (waveNumber - 1) * 2;

        for (int i = 0; i < totalZombies; i++)
        {
            Transform spawn = spawnPoints != null && spawnPoints.Length > 0
                ? spawnPoints[Random.Range(0, spawnPoints.Length)]
                : null;

            Vector3 pos = spawn != null
                ? spawn.position + new Vector3(Random.Range(-2.5f, 2.5f), 0f, Random.Range(-2.5f, 2.5f))
                : new Vector3(Random.Range(-12f, 12f), 0f, Random.Range(-12f, 12f));

            GameObject zombieObject = Instantiate(zombiePrefab, pos, Quaternion.identity);
            ZombieEnemy zombieEnemy = zombieObject.GetComponent<ZombieEnemy>();

            if (zombieEnemy != null)
            {
                zombieEnemy.Initialize(playerTarget, 1f + waveNumber * 0.12f);
                if (ZombieGameManager.Instance != null)
                {
                    ZombieGameManager.Instance.RegisterZombie(zombieEnemy);
                }
            }
        }
    }
}
