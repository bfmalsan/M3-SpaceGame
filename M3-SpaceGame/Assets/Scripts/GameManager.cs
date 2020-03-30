using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerObject;
    public GameObject spawnerObject;

    public enum GameManagerState
    {
        Opening,
        GamePlay,
        GameOver,
    }

    GameManagerState gmState;

    // Start is called before the first frame update
    void Start()
    {
        gmState = GameManagerState.Opening;
    }

    void UpdateGameManagerState()
    {
        switch (gmState)
        {
            case GameManagerState.Opening:
                playButton.SetActive(true);

                break;
            case GameManagerState.GamePlay:
                //Hide play button
                playButton.SetActive(false);

                //Show player and call init
                playerObject.GetComponent<Player>().Init();

                //Start spawner
                spawnerObject.GetComponent<EnemySpawner>().StartSpawner();
                break;
            case GameManagerState.GameOver:
                //Stop spawning enemies
                spawnerObject.GetComponent<EnemySpawner>().StopSpawner();

                //Stop shooting
                playerObject.GetComponent<PlayerShoot>().StopShooting();

                //Change to opening state after 8 seconds
                Invoke("ChangeToOpeningState", 8);
            
                break;
        }
    }

    public void SetGameManagerState(GameManagerState state)
    {
        gmState = state;
        UpdateGameManagerState();
    }

    //Play button function
    public void StartGamePlay()
    {
        gmState = GameManagerState.GamePlay;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        gmState = GameManagerState.Opening;
        UpdateGameManagerState();
    }
}
