using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerMove : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 7.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Vector3 dir = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        rb.velocity = dir.normalized * speed;
    }
}