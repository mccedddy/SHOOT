using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Vector3 shootposition;
    private bool shooting;
    private bool audioPlayed = false;

    // Update is called once per frame
    void Update()
    {
        // Laser
        if (GameControl.playing == true)
        {
            if (GameControl.laser.transform.position.y == -6)
            {
                shooting = false;
            }
            else
            {
                shooting = true;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                shootposition = GameControl.player.transform.position;
                if (shooting == false)
                {
                    GameControl.sfx_laser.Play();
                    GameControl.laser.transform.position = shootposition;
                    GameControl.laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
                }
            }
            if (GameControl.laser.transform.position.y >= 6)
            {
                GameControl.laser.transform.position = new Vector3(0, -6, 0);
                GameControl.laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            }
        }
        else
        {
            GameControl.laser.transform.position = new Vector3(0, -6, 0);
            GameControl.laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Meteor1")
        {
            if (audioPlayed == false)
            {
                GameControl.sfx_lose.Play();
                ScoreControl.score += 10;
                audioPlayed = true;
            }
            GameControl.laser.transform.position = new Vector3(0, -6, 0);
            GameControl.laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GameControl.meteor1.transform.position = new Vector3(GameControl.randomx, 6, 0);
        }
        else if (collision.gameObject.name == "Meteor2")
        {
            if (audioPlayed == false)
            {
                GameControl.sfx_lose.Play();
                ScoreControl.score += 10;
                audioPlayed = true;
            }
            GameControl.laser.transform.position = new Vector3(0, -6, 0);
            GameControl.laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GameControl.meteor2.transform.position = new Vector3(GameControl.randomx, 9, 0);
        }
        else if (collision.gameObject.name == "Meteor3")
        {
            if (audioPlayed == false)
            {
                GameControl.sfx_lose.Play();
                ScoreControl.score += 10;
                audioPlayed = true;
            }
            GameControl.laser.transform.position = new Vector3(0, -6, 0);
            GameControl.laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GameControl.meteor3.transform.position = new Vector3(GameControl.randomx, 12, 0);
        }
        else if (collision.gameObject.name == "Meteor4")
        {
            if (audioPlayed == false)
            {
                GameControl.sfx_lose.Play();
                ScoreControl.score += 10;
                audioPlayed = true;
            }
            GameControl.laser.transform.position = new Vector3(0, -6, 0);
            GameControl.laser.GetComponent<Rigidbody2D>().velocity = new Vector3(0, 0, 0);
            GameControl.meteor4.transform.position = new Vector3(GameControl.randomx, 16, 0);
        }
        audioPlayed = false;
    }
}
