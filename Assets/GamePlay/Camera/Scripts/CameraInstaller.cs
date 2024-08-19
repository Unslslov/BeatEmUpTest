using UnityEngine;
using Zenject;

public class CameraInstaller : MonoInstaller
{
    [SerializeField] private PlayerMovement _player;

    public override void InstallBindings()
    {
        Container.BindInstance(_player).AsSingle();
    }
}