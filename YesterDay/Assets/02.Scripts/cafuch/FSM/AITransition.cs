using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AITransition : MonoBehaviour
{
    protected AIBrain _aiBrain;
    public AIState nextState; //건드리는 아이가 없다?
    [SerializeField] private List<AIDecision> decisionLs = new List<AIDecision>();

    private void Awake() {
        
        _aiBrain = GetComponentInParent<AIBrain>();
    }

    public bool CheckTransition() { //전환 체크

        bool result = false;

        foreach (AIDecision d in decisionLs) {

            result = d.MakeDecition(); //거리 안에 있는지 체크

            // if (d.isReverse) //isReverse를 건드리는 아이가 없다!!
            //     result = !result;

            // if (result == false) 
            //     break;
        }

        return result;
    }
}

