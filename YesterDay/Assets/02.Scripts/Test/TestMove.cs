using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    float speed = 0.05f;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            WhiteMap.instance.TestWhite();
        }

        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");
        Vector3 dir = new Vector3(x, 0, z);
        transform.position += dir.normalized * speed ;
    }
}
