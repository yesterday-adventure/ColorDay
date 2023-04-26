using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.CompilerServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    TEnemyState tenemyState;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private float attackDir, runDir, walkDir;

    void Awake() {

        tenemyState = GameObject.Find("GameManager").GetComponent<TEnemyState>();
    }

    private void Update() {

        PlayerRay(walkDir, State.WALK);
        PlayerRay(runDir, State.RUN); 
        PlayerRay(attackDir, State.ATTACK);
    }

    private void OnCollisionEnter(Collision other) {
    
        if (other.collider.CompareTag("Bullet")) { //타격됨

            tenemyState.curState = State.RUN; // 달린다.
        }
    }

    private void PlayerRay(float dist, State state) { //문제점, 나가면 안 따라옴 / 겹쳐서 개수만큼 실행됨

        Collider[] hit = Physics.OverlapSphere(this.transform.position, dist, enemyLayer);

        for (int i = 0; i < hit.Length; ++i) {

            if (hit[i].gameObject.layer == 7) {

                if (tenemyState.curState < state) {

                    Debug.Log(state);
                    tenemyState.curState = state;
                }
            }
        }
    }

    private void OnDrawGizmos() {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, walkDir);

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, runDir);

        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(this.transform.position, attackDir);
    }
}