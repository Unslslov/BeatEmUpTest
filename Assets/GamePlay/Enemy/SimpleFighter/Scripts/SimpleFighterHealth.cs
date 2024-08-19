using System.Collections;
using UnityEngine;

public class SimpleFighterHealth : EnemyHealth
{
    int maxHealth = 100;

    private void OnEnable() 
    {
        if(_health != null)
        {
            _health.ResetValue();
        }
        else 
        {
            _health = new Health(maxHealth);

            _health.OnDiedEvent += OnDied;
        }
    }

    protected void OnDied()
    {
        _characterAnimation.KnockDown();

        StartCoroutine(FighterToPool());
    }

    private IEnumerator FighterToPool()
    {
        yield return new WaitForSeconds(1f);

        gameObject.SetActive(false);
    }
}
