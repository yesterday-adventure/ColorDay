using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {

    STOP = 0,
    IDLE,
    ATTACK,
    WALK,
    RUN,
    DIE
}

public class TEnemyState : MonoBehaviour
{
    public State curState = State.IDLE;
}   
