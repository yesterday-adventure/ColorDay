using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwing : MonoBehaviour
{
    [SerializeField] private Transform attackPos;
    [Range(0f, 50f)][SerializeField] private float radius;

    public void Attack()
    {
        Collider[] cols = Physics.OverlapSphere(attackPos.position, radius, 1 << 8);
        foreach (Collider col in cols)
        {
            ColorEnemy ce = null;
            col.TryGetComponent<ColorEnemy>(out ce);
            //ce?.
        }
    }
}
