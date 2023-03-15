using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour
{
	public float currentTime = 0;
	public float timerSpeed = 0.5f;

	public bool nextTurn = false;

	[SerializeField] private Bar _timerBar;

	void Update()
	{
		currentTime += timerSpeed * Time.deltaTime;

		if(currentTime >= 1)
		{
			nextTurn = true;
			currentTime = 0;
		}
		_timerBar.SetBar(currentTime,1);
	}
}
