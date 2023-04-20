using System.Runtime.InteropServices.ComTypes;
using System.Diagnostics.Contracts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TEnemyMove : MonoBehaviour
{
    Enemy enemy;
    TEnemyState tenemyState;

    private Rigidbody rb;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    [SerializeField] private GameObject player;

    private bool follow = false;
    private bool isChg = true;

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
                    rb.velocity = Vector3.zero;
                    if(isChg)
                        StartCoroutine(Delay(2));
                }
                break;
                case State.IDLE:
                {
                    if(isChg) {

                        RandomMove();
                        StartCoroutine(Delay(3));
                    }
                }
                break;
                case State.WALK:
                {
                    if (!follow) {

                        //다트윈 떡칠해서?
                        //아잇 찾았다~ 하는 거 보여주고?ㄴ 에너미 방향을 플레이어 방향으로 돌리고?
                        follow = true; //한 번만 돌아가도록
                    }
                    //걷기 이상이라면 실행하지 않는다
                    Debug.Log(tenemyState.curState);
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
                    Debug.Log(tenemyState.curState);
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
        dir.Normalize();
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
        isChg = false;
        yield return new WaitForSeconds(delay);
        isChg = true;
        tenemyState.curState = tenemyState.curState == State.STOP ? tenemyState.curState = State.IDLE : tenemyState.curState = State.STOP;
        //현재의 상태를 정지와 배회의 반대 상태로 바꿔주는 삼항연산자
    }
}
