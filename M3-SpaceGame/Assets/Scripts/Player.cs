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

    public TextMeshProUGUI healthUIText;

    public void Init()
    {
        health = startHealth;

        healthUIText.text = "Health: " + health.ToString();

        gameObject.SetActive(true);

        GetComponent<PlayerShoot>().ResetValues();
        GetComponent<PlayerShoot>().StartShooting();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
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
}
