using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipShooting : MonoBehaviour
{
    public GameObject projectile;
    public float cooldownDuration;
    public AudioSource shootSound;

    float cooldownTimer = 0f;

    Ship shipScript;
    private void Start()
    {
        shipScript = GameObject.Find("PlayerShip").GetComponent<Ship>();
        shootSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // spawn projectiles on button press
        if (Input.GetButtonDown("Shoot") && cooldownTimer < 0f && shipScript.onShip)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            cooldownTimer = cooldownDuration;

            shootSound.Play();
        }

        cooldownTimer -= Time.deltaTime;
    }
}