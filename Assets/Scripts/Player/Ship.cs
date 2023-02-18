using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship : MonoBehaviour
{
    public bool onShip = false;
    bool nearShip = false;

    public GameObject ui;

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
        // getting on snowmobile
        if (nearShip)
        {
            ui.SetActive(true);
            if (Input.GetButtonDown("Interact") && onShip == false) // get on
            {
                player.transform.parent = gameObject.transform; // set snowmobile to parent of player
                playerMovementScript.immobile = true;
                onShip = true;
            }
            else if (Input.GetButtonDown("Interact") && onShip == true) // get off
            {
                player.transform.parent = null; // set snowmobile to parent of player
                playerMovementScript.immobile = false;
                onShip = false;
            }
        }
        else
        {
            
            ui.SetActive(false);
        }

        if (onShip)
        {
            ui.SetActive(false);
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
            nearShip = true;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            nearShip = false;
        }
    }
}
