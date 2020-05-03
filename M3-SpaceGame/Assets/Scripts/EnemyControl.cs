using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    float speed;
    public int health = 1;

    GameObject spawner;
    public GameObject upgradePowerUpPrefab;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1f;
        spawner = GameObject.FindGameObjectWithTag("Spawner");
        if(spawner == null)
        {
            Debug.Log("Couldn't find spawner");
        }
    }

    // Update is called once per frame
    void Update()
    {
        //If the enemies health hits zero, kill it
        if(health <= 0)
        {
            //Todo: play death animation 
            DropUpgrade();
            Destroy(gameObject);
            spawner.GetComponent<EnemySpawner>().removeEnemyFromList(gameObject);
        }

        //Move the enemy downward
        Move();
    }

    private void Move()
    {
        Vector2 pos = transform.position;

        pos = new Vector2(pos.x, pos.y - speed * Time.deltaTime);

        transform.position = pos;

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
            spawner.GetComponent<EnemySpawner>().removeEnemyFromList(gameObject);
        }
    }

    public void IncreaseHealth(int value)
    {
        health += value;
    }

    public void DecreaseHealth(int value)
    {
        health -= value;
    }

    public void SetHealth(int value) => health = value;

    public void DropUpgrade(){
        int randNum = Random.Range(0, 101);

        if(randNum <= 5){
            //drop an upgrade
            GameObject powerUp = Instantiate(upgradePowerUpPrefab, 
                                            new Vector3(transform.position.x, transform.position.y, 0),
                                            Quaternion.identity);
        }
        else{
            //nothing
        }
    }
}
