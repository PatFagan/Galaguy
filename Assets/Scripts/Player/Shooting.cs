using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    float cooldownTimer = 0f;
    public float cooldownDuration;

    // Update is called once per frame
    void Update()
    {
        // spawn projectiles on button press
        if (Input.GetButtonDown("Shoot") && cooldownTimer < 0f)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            cooldownTimer = cooldownDuration;
        }

        cooldownTimer -= Time.deltaTime;
    }
}