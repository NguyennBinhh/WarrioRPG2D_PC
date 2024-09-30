
using UnityEngine;

public class SpawnMonster : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] List_PointSpw;
    public Transform Player;
    public float spawnInterval = 2f;
    public int maxEnemies = 15;
    public int currentEnemyCount = 0;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
    }

    void SpawnEnemy()
    {
        if (currentEnemyCount < maxEnemies)
        {
            Vector2 spawnPosition = List_PointSpw[Random.Range(0, 8)].position;
            Instantiate(enemyPrefab, spawnPosition , Quaternion.identity);
            currentEnemyCount++;
            Debug.Log(spawnPosition);
        }
    }
}
