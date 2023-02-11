using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUpwards : MonoBehaviour
{
    public float lifetime;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, speed));
    }
}
