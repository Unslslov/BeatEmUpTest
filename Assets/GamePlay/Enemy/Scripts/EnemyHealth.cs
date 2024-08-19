using UnityEngine;
using Zenject;

public abstract class EnemyHealth : MonoBehaviour, IApplyDamage
{
    [SerializeField] protected FighterAnimation _characterAnimation;
    protected Health _health;

    public void ApplyDamage(int damage)
    {
        _health.TakeDamage(damage);
    }
}
