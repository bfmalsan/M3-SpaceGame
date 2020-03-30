using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public GameObject GameManagerGO;

    public int maxHealth = 3;
    public int health = 3;

    public TextMeshProUGUI healthUIText;

    public void Init()
    {
        health = maxHealth;

        healthUIText.text = "Health: " + health.ToString();

        gameObject.SetActive(true);

        GetComponent<PlayerShoot>().StartShooting();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("EnemyBullet"))
        {
            health--;

            healthUIText.text = "Health: " + health.ToString();

            if (health <= 0)
            {
                //set GameManager state to GameOver
                GameManagerGO.GetComponent<GameManager>().SetGameManagerState(GameManager.GameManagerState.GameOver);

                gameObject.SetActive(false);
            }

            //Destroy the object they we hit
            Destroy(collision.gameObject);

        }       
    }
}
