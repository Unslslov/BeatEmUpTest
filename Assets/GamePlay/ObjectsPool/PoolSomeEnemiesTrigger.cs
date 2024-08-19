using UnityEngine;

public class PoolSomeEnemiesTrigger : MonoBehaviour
{
    [SerializeField] private PoolSimpleFighters _pool;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
           _pool.CreateSomeFighters(Random.Range(1,3));
        }
    }
}
