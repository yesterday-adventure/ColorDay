using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIAction : MonoBehaviour
{
    protected AIBrain _aiBrain;

    protected virtual void Awake() {
        
        _aiBrain = GetComponentInParent<AIBrain>();
    }

    public abstract void TakeAction(); //AIAction을 상속 받아 구현할 Action들의 메서드
}
