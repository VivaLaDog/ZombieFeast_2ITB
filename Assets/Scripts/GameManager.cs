using System.Collections;
using System.Collections.Generic;
<<<<<<< Updated upstream
=======
using System.Linq;
using TMPro;
>>>>>>> Stashed changes
using UnityEngine;
using UnityEngine.SceneManagement;

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

    [SerializeField]
    private GameObject endGameScreen;
    [SerializeField]
    private TMPro.TMP_Text timeText;

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
        Time.timeScale = 1;
        StartCoroutine(SpawnEnemies());
    }

    [SerializeField]
    Camera cam;

    private float timeAlive = 0;
    void Update()
    {
        CheckMouse();
        timeAlive += Time.deltaTime;
    }

    private void CheckMouse()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("sex");
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Debug.Log("sex2" + hit.transform.name);
                var res = hit.transform;

                //if (res == null) return;

                if (res.name.Contains("Enemy"))
                {
                    Debug.Log(res.name);
                    EnemyStats en = res.GetComponent<EnemyStats>();
                    en.TakeDamage(50);
                }
            }
        }
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

    
    public void EndGame() //holy shit marvel reference
    {
        endGameScreen.SetActive(true);
        var levelName = SceneManager.GetActiveScene().name;
        float bestTime = PlayerPrefs.GetFloat(levelName, 0f);
        if (bestTime > timeAlive)
        {
            PlayerPrefs.SetFloat("Level1", timeAlive);
            timeText.text = $"You survived {timeAlive} seconds. New top!";
        }
        else
        {
            timeText.text = $"You survived {timeAlive} seconds. Better luck next time!";
        }
        Time.timeScale = 0;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
