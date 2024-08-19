using System;
using UnityEngine;

public class Health
{
    public event Action<int> OnHealthChangedEvent;
    public event Action OnDiedEvent;

    private int _value;
    private int _startValue;

    public int Value => _value;


    public Health(int value)
    {
        _value = value;
        _startValue = value;
    }

    public void TakeDamage(int value)
    {
        _value -= value;

        if(_value <= 0)
        {
            OnHealthChangedEvent?.Invoke(_value);
            OnDiedEvent?.Invoke();
        }
        else 
        {
            OnHealthChangedEvent?.Invoke(_value);
        }
    }

    public void ResetValue()
    {
        if(_value <= 5)
        {
            _value = _startValue;
            Debug.Log("Reset HP");
        }
    }
}
