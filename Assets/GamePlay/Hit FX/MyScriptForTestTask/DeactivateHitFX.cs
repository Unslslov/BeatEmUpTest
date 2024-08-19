using UnityEngine;

public class DeactivateHitFX : MonoBehaviour
{
    [SerializeField] private float timer = 2f;

    void Start()
    {
        Invoke("DeactivateAfterTime", timer);
    }

    void DeactivateAfterTime()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);    
    }
}
