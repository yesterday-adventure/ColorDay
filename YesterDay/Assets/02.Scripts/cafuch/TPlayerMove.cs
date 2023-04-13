using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerMove : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] private float speed = 7.0f;
    private float x, z;

    void Awake() {

        rb = GetComponent<Rigidbody>();
    }

    void Update() {

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(x, 0, z);
        rb.velocity = dir.normalized * speed;
    }
}