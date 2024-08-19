using UnityEngine;
using Zenject;

public class FightersInstaller : MonoInstaller
{
    [SerializeField] private FighterAnimation _characterAnimation;

    public override void InstallBindings()
    {
        Container.BindInstance(_characterAnimation).WithId(FighterType.Player).AsTransient();
    }
}