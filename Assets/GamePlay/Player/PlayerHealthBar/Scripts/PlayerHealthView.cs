using UnityEngine;
using Zenject;

public class PlayerHealthView : HealthView
{
    [Inject]
    public override void Constructor([Inject(Id = HealthId.Player)] Health health)
    {
        base.Constructor(health);
    }

    
}
