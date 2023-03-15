using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Normal,
        LowHP,
        Sleep,
    }

    [SerializeField] private State _state;
    [SerializeField] private Enemy _enemy;

    //Keep track of which state we are in
    //Start
    // -------> NextState()
    //---------------> PatrolState()
    //---------------> CombatState()

    private void Start()
    {
        //_state = State.Patrol;
        NextState();
    }

    private void NextState()
    {
        switch(_state)
        {
            case State.Normal:
                StartCoroutine(NormalState());
                break;
            case State.LowHP:
                 StartCoroutine(LowHPState());
                break;
            case State.Sleep:
                 StartCoroutine(SleepState());
                break;
        }
    }

    private IEnumerator NormalState()
    {
        Debug.Log("Enter Normal State");
        while(_state == State.Normal)
        {
            if(_enemy.CurrentHealth() < 30)
            {
                _state = State.LowHP;
            }

            yield return null;//wait a single frame
        }
        Debug.Log("Exit Normal State");
        NextState();
    }
    
    private IEnumerator LowHPState()
    { 
        Debug.Log("Enter LowHP State");
        while(_state == State.LowHP)
        {
            _enemy.Heal();
            if(_enemy.CurrentHealth() > 80)
            {
                _state = State.Normal;
            }
            yield return null;
        }
        Debug.Log("Exit LowHP State");
        NextState();
    }

    private IEnumerator SleepState()
    {
        Debug.Log("Enter Sleep State");
        while(_state == State.Sleep)
        {


            yield return null;
        }
        Debug.Log("Exit Sleep State");
        NextState();
    }
}
