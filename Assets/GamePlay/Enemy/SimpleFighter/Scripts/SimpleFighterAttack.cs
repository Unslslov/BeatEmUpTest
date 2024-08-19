using System.Collections;
using UnityEngine;

public class SimpleFighterAttack : EnemyAttackAnimation
{
    private float _attackTime;

    public override void Attack(FighterAnimation fighterAnimation)
    {
        if(_attackTime <= 0)
        {
            fighterAnimation.Kick_1(out float time, true);
            _attackTime = time;

            StartCoroutine(AttackAnimation());
        }
    }

    private IEnumerator AttackAnimation()
    {
        while(_attackTime > 0)
        {
            _attackTime -= Time.deltaTime;
            
            yield return null;
        }
    }
}
