using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodMagicAbility : PlayerAbility
{
    public override void UseAbility()
    {
        if(_turnTimer.IsNextTurn())
        {
            int damage = Random.Range(50, 80);
            _player.DealDamage(20);
            _enemy.DealDamage(damage);
            
            EndTurn();
        }
    }
}
