using UnityEngine;

public class AlwaysPoolingFightersTrigger : MonoBehaviour
{
    [SerializeField] private PoolSimpleFighters _pool;
    private bool _isCreated;
    private float _time;
    private int _enemyWave = 1;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
           _isCreated = true;
        }
    }

    private void Update() 
    {
        if(_isCreated)
        {
            if(_time >= 7.5f)
            {
                _time = 0;

                if(_enemyWave <= 5)
                    _enemyWave++;
            }

            if(_time <= 0)
            {
                _pool.CreateSomeFighters(_enemyWave);
            }

            _time += Time.deltaTime;
        }
    }
}
