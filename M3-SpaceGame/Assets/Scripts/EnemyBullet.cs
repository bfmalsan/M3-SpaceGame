using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    private Vector3 myTarget;
    private Vector3 myDirection;

    // Start is called before the first frame update
    void Start()
    {
        speed = 6f;
        myTarget = GameObject.FindGameObjectWithTag("Player").transform.position;

        myDirection = myTarget - transform.position;
        myDirection.Normalize();

        if(myDirection.y >= 0){
            myDirection = new Vector3(0,-1,0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float deltaSpeed = speed * Time.deltaTime;

        transform.Translate(myDirection.x * deltaSpeed, myDirection.y * deltaSpeed, 0, Space.World);

        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        if (transform.position.y < min.y)
        {
            Destroy(gameObject);
        }
    }

}
