using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    [SerializeField] EnemyController enemyToSpawn;
    //private List<Transform> spawnLocations = new List<Transform>();
    [SerializeField] Transform spawnLocation;

    [Header("Spawn Values")]
    [SerializeField] float spawnTimer;
    [SerializeField] int startNumber;
    [SerializeField] float difficultyTimer;

    private int spawnNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        //for(int i = 0; i < transform.childCount; i++)
        //{
        //    spawnLocations.Add(transform.GetChild(i).GetComponent<Transform>());
        //}

        for(int i = 0; i < startNumber; i++)
        {
            float randomX = Random.Range(-45f, 45f);
            float randomZ = Random.Range(-45f, 45f);
            //spawnLocation.position = new Vector3(randomX, 2, randomZ);
            EnemyController temp = Instantiate(enemyToSpawn, spawnLocation);
            temp.transform.position = new Vector3(randomX, 2, randomZ);
        }

        StartCoroutine(SpawnEnemy());
    }

    IEnumerator IncreaseDifficulty()
    {
        while (GameManager.playerState == GameManager.PlayerState.Playing)
        {
            yield return new WaitForSeconds(difficultyTimer);
            spawnNumber++;
        }
    }

    IEnumerator SpawnEnemy()
    {
        while(GameManager.playerState == GameManager.PlayerState.Playing)
        {
            yield return new WaitForSeconds(spawnTimer);
            for (int i = 0; i < spawnNumber; i++)
            {
                float randomX = Random.Range(-45f, 45f);
                float randomZ = Random.Range(-45f, 45f);
                //spawnLocation.position = new Vector3(randomX, 2, randomZ);
                EnemyController temp = Instantiate(enemyToSpawn, spawnLocation);
                temp.transform.position = new Vector3(randomX, 2, randomZ);
            }
        }
        
    }
}
