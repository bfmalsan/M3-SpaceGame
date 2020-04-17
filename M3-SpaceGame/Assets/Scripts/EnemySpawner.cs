using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Todo: spawn multiple enemies at once
//Todo: can only spawn a certain number of enemies per round

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameManager gameManager;

    float maxSpawnRateInSeconds = 3f;

    int numSpawnPerRound = 10;
    int numLeft;


    public void Spawn()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//Bottom left of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Top right of screen

        GameObject anEnemy = (GameObject)Instantiate(enemyPrefab);
        anEnemy.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        //Increase the health of each enemy by the round number for now
        int roundNumber = gameManager.GetComponent<GameManager>().GetRoundNumber();
        if (roundNumber > 1)
        {
            anEnemy.GetComponent<EnemyControl>().IncreaseHealth(roundNumber - 1);
        }

        //yield return new WaitForSeconds(maxSpawnRateInSeconds);
        Invoke("Spawn", maxSpawnRateInSeconds);

        numLeft--;
        if(numLeft < 0)
        {
            gameManager.EndRound();
        }
        
    }

    public void StartSpawner()
    {
        numLeft = numSpawnPerRound;
        Invoke("Spawn", maxSpawnRateInSeconds);
    }

    public void StopSpawner()
    {
        CancelInvoke("Spawn");
    }
}
