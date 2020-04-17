using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 mousePosition;
    public float moveSpeed = 0.1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
        Move(mousePosition);
  
    }
    
    private void Move(Vector3 mousePosition)
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));//Bottom left of screen
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));//Top right of screen

        //Account for the height and width of the ship
        max.x -= .5f;
        min.x += .5f;

        max.y -= .5f;
        min.y += .5f;

        mousePosition.x = Mathf.Clamp(mousePosition.x, min.x, max.x);
        mousePosition.y = Mathf.Clamp(mousePosition.y, min.y, max.y);

        transform.position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }
    
}
