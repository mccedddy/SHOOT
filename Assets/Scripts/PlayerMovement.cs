using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D body;
    public static float horizontal;
    public static float vertical;
    float moveLimiter = 0.7f;
    public static float runSpeed = 5.0f;
    private static float playerx;
    private static float playery;
    

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Gives a value between -1 and 1
        horizontal = Input.GetAxisRaw("Horizontal"); // -1 is left
        vertical = Input.GetAxisRaw("Vertical"); // -1 is down

        // Restrictions 2.2 x 4.5
        playerx = transform.position.x;
        playery = transform.position.y;

        if (playerx <= -2.2)
        {
            transform.position = new Vector3(-2.2f, playery, 0);
        }
        if (playerx >= 2.2)
        {
            transform.position = new Vector3(2.2f, playery, 0);
        }
        if (playery <= -4.5)
        {
            transform.position = new Vector3(playerx, -4.5f, 0);
        }
        if (playery <= -4.5 && playerx <= -2.2)
        {
            transform.position = new Vector3(-2.2f, -4.5f, 0);
        }
        if (playery <= -4.5 && playerx >= 2.2)
        {
            transform.position = new Vector3(2.2f, -4.5f, 0);
        }
        if (playery >= 4.5)
        {
            transform.position = new Vector3(playerx, 4.5f, 0);
        }
        if (playery >= 4.5 && playerx <= -2.2)
        {
            transform.position = new Vector3(-2.2f, 4.5f, 0);
        }
        if (playery >= 4.5 && playerx >= 2.2)
        {
            transform.position = new Vector3(2.2f, 4.5f, 0);
        }
    }

    void FixedUpdate()
    {
        if (horizontal != 0 && vertical != 0) // Check for diagonal movement
        {
            // limit movement speed diagonally, so you move at 70% speed
            horizontal *= moveLimiter;
            vertical *= moveLimiter;
        }

        if (GameControl.playing == true)
        {
            body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
        }

        // Fix not in position
        if (GameControl.playing == false)
        {
            GameControl.ResetGame();
        }
    }

    // Collision
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Meteor")
        {
            GameControl.sfx_lose.Play();
            GameControl.ResetGame();
        }
    }
}
