using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float spawnTime = 3f;
    public GameObject enemy;
    public Transform[] spawnPoints;

    private void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    public void Spawn()
    {
        if (PlayerHealth.currentHealth <= 0)
            return;
        int spawnPointIndex = Random.Range(0, spawnPoints.Length);
        Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
    }
}
