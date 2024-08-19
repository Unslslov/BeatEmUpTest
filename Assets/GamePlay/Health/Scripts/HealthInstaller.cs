using UnityEngine;
using Zenject;

public class HealthInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        var playerHealth = new Health(100);

        Container.BindInstance(playerHealth).WithId(HealthId.Player).AsTransient();

        // var simpleFighterHealth = new Health(100);

        // Container.BindInstance(simpleFighterHealth).WithId(HealthId.SimpleFighter).AsTransient();
        // // Container.Bind<Health>().FromMethod(ctx => new Health(100)).AsTransient().WithId(HealthId.SimpleFighter);//   WithId(HealthId.SimpleFighter).AsTransient();
        // // Container.Bind<Health>().ToSelf().AsTransient().WithArguments(100).WhenInjectedInto<SimpleFighterHealth>();
    }
}
public enum HealthId
{
    Player,
    SimpleFighter
}