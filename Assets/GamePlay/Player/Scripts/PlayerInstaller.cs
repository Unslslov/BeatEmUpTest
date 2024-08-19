using UnityEngine;
using Zenject;

public class PlayerInstaller : MonoInstaller
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerAttackUI _characterAttackButton;

    public override void InstallBindings()
    {
        Container.BindInstance(_joystick).AsSingle();
        Container.BindInstance(_characterAttackButton).AsSingle();
    }
}