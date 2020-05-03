using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject GameManagerGO;

    public int startHealth = 3;
    public int health;
    public int upgradePoints = 0;
    public TextMeshProUGUI pointsUIText;

    public TextMeshProUGUI healthUIText;

    public void Init()
    {
        health = startHealth;

        healthUIText.text = "Health: " + health.ToString();

        upgradePoints = 0;

        gameObject.SetActive(true);

        GetComponent<PlayerShoot>().ResetValues();
        GetComponent<PlayerShoot>().StartShooting();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("EnemyBullet"))
        {
            DecreaseHealth(1);

            healthUIText.text = "Health: " + health.ToString();

            if (health <= 0)
            {
                //set GameManager state to GameOver
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }

            //Destroy the object that we hit
            Destroy(collision.gameObject);

        }       
        if(collision.gameObject.CompareTag("Enemy")){
            DecreaseHealth(1);

             if (health <= 0)
            {
                //set GameManager state to GameOver
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }

            collision.gameObject.GetComponent<EnemyControl>().SetHealth(0);
        }

        if(collision.gameObject.CompareTag("Upgrade")){
            IncreaseUpgradePoints();
            
            Destroy(collision.gameObject);
        }
    }

    public void IncreaseHealth(int value)
    {
        health += value;
        healthUIText.text = "Health: " + health.ToString();
    }

    public void DecreaseHealth(int value)
    {
        health -= value;
        healthUIText.text = "Health: " + health.ToString();
    }

    public int GetHealth(){
        return health;
    }

    public int GetUpgradePoints(){
        return upgradePoints;
    }

    public void IncreaseUpgradePoints(){
        upgradePoints++;
        pointsUIText.text = upgradePoints.ToString();
    }
    public void DecreaseUpgradePoints(){
        if(upgradePoints > 0){
            upgradePoints--;
            pointsUIText.text = upgradePoints.ToString();
        }
    }

}
