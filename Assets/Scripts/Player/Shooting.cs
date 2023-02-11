using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject projectile;
    float cooldownTimer = 0f;
    public float cooldownDuration;

    private AudioSource shootSound;

    private void Start()
    {
        shootSound = GameObject.Find("ShootSound").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // spawn projectiles on button press
        if (Input.GetButtonDown("Shoot") && cooldownTimer < 0f)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            cooldownTimer = cooldownDuration;

            shootSound.Play();
        }

        cooldownTimer -= Time.deltaTime;
    }
}