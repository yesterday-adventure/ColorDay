using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAction : AIAction
{
    public override void TakeAction()
    {  
        // _aiBrain.SetDestination(_aiBrain._playerTrm.position);
        _aiBrain.SetDestinationF(_aiBrain._playerTrm.position, 5f);
    }
}
