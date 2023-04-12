using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum State {

    STOP,
    IDLE,
    WALK,
    RUN,
    ATTACK,
    DIE
}

public class TEnemyState : MonoBehaviour
{
    public State curState = State.STOP;
}   
