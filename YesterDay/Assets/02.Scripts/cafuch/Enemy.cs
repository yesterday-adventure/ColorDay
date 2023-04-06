using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TEnemyState tenemyState;
    private State test = State.STOP;

    void Awake() {

        tenemyState = GameObject.Find("GameManager").GetComponent<TEnemyState>();
    }

    private void Update() {
        
        if (Input.GetKeyDown(KeyCode.B)) test++;

        tenemyState.curState = test;

        if (test == State.ATTACK) test = State.STOP;
    }

    private void OnCollisionEnter(Collision other) {
    
    if (other.collider.CompareTag("Bullet")) { //타격됨

        tenemyState.curState = State.RUN; // 달린다.
    }
}
}
