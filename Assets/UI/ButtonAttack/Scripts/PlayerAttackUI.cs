using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class PlayerAttackUI : MonoBehaviour
{
    [SerializeField] private Button _button;
    public event Action OnAttackButtonClicked;

    private void OnValidate() 
    {
        _button ??= GetComponent<Button>();
    }

    private void Start() 
    {
        _button.onClick.AddListener(HandleAttackButtonClicked);
    }

    private void OnDestroy() 
    {
        _button.onClick.RemoveListener(HandleAttackButtonClicked);
    }

    private void HandleAttackButtonClicked() 
    {
        OnAttackButtonClicked?.Invoke();
    }
}
