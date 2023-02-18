using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipGunUnlock : MonoBehaviour
{
    public GameObject newProjectile;
    public float newCooldown;
    public AudioSource newShootSound;

    ShipShooting shipShootingScript;
    // Start is called before the first frame update
    void Start()
    {
        shipShootingScript = GameObject.Find("PlayerShip").GetComponent<ShipShooting>();
    }

    // Update is called once per frame
    void Update()
    {
        if (shipShootingScript.projectile != newProjectile)
            transform.Rotate(0, .1f, 0, Space.Self);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            shipShootingScript.projectile = newProjectile;
            shipShootingScript.cooldownDuration = newCooldown;
            shipShootingScript.shootSound = newShootSound;
            Destroy(gameObject);
        }
    }
}
