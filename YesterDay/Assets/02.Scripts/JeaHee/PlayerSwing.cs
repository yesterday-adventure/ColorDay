using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField] private Transform attackPos;
    [Range(0f, 10f)][SerializeField] private float radius;

    Animator anim;

    private readonly int attackHash = Animator.StringToHash("Attack");

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C)) 
        {
            anim.SetTrigger(attackHash);
        }
    }

    public void Attack()
    {
        Debug.Log("Attack Event 실행");
        Collider[] cols = Physics.OverlapSphere(attackPos.position, radius, 1 << 8);
        foreach (Collider col in cols)
        {
            ColorEnemy ce = null;
            col.TryGetComponent<ColorEnemy>(out ce);
            if (ce != null)
            {
                ce.currentColor = ColorEnum.white;
                Debug.Log($"{col.transform.name} -> White");
            }
            else
            {
                Debug.Log("ColorEnemy가 존재하지 않는 적");
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (attackPos != null)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(attackPos.position, radius);
            Gizmos.color = Color.white;
        }
    }
}
