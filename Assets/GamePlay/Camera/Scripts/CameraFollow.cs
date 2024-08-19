using UnityEngine;
using Zenject;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private float _smoothSpeed = 1f; 

    [SerializeField] private PlayerMovement _target; 
    // [SerializeField] private GameObject _target;
    [SerializeField] private float _offsetZ;

    [Inject]
    public void Constructor(PlayerMovement player)
    {
        _target = player;
    }

    void LateUpdate()
    {
        // Debug.Log(transform.position.z + 2 <  _target.transform.position.z);

        _offsetZ = _target.transform.position.z;

        Vector3 desiredPosition = 
            new Vector3(transform.position.x, transform.position.y, _offsetZ);

        var currentTransformPosZ = new Vector3(transform.position.x,transform.position.y, transform.position.z);

        Vector3 smoothedPosition = Vector3.Lerp(currentTransformPosZ, desiredPosition, _smoothSpeed); //Time.deltaTime * 10f);
        
        // Debug.Log("currentTransformPosZ" + currentTransformPosZ);
        // Debug.Log("desiredPosition" + desiredPosition);

        transform.position = smoothedPosition;
        
        // Опционально можно вращать камеру, чтобы она всегда смотрела на персонажа
        // transform.LookAt(target.transform);
        
    }
}
