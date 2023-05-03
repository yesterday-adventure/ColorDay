using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceDecision : AIDecision
{
    [SerializeField] private Transform playerTrm;
    [SerializeField] private float distance;
    public override bool MakeDecition() { //거리 안에 있는지 체크

        return Vector3.Distance(playerTrm.position, transform.position) < distance;
    }

    #if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        if(UnityEditor.Selection.activeObject == gameObject)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, distance);
            Gizmos.color = Color.white;
        }
    }
#endif
}
