using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject playButton;
    public GameObject playerObject;
    public GameObject spawnerObject;
    public GameObject upgradePanel;
    public TextMeshProUGUI roundUIText;
    private int roundNumber;

    public enum GameManagerState
    {
        Opening,
        GamePlay,
        StartRound,
        EndRound,
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
                roundNumber = 1;
                roundUIText.text = "Round: " + roundNumber.ToString();

                //Show player and call init
                playerObject.GetComponent<Player>().Init();

                //Start spawner
                spawnerObject.GetComponent<EnemySpawner>().StartSpawner();
                break;

            case GameManagerState.StartRound:
                //Disable the upgradepanel,Start the spawner/shooting and increment the round number
                upgradePanel.SetActive(false);

                roundNumber++;
                roundUIText.text = "Round: " + roundNumber.ToString();

                playerObject.GetComponent<PlayerShoot>().StartShooting();
                playerObject.GetComponent<PlayerMovement>().enabled = true;
                playerObject.GetComponent<BoxCollider2D>().enabled = true;
                spawnerObject.GetComponent<EnemySpawner>().StartSpawner();

                break;

            case GameManagerState.EndRound:
                //When all of the enemies are killed in a round show the upgrade screen
                //spawnerObject.GetComponent<EnemySpawner>().StopSpawner();
                if(playerObject.GetComponent<Player>().GetHealth() != 0){
                    playerObject.GetComponent<Player>().IncreaseUpgradePoints();
                    playerObject.GetComponent<PlayerShoot>().StopShooting();
                    playerObject.GetComponent<PlayerMovement>().enabled = false;
                    playerObject.GetComponent<BoxCollider2D>().enabled = false;

                    upgradePanel.SetActive(true);
                }

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

    public void EndRound()
    {
        gmState = GameManagerState.EndRound;
        UpdateGameManagerState();
    }

    public void StartRound()
    {
        gmState = GameManagerState.StartRound;
        UpdateGameManagerState();
    }

    public void ChangeToOpeningState()
    {
        gmState = GameManagerState.Opening;
        UpdateGameManagerState();
    }

    public int GetRoundNumber()
    {
        return roundNumber;
    }

    public void SetRoundNumber(int value)
    {
        roundNumber = value;
    }
}
