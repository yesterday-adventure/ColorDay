using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {

    STOP,
    IDLE,
    WORK,
    RUN,
    ATTACK
}

public class TEnemyState : MonoBehaviour
{
    public State curState = State.STOP;
}   
