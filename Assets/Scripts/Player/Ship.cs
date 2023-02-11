using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    bool ridingSnowmobile = false;
    bool atSnowmobile = false;

    // movement variables
    float horizontal, vertical, BASE_MOVE_SPEED;
    public float moveSpeed;
    public Vector3 movement;

    PlayerMovement playerMovementScript;
    GameObject player;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerMovementScript = player.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        print(atSnowmobile);
        // getting on snowmobile
        if (atSnowmobile)
        {
            if (Input.GetButtonDown("Interact") && ridingSnowmobile == false) // get on
            {
                player.transform.parent = gameObject.transform; // set snowmobile to parent of player
                playerMovementScript.immobile = true;
                ridingSnowmobile = true;
            }
            else if (Input.GetButtonDown("Interact") && ridingSnowmobile == true) // get off
            {
                player.transform.parent = null; // set snowmobile to parent of player
                playerMovementScript.immobile = false;
                ridingSnowmobile = false;
            }
        }

        if (ridingSnowmobile)
        {
            player.transform.position = gameObject.transform.position;

            // movement
            horizontal = Input.GetAxis("Horizontal");
            vertical = Input.GetAxis("Vertical");
            movement = new Vector2(horizontal, vertical);
            GetComponent<Rigidbody2D>().velocity = movement * moveSpeed;
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            atSnowmobile = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            atSnowmobile = false;
        }
    }
}
