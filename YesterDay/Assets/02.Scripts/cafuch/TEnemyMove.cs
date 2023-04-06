using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEnemyMove : MonoBehaviour
{
    Enemy enemy;
    TEnemyState tenemyState;

    private Rigidbody rb;
    [SerializeField] private float lowSpeed;
    [SerializeField] private float highSpeed;

    [SerializeField] private GameObject player;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        tenemyState = GameObject.Find("GameManager").GetComponent<TEnemyState>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {

        switch (tenemyState.curState) {

            case State.STOP: {

                Debug.Log("stop");
                //멈추는 코드
                Delay(3);
            }
            break;
            case State.IDLE : {

                Debug.Log("idle");
                RandomMove();
                Delay(1);
            }
            break;
            case State.WORK : {

                Debug.Log("work");
                Move(lowSpeed);
            }
            break;
            case State.RUN : {

                Debug.Log("run");
                Move(highSpeed);
            }
            break;
            case State.ATTACK : {


            }
            break;
        }
    }

    private void RandomMove() {

        int a = Random.Range(-1 , 2);
        int b = Random.Range(-1 , 2);
        Vector3 dir = new(a, 0, b);
        dir.Normalize();
        rb.velocity = dir * lowSpeed;
    }

    private void Move(float speed) {

        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        rb.velocity = dir * speed;
    }

    IEnumerator Delay(float delay) {

        yield return new WaitForSeconds(delay);
        tenemyState.curState = tenemyState.curState == State.STOP ? tenemyState.curState = State.IDLE : tenemyState.curState = State.STOP;
    }
}
