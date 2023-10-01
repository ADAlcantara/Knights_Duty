using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    void Update()
    {
        GameObject target = GameObject.FindWithTag("Player");
        if (Vector3.Distance(target.transform.position, transform.position) < 20)
        {
            GetComponent<NavMeshAgent>().
                SetDestination(target.transform.position);
        }
    }
}
