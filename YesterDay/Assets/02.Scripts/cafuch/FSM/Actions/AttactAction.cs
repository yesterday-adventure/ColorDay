using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttactAction : AIAction
{
    public override void TakeAction()
    {
        _aiBrain.SetDestinationF(Vector3.zero, 0f);
        Debug.Log("죽어라 시발");
    }
}
