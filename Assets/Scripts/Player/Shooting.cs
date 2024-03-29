using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    float cooldownTimer = 0f;
    public float cooldownDuration;

    private AudioSource shootSound;

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
        if (Input.GetButtonDown("Shoot") && cooldownTimer < 0f && !shipScript.onShip)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            cooldownTimer = cooldownDuration;

            shootSound.Play();
        }

        cooldownTimer -= Time.deltaTime;
    }
}