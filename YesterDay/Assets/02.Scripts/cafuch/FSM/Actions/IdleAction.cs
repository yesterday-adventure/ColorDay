using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleAction : AIAction
{
    public override void TakeAction()
    {
        _aiBrain.SetDestinationF(_aiBrain._playerTrm.position, 0f);
    }
}
