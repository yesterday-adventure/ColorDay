using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIDecision : MonoBehaviour
{
    public bool isReverse = false;
    
    public abstract bool MakeDecition();
}
