using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class PlayerHealth : MonoBehaviour, IApplyDamage
{
    private Health _health;
    private FighterAnimation _characterAnimation;

    [Inject]
    public void Constructor
    ([Inject(Id = FighterType.Player)] FighterAnimation characterAnimation, 
    [Inject(Id = HealthId.Player)] Health health)
    {
        _characterAnimation = characterAnimation;

        _health = health;
        _health.OnDiedEvent += OnDied;
    }

    #region DeleteAfterTesting
    // private void Update() 
    // {
    //     if(Input.GetKeyDown(KeyCode.Z))
    //         Debug.Log(_health.Value);

    //     if(Input.GetKeyDown(KeyCode.X))
    //         _health.TakeDamage(20);
    // }
    #endregion DeleteAfterTesting

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }

    private void OnDied()
    {
        _characterAnimation.KnockDown();

        StartCoroutine(RestartLevel());
    }

    private IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(5f);

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.buildIndex);
    }
}
