using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI field_text_space;
    [SerializeField] TextMeshProUGUI field_text_score;
    [SerializeField] TextMeshProUGUI field_text_title;
    [SerializeField] AudioSource field_sfx_lose;
    [SerializeField] AudioSource field_sfx_laser;
    public static AudioSource sfx_lose;
    public static AudioSource sfx_laser;
    public static TextMeshProUGUI text_space;
    public static TextMeshProUGUI text_score;
    public static TextMeshProUGUI text_title;
    public static GameObject player;
    public static GameObject laser;
    public static GameObject meteor1;
    public static GameObject meteor2;
    public static GameObject meteor3;
    public static GameObject meteor4;
    public static bool playing = false;
    public static float gravity = 1;
    public static float randomx;

    // Start is called before the first frame update
    void Start()
    {
        text_space = field_text_space;
        text_score = field_text_score;
        text_title = field_text_title;
        sfx_lose = field_sfx_lose;
        sfx_laser = field_sfx_laser;
        player = GameObject.Find("Player");
        laser = GameObject.Find("Laser");
        meteor1 = GameObject.Find("Meteor1");
        meteor2 = GameObject.Find("Meteor2");
        meteor3 = GameObject.Find("Meteor3");
        meteor4 = GameObject.Find("Meteor4");
    }

    // Update is called once per frame
    void Update()
    {
        // Game Start
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playing = true;
            text_space.enabled = false;
            text_title.enabled = false;
        }

        // Constant Speed
        randomx = Random.Range(-2.5f, 2.5f);
        meteor1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -5*gravity, 0);
        meteor2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -5*gravity, 0);
        meteor3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -5*gravity, 0);
        meteor4.GetComponent<Rigidbody2D>().velocity = new Vector3(0, -5*gravity, 0);


        // Increase Gravity
        if (playing == true)
        {
            gravity += 0.0005f;
        }

        // Random Respawn
        if (meteor1.transform.position.y <= -5)
        {
            meteor1.transform.position = new Vector3(randomx, 6, 0);
        }
        if (meteor2.transform.position.y <= -5)
        {
            meteor2.transform.position = new Vector3(randomx, 9, 0);
        }
        if (meteor3.transform.position.y <= -5)
        {
            meteor3.transform.position = new Vector3(randomx, 12, 0);
        }
        if (meteor4.transform.position.y <= -5)
        {
            meteor4.transform.position = new Vector3(randomx, 16, 0);
        }
    }

    public static void ResetGame()
    {
        playing = false;
        gravity = 1;
        text_space.enabled = true;
        text_title.enabled = true;
        ScoreControl.score = 0;
        player.transform.position = new Vector3(0, -3, 0);
        meteor1.transform.position = new Vector3(0, 6, 0);
        meteor1.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        meteor2.transform.position = new Vector3(0, 9, 0);
        meteor2.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        meteor3.transform.position = new Vector3(0, 12, 0);
        meteor3.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
        meteor4.transform.position = new Vector3(0, 16, 0);
        meteor4.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
}
