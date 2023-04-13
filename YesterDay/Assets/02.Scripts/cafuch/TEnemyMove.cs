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
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    [SerializeField] private GameObject player;

    void Awake()
    {
        enemy = GetComponent<Enemy>();
        tenemyState = GameObject.Find("GameManager").GetComponent<TEnemyState>();
        rb = GetComponent<Rigidbody>();
    }

    private void Update() {

        if (tenemyState.curState != State.DIE) //살아있다면
        {
            switch (tenemyState.curState)
            {
                case State.STOP:
                {
                    transform.position = transform.position;
                    Delay(3);
                }
                break;
                case State.IDLE:
                {

                    Debug.Log("idle");
                    RandomMove();
                    Delay(1);
                }
                break;
                case State.WALK:
                {
                    Debug.Log(tenemyState.curState);
                    //걷기 이상이라면 실행하지 않는다
                    Move(walkSpeed);
                }
                break;
                case State.RUN:
                {
                    Debug.Log(tenemyState.curState);
                    Move(runSpeed);
                }
                break;
                case State.ATTACK:
                {
                    Debug.Log("에잇 잇팔");
                    Move(runSpeed);
                }
                break;
            }
        }
    }

    private void RandomMove() //수정필요
    {
        int a = Random.Range(-1 , 2);
        int b = Random.Range(-1 , 2);
        Vector3 dir = new(a, 0, b);
        dir.Normalize();;
        rb.velocity = dir * walkSpeed;
    }

    private void Move(float speed) 
    {
        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();
        rb.velocity = dir * speed;
    }

    IEnumerator Delay(float delay) 
    {
        Debug.Log(tenemyState.curState + "중");
        yield return new WaitForSeconds(delay);
        tenemyState.curState = tenemyState.curState == State.STOP ? tenemyState.curState = State.IDLE : tenemyState.curState = State.STOP;
        //현재의 상태를 정지와 배회의 반대 상태로 바꿔주는 삼항연산자
    }
}
