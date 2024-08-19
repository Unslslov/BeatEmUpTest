using UnityEngine;
using UnityEngine.UI;

public abstract class HealthView : MonoBehaviour
{
    [SerializeField] protected Image HealthBar;
    [SerializeField] protected Health _health;

    public virtual void Constructor(Health health)
    {
        _health = health;
        _health.OnHealthChangedEvent += OnHealthChanged;
        _health.OnDiedEvent += OnDied;
    }
    public virtual void OnHealthChanged(int value)
    {
        HealthBar.fillAmount = value/100f;
    }

    public virtual void OnDied() => Destroy(gameObject);

    private void OnDestroy()
    {  
        _health.OnHealthChangedEvent -= OnHealthChanged;
        _health.OnDiedEvent -= OnDied;
    }
}
