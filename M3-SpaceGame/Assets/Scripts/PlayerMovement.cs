using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float speed;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Get the input from the user
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        //Get a direction vector and normalize it so you get a unit circle
        Vector2 direction = new Vector2(moveHorizontal,moveVertical).normalized;

        Move(direction);
    }

    private void Move(Vector2 direction)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//Bottom left of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Top right of screen

        //Account for the height and width of the ship
        max.x -= .5f;
        min.x += .5f;

        max.y -= .5f;
        min.y += .5f;

        //Get the current position
        Vector2 pos = transform.position;

        //Add the movement to the position
        pos += direction * speed * Time.deltaTime;

        //Make sure the ship does not leave the bounds of the screen
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);

        //Set the position of the ship to the new position
        transform.position = pos;

    }

}
