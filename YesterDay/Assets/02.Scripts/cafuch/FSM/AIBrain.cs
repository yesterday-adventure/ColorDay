using System.Xml.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIBrain : MonoBehaviour //목적지를 찾아 이동, State 변환
{
    NavMeshAgent _navAgent;
    [SerializeField] private AIState _aiState; //현재의 AIState
    [SerializeField] private Transform _playerTrm; //플레이어의 pos 받아오기

    private void Awake() {
        
        _navAgent = GetComponent<NavMeshAgent>(); //NavAgent 받아오기
    }

    private void Update() {
        
        _aiState?.updateState(); //
    }

    public void SetDestination(Vector3 pos) { //목적지를 찾는 메서드 (== 이동하는 메서드)

        _navAgent.SetDestination(pos); //NavAgent를 통해 pos로 이동한다.
    }

    public void ChangeState(AIState nextState) { //현재의 AIState를 바꿔주는 메서드

        _aiState = nextState;
    }
}