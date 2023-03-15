using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTimer : MonoBehaviour
{
	public float currentTime = 0;
	public float timerSpeed = 2;

	public bool nextTurn = false;

	[SerializeField] private Bar _timerBar;

	void Update()
	{
		/*
		x = x + 1;
		x += 1;
		x++;
		*/
		currentTime += timerSpeed * Time.deltaTime;
		
		if(currentTime >= 1)
		{
			nextTurn = true;
			currentTime = 0;
		}
		_timerBar.SetBar(currentTime,1);
	}
}
