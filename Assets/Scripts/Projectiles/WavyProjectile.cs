using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyProjectile : MonoBehaviour
{
    public float lifetime;
    public float speed;
    public Vector2 direction;
    float time = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        time += .01f;
        transform.Translate(new Vector2(.03f * Mathf.Sin(time), speed));
    }
}
