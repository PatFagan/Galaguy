using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // set target loc by finding target object by tag
    public void SetTarget(string targetTag)
    {
        GameObject target = GameObject.FindGameObjectWithTag(targetTag);
        //navMeshAgent.SetDestination(target.transform.position);
        //print(transform.position);
        //print("player: " + target.transform.position);
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        SetTarget("Player");
    }
}
