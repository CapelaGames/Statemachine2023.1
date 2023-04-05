using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statemachine : MonoBehaviour
{
	public enum State
	{
		Normal,
		LowHp,
		Sleep
	}

	[SerializeField] private State _state;
	[SerializeField] private Health _enemy;
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
			case State.LowHp:
				StartCoroutine(LowHpState());
				break;
			case State.Sleep:
				StartCoroutine(SleepState());
				break;
		}
	}

	private IEnumerator NormalState()
	{
		Debug.Log("Entering Normal State");

		while(_state == State.Normal)
		{
			if(_enemy.CurrentHealth() < 30)
			{
				_state = State.LowHp;
				yield return null; // wait 1 frame , only works in coroutines
				continue;
			}
			
			if(!_turnTimer.IsNextTurn())
			{
				yield return null; // wait 1 frame , only works in coroutines
				continue;
			}

			int damage = Random.Range(30, 40);
			_playerHealth.DealDamage(damage);
			//_playerHealth.DealDamage(Random.Range(5,20)); // this line, is the same as the above 2 lines
			
			_turnTimer.ResetTimer();
			yield return null; //continues 1 frame later
		}

		Debug.Log("Exiting Normal State");
		NextState();
	}
	
	
	private IEnumerator LowHpState()
	{
		Debug.Log("Entering LowHp State");
		while(_state == State.LowHp)
		{
			if(!_turnTimer.IsNextTurn())
			{
				yield return null;
				continue;
			}

			_enemy.Heal();
			_turnTimer.ResetTimer();
			if(_enemy.CurrentHealth() > 80)
			{
				_state = State.Normal;
			}
			yield return null; //continues 1 frame later
		}
		Debug.Log("Exiting LowHp State");
		NextState();
	}

	private IEnumerator SleepState()
	{
		Debug.Log("Entering Sleep State");
		while(_state == State.Sleep)
		{
			//do code here
			yield return null; //continues 1 frame later
		}
		Debug.Log("Exiting Sleep State");
		NextState();
	}
}
