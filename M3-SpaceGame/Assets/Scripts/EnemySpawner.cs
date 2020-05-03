using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Todo: spawn multiple enemies at once


public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameManager gameManager;

    List<GameObject> enemyList;

    float maxSpawnRateInSeconds = 2f;

    int numSpawnPerRound = 5;
    int numLeft;

    public void Start()
    {
        enemyList = new List<GameObject>();
        numLeft = numSpawnPerRound;
    }

    public void Update()
    {
        if (numLeft == 0 && enemyList.Count.Equals(0))
        {   
            numLeft = -1;
            gameManager.EndRound();
        }
    }

    public void Spawn()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//Bottom left of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Top right of screen

        GameObject anEnemy = (GameObject)Instantiate(enemyPrefab);
        anEnemy.transform.position = new Vector2(Random.Range(min.x + 1, max.x - 1), max.y);

        enemyList.Add(anEnemy);
        //Debug.Log("Spawned: " + enemyList.Count);

        //Increase the health of each enemy by the round number for now
        int roundNumber = gameManager.GetComponent<GameManager>().GetRoundNumber();
        anEnemy.GetComponent<EnemyControl>().IncreaseHealth(roundNumber - 1);

        //yield return new WaitForSeconds(maxSpawnRateInSeconds);
        Invoke("Spawn", maxSpawnRateInSeconds);

        numLeft--;
        if(numLeft <= 0)
        {
            StopSpawner();
        }
        
    }

    public void StartSpawner()
    {
        numLeft = numSpawnPerRound + gameManager.GetComponent<GameManager>().GetRoundNumber();
        Invoke("Spawn", 0);
    }

    public void StopSpawner()
    {
        CancelInvoke("Spawn");
    }

    public void removeEnemyFromList(GameObject enemy)
    {
        enemyList.Remove(enemy);
        //Debug.Log("Removed: " + enemyList.Count);
    }
}
