using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed;

    int damage; //equal to players damage

    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    public void SetDamage(int value)
    {
        damage = value;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 pos = transform.position;

        pos = new Vector2(pos.x, pos.y + speed * Time.deltaTime);

        transform.position = pos;

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        if(transform.position.y > max.y)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        
        if(collision.gameObject.tag.Equals("Enemy"))
        {

            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyControl>().DecreaseHealth(damage);
            //Destroy(collision.gameObject);//destroy enemy
            
        }
    }
}
