using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Todo: spawn multiple enemies at once
//Todo: can only spawn a certain number of enemies per round

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;

    float maxSpawnRateInSeconds = 3f;

    bool canSpawn = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Spawn()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//Bottom left of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Top right of screen

        GameObject anEnemy = (GameObject)Instantiate(enemyPrefab);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        canSpawn = false;
        //yield return new WaitForSeconds(maxSpawnRateInSeconds);
        Invoke("Spawn", maxSpawnRateInSeconds);
        canSpawn = true;
    }

    public void StartSpawner()
    {
        Invoke("Spawn", maxSpawnRateInSeconds);
    }

    public void StopSpawner()
    {
        CancelInvoke("Spawn");
    }
}
