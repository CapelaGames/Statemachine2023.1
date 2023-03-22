using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerAbility : MonoBehaviour
{
	[SerializeField] TurnTimer _turnTimer;

	public abstract void UseAbility();

	protected void EndTurn()
	{
		if(_turnTimer != null)
		{
			_turnTimer.ResetTimer();
		}
	}
}
