using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class StateMachine : MonoBehaviour
{
    public enum State
    {
        Normal,
        LowHP,
        Sleep,
    }

    [SerializeField] private State _state;
    [SerializeField] private Health _health; // this was _enemy, you can leave it as _enemy if you want (easier)
    [SerializeField] private Health _playerHealth;
    [SerializeField] private TurnTimer _turnTimer;
    
    private void Start()
    {
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
            if(_health.CurrentHealth() < 30)
            {
                _state = State.LowHP;
                yield return null;
                continue;
            }
            
            if(!_turnTimer.IsNextTurn())
            {
                yield return null;
                continue;
            }
            
            int randomDamage = Random.Range(1, 9);
            _playerHealth.DealDamage( randomDamage );
            //_playerHealth.DealDamage(Random.Range(1, 9)); //above 2 lines done as 1 line
            
            _turnTimer.ResetTimer();
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
            if(!_turnTimer.IsNextTurn())
            {
                yield return null;
                continue;
            }


            _health.Heal();
            _turnTimer.ResetTimer();
            if(_health.CurrentHealth() > 80)
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
