using UnityEngine;
using Zenject;

public class PoolSimpleFighters : MonoBehaviour
{
    [SerializeField] private int _poolCount;
    [SerializeField] private bool _autoExpand;
    [SerializeField] private EnemyMovement _fighterPrefab;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _spawnPoint;
    
    public Transform Container => _container;

    private PlayerMovement _player;
    private PoolMono<EnemyMovement> _pool;


    [Inject]
    public void Constructor(PlayerMovement player)
    {
        _player = player;
    }

    private void Start() 
    {
        _fighterPrefab.SetPlayer(_player);

        _pool = new PoolMono<EnemyMovement>(_fighterPrefab, _poolCount, _container);
        _pool.autoExpand = _autoExpand;
    }

    public void CreateFighter()
    {
        var _pointPosition = _spawnPoint.position;

        var rX = Random.Range(_pointPosition.x - 1f ,_pointPosition.x + 1f);
        var rZ = _pointPosition.z;
        var y = 0f;

        var rPosition = new Vector3(rX, y, rZ);
        var prefab = _pool.GetFreeElement();
        prefab.transform.position = rPosition;
    }

     public void CreateSomeFighters(int count)
    {
        var _pointPosition = _spawnPoint.position;

        var prefabs = _pool.GetFreeSomeElement(count);

        foreach(var prefab in prefabs)
        {
            var rX = Random.Range(_pointPosition.x - 1f, _pointPosition.x + 1f);
            var rZ = _pointPosition.z;
            var y = 0f;
            
            var rPosition = new Vector3(rX, y, rZ);

            prefab.transform.position = rPosition;
        }
    }
}
