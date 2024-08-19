using System.Collections;
using UnityEngine;

public class CreateFightZone : MonoBehaviour
{
    [SerializeField] private Collider[] _walls;
    [SerializeField] LayerMask _wallMask;
    [SerializeField] LayerMask _enemyMask;
    [SerializeField] private CameraFollow _cameraFollow;
    [SerializeField] private Transform _offsetZ;
    
    private float _time;
    private Transform _camera;

    private void OnValidate() 
    {
        if(_walls == null | _walls.Length == 0)
            _walls = new Collider[transform.childCount];
        
        for(int i = 0; i < _walls.Length; i++)
        {
            _walls[i] ??= transform.GetChild(i).GetComponent<Collider>();
        }
    }

    private void Start() 
    {
        // Debug.Log(_wallMask.value); 
        // Debug.Log(_enemyMask.value);

        // Не понимаю почему, но выдает ошибку, что диапазон должен быть между 0 и 31, но _wallMask и _enemyMask == 7 и 8
        Physics.IgnoreLayerCollision(7, 8);
    }

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player"))
        {
            foreach(var wall in _walls)
            {
                wall.gameObject.SetActive(true);

                _cameraFollow.enabled = false;
                _camera = _cameraFollow.gameObject.transform;

                StartCoroutine(SetCameraPos());
            }
        }    
    }

    private IEnumerator SetCameraPos()
    {
        while(_time <= 1)
        {
            _time += Time.deltaTime;

            var newOffsetZ = new Vector3(_camera.position.x, _camera.position.y, _offsetZ.position.z);

            _camera.transform.position = Vector3.Lerp(_camera.position, newOffsetZ, _time);

            yield return null;
        }

        this.enabled = false;
    }
}
