using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour
{
	public float currentTime = 0;
	public float timerSpeed = 0.5f;

	private bool _nextTurn = false;

	[SerializeField] private Bar _timerBar;

	// bool myVar = IsNextTurn();
	public bool IsNextTurn()
	{
		if (Time.timeScale == 0)
		{
			return false;
		}
		
		return _nextTurn;
	}

	public void ResetTimer()
	{
		_nextTurn = false;
		currentTime = 0;
	}

	void Update()
	{
		if(_nextTurn) return;

		currentTime += timerSpeed * Time.deltaTime;

		if(currentTime >= 1)
		{
			_nextTurn = true;
		}
		_timerBar.SetBar(currentTime,1);
	}
}
