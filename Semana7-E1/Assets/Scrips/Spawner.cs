using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour
{
    public int EnemySpawnCount { get; set; }
    private int currentLevel = 1;

    public GameObject enemyPrefab;
    public GameObject enemy2Prefab;

    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(2f);

            if (currentLevel == 1 && currentLevel <= 3)
            {
                Vector3 initialPosition = GetRandomSpawnPosition();
                int initialHealth = CalculateEnemyHealth(currentLevel);
                int initialDamage = 1;

                GameObject enemyGO = Instantiate(enemyPrefab, initialPosition, Quaternion.identity);
                Enemy enemy = enemyGO.GetComponent<Enemy>();
                enemy.Initialize(initialHealth, initialDamage);
                GameManager.Instance.AddEnemy(enemy);
            }
            else if (currentLevel >= 3 && currentLevel <= 10)
            {
                Vector3 initialPosition = GetRandomSpawnPosition();
                int initialHealth = CalculateEnemyHealth(currentLevel);
                int initialDamage = 2;

                GameObject enemy2GO = Instantiate(enemy2Prefab, initialPosition, Quaternion.identity);
                Enemy2 enemy2 = enemy2GO.GetComponent<Enemy2>();
                enemy2.Initialize(initialHealth, initialDamage);
                GameManager.Instance.AddEnemy2(enemy2);
            }
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        float minX = -10f;
        float maxX = 10f;
        float minY = -8f;
        float maxY = 8f;
        float minZ = -5f;
        float maxZ = 5f;
        float randomX = Random.Range(minX, maxX);
        float randomY = Random.Range(minY, maxY);
        float randomZ = Random.Range(minZ, maxZ);
        return new Vector3(randomX, randomY, randomZ);
    }

    private int CalculateEnemyHealth(int currentLevel)
    {
        int baseHealth = 3;
        int healthIncreasePerLevel = 1;

        if (currentLevel == 1)
        {
            return baseHealth;
        }
        else if (currentLevel == 2)
        {
            return baseHealth + healthIncreasePerLevel;
        }
        else if (currentLevel >= 3 && currentLevel <= 10)
        {
            return baseHealth + (currentLevel + 1) * healthIncreasePerLevel;
        }
        else
        {
            return baseHealth + 9 * healthIncreasePerLevel;
        }
    }

    public void LevelUp()
    {
        currentLevel++;
        EnemySpawnCount = 0;
    }
}
