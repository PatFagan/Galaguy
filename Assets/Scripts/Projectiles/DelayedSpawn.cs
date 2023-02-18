using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedSpawn : MonoBehaviour
{
    public GameObject projectile;
    float delayTimer = 0f;
    public float delayDuration;

    private AudioSource shootSound;

    private void Start()
    {
        shootSound = GetComponent<AudioSource>();
        delayTimer = delayDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if (delayTimer < 0f)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);

            shootSound.Play();

            Destroy(gameObject);
        }

        delayTimer -= Time.deltaTime;
    }
}