using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBG : MonoBehaviour
{
    GameObject player;
    private float playerx;
    private float playery;
    private float offsetx;
    private float offsety;
    MeshRenderer meshrenderer;
    Material material;
    Vector2 offset;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        meshrenderer = GetComponent<MeshRenderer>();
        material = meshrenderer.material;
        offset = material.mainTextureOffset;
    }

    // Update is called once per frame
    void Update()
    {
        // Move Backgound
        offset.y += 0.005f;
        material.mainTextureOffset = offset;
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
