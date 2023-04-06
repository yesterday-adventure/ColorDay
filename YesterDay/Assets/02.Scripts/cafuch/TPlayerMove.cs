using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPlayerMove : MonoBehaviour
{

    private Rigidbody rigid;
    private float moveForce = 7.0f;
    private float x_Axis;
    private float z_Axis;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        x_Axis = Input.GetAxis("Horizontal");
        z_Axis = Input.GetAxis("Vertical");

        Vector3 velocity = new Vector3(x_Axis, 0, z_Axis);
        velocity *= moveForce;
        rigid.velocity = velocity;
    }
}