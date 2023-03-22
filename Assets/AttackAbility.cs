using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAbility : PlayerAbility
{
	public override void UseAbility()
	{
		Debug.Log("ATTACK!");
		EndTurn();
	}
}
