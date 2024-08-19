using UnityEngine;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private LayerMask _collisionLayer;
    [SerializeField] private float _radius = 1f;
    [SerializeField] private int _damage = 20;
    [SerializeField] private GameObject _hitFXPrefab;
    
    void Update()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider[] hit = Physics.OverlapSphere(transform.position, _radius, _collisionLayer);
      
        if(hit.Length > 0)
        {
            Vector3 hitFX_Pos = transform.position;

            var go = Instantiate(_hitFXPrefab, hitFX_Pos, Quaternion.identity);
            // Debug.Log(go.transform.position);

            hit[0].GetComponent<IApplyDamage>().ApplyDamage(_damage);
       
            gameObject.SetActive(false);
        }
    }
}   
