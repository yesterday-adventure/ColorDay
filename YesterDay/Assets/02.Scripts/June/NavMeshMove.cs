using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshMove : MonoBehaviour
{
    NavMeshAgent nav;
    public Transform targetPos;
    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        nav.SetDestination(targetPos.position);
    }
}