using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private bool spawn = true;

    [SerializeField]
    private List<Transform> brains;

    [Header("Spawn values")]
    [SerializeField]
    private Transform spawnPointsParent;
    List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private List<EnemyMovement> enemyPrefabs;

    [SerializeField]
    private List<SpawnData> enemyColors;

    [Range(0.25f,5)]
    [SerializeField]
    private float spawnInterval;

    private void Awake()
    {
        Instance = this;
        for(int i = 0; i < spawnPointsParent.childCount; i++)
        {
            spawnPoints.Add(spawnPointsParent.GetChild(i));
        }
    }

    public Transform GetClosestBrain(Vector3 position)
    {
        int indexOfClosestBrain = 0;
        float distance = 10000;
        for (int i = 0; i < brains.Count; i++) {
            float dist = Vector3.Distance(position, brains[i].position);
            if(dist < distance) { 
                indexOfClosestBrain = i; 
                distance = dist; 
            }
        }
        return brains[indexOfClosestBrain];
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while(true)
        {
            if(spawn)
                SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        var enemy = Instantiate(GetRandomPrefab(), GetRandomSpawnPoint(), Quaternion.identity);
        var color = GetColorForEnemy();
        var stats = enemy.GetComponent<EnemyStats>();
        stats.SetType(color.enemyColor, color.damage);
    }

    private EnemyMovement GetRandomPrefab()
    {
        return enemyPrefabs[UnityEngine.Random.Range(0, enemyPrefabs.Count)];
    }

    private SpawnData GetColorForEnemy()
    {
        int rnd = UnityEngine.Random.Range(0, 100);
        int lastSum = 0;
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            lastSum += enemyColors[i].probability;
            if (rnd <= lastSum) return enemyColors[i];
        }

        return enemyColors.Last();
    }

    private Vector3 GetRandomSpawnPoint()
    {
        var point = spawnPoints[UnityEngine.Random.Range(0, spawnPoints.Count)];
        return point.position;
    }
}

[Serializable]
public class SpawnData
{
    public int probability; // normal %
    public Material enemyColor;
    public int damage;
}