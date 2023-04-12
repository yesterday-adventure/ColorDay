using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TEnemyState tenemyState;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackDir, walkDir, runDir;

    void Awake() {

        tenemyState = GameObject.Find("GameManager").GetComponent<TEnemyState>();
    }

    private void Update() {
        
        //test
        // if (Input.GetKeyDown(KeyCode.B)) tenemyState.curState++;
        // if (tenemyState.curState == State.ATTACK) tenemyState.curState = State.STOP;

        PlayerRay(); //레이를 쏴 체크한다
    }

    private void OnCollisionEnter(Collision other) {
    
        if (other.collider.CompareTag("Bullet")) { //타격됨

            tenemyState.curState = State.RUN; // 달린다.
        }
    }

    private void PlayerRay(float dist, State state) {

        for (int i = 0; i < 360; i += 10)
        {
            Vector3 dir = Quaternion.Euler(0, i, 0) * transform.forward;

            Ray ray = new Ray(transform.position, dir.normalized);

            if (Physics.Raycast(ray, dist, enemyLayer))
            {
                tenemyState.curState = state;
            }
        }
    }
}