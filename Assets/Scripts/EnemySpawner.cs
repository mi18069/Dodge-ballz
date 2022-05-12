using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Vector3 spawnPoint;

    [SerializeField] private List<GameObject> enemies;
    [SerializeField] private int spawnTime;

    [SerializeField] private int maxEnemy;
    private int enemyCount;

    private void Awake()
    {
        enemies = new List<GameObject>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator SpawnCoroutine()
    {
        yield return new WaitForSecondsRealtime(3f);
        while(true)
        {        
            GameObject instantiatedEnemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            instantiatedEnemy.tag="Enemy";
            enemies.Add(instantiatedEnemy);

            UIScoreCounter.scoreAmount += 10;

            enemyCount++;

            if(enemyCount >= maxEnemy){
                yield break;
            }

            yield return new WaitForSecondsRealtime(spawnTime);
        }
    }
}
