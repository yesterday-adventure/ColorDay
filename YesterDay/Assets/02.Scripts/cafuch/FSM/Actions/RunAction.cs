using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunAction : AIAction
{
    public override void TakeAction()
    {
        // _aiBrain.SetDestinationF(transform.position + _aiBrain._playerTrm.position, 7f);
        _aiBrain.SetDestinationF(_aiBrain._playerTrm.position, 7f);
    }
}
