using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [SerializeField]
    private List<Transform> brains;

    [Header("Spawn values")]
    [SerializeField]
    private Transform spawnPointsParent;
    List<Transform> spawnPoints = new List<Transform>();
    [SerializeField]
    private EnemyMovement enemyPrefab;

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
            SpawnEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GetRandomSpawnPoint(), Quaternion.identity);
    }

    private Vector3 GetRandomSpawnPoint()
    {
        var point = spawnPoints[Random.Range(0, spawnPoints.Count)];
        return point.position;
    }
}
