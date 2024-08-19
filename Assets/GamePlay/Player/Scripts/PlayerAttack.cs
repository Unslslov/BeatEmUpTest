using System;
using System.Collections;
using UnityEngine;
using Zenject;

public class PlayerAttack : AttackAnimation
{
    private PlayerAttackUI _playerAttackUI;
    private ComboAttack _comboAttack;
    private FighterAnimation _fighterAnimation;

    float _animationTime;

    private bool _activateTimeToReset;
    private float _defaultComboTimer = 0.4f;
    private float _currentComboTimer;

    [Inject]
    public void Constructor([Inject(Id = FighterType.Player)] FighterAnimation fighterAnimation, PlayerAttackUI playerAttackUI)
    {
        _fighterAnimation = fighterAnimation;
        _playerAttackUI = playerAttackUI;
    
        _playerAttackUI.OnAttackButtonClicked += OnAttack;
    }

    void Start()
    {
        _currentComboTimer = _defaultComboTimer;
        _comboAttack = ComboAttack.None;
    }

    private void OnDestroy() 
    {
        _playerAttackUI.OnAttackButtonClicked -= OnAttack;    
    }

    private void OnAttack()
    {
        Attack();
    }

    protected override void Attack()
    {
        if(_animationTime <= 0)
        {
            AttackInput();

            DoAnimate(_comboAttack); // Animation have event for attack
        }
        
    }
    void ResetComboState()
    {
        if(_activateTimeToReset)
        {
            _currentComboTimer -=  Time.deltaTime;
            if(_currentComboTimer <= 0)
            {
                _comboAttack = ComboAttack.None;
                _activateTimeToReset = false;
                _currentComboTimer = _defaultComboTimer;
            }
        }
    }

    private void AttackInput()
    {
        if (_comboAttack == ComboAttack.None)
        {
            _comboAttack = ComboAttack.FirstStrokeСondition; 
        }
        else if (_comboAttack == ComboAttack.FirstStrokeСondition)
        {
            _comboAttack = ComboAttack.SecondStrokeСondition;
        }
        else if (_comboAttack == ComboAttack.SecondStrokeСondition)
        {
            _comboAttack = ComboAttack.FirstStrokeСondition; 
        }
    }

    private void DoAnimate(ComboAttack typeAttack)
    {
        if(typeAttack == ComboAttack.FirstStrokeСondition)
        {
            _fighterAnimation.Kick_1(out float time, true);
            _animationTime = time;
            // Debug.Log(_animationTime);
            StartCoroutine(AnimationTike());
        }
        else if(typeAttack == ComboAttack.SecondStrokeСondition)
        {
            _fighterAnimation.Kick_2(out float time, true);
            _animationTime = time;
            StartCoroutine(AnimationTike());
        }
    }

    private IEnumerator AnimationTike()
    {
        while(_animationTime > 0)
        {
            _animationTime -= Time.deltaTime;
            // Debug.Log(_animationTime);
            yield return null;
        } 
    }
}