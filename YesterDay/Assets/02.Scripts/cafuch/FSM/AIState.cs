using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIState : MonoBehaviour //현재 State의 Action들을 수행하기 위한 스크립트
{
    protected AIBrain _aiBrain;
    [SerializeField] private List<AIAction> actionLs = new List<AIAction>();
    [SerializeField] private List<AITransition> transitionLs = new List<AITransition>();

    private void Awake() {
        
        _aiBrain = GetComponentInParent<AIBrain>();
        
        GetComponents<AIAction>(actionLs);
        GetComponents<AITransition>(transitionLs);
    }
    public void updateState() {

        Debug.Log("AIState - updateState 실행중");
        foreach (AIAction a in actionLs) {

            a.TakeAction(); //a의 Action을 실행한다
        }

        foreach (AITransition t in transitionLs) {

            if (t.CheckTransition()) //State 전환이 가능한지 체크
                _aiBrain.ChangeState(t.nextState);//t의 State로 전환
        }
    }
}
