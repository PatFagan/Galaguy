using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // movement variables
    public float moveSpeed = 50f, rotLerp = 100f;
    public Rigidbody2D physicsComponent;

    // jump variables
    float dashCooldown = 0f;
    public float dashForce = 800f, dashTimeout = 40f;

    // runs on start
    void Start()
    {
        physicsComponent = gameObject.GetComponent<Rigidbody2D>();
    }

    // runs once per frame
    void Update()
    {
        Movement();

        Dash();
    }

    void Dash()
    {
        dashCooldown--;

        if (Input.GetButtonDown("Dash") && dashCooldown <= 0)
        {
            physicsComponent.AddForce(new Vector3(Input.GetAxis("Horizontal") * dashForce,
                0f, Input.GetAxis("Vertical") * dashForce), ForceMode2D.Force);
            dashCooldown = dashTimeout;
            //physicsComponent.velocity = new Vector3(0f, 0f, 0f);
        }
    }

    // contains movement code
    void Movement()
    {
        // x axis
        if (Input.GetAxis("Horizontal") > 0)
        {
            physicsComponent.AddForce(Vector3.right * moveSpeed * Time.deltaTime, ForceMode2D.Force);
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            physicsComponent.AddForce(Vector3.left * moveSpeed * Time.deltaTime, ForceMode2D.Force);
        }

        // z axis
        if (Input.GetAxis("Vertical") > 0)
        {
            physicsComponent.AddForce(Vector3.up * moveSpeed * Time.deltaTime, ForceMode2D.Force);
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            physicsComponent.AddForce(Vector3.down * moveSpeed * Time.deltaTime, ForceMode2D.Force);
        }

        // rotate player in movement direction
        //if (new Vector3(physicsComponent.velocity.x, 0f, physicsComponent.velocity.y) != Vector3.zero)
        //{
        //    transform.rotation = Quaternion.Slerp(gameObject.transform.rotation,
        //        Quaternion.LookRotation(new Vector3(physicsComponent.velocity.x, 0f, physicsComponent.velocity.y)), Time.deltaTime * rotLerp);
        //}
    }
}