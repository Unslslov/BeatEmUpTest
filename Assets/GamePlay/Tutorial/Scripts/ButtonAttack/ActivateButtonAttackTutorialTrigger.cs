using System.Collections;
using UnityEngine;

public class ActivateButtonAttackTutorialTrigger : MonoBehaviour
{
    [SerializeField] private TutorialButtonAttack _tutorialButtonAttack;

    private void OnTriggerEnter(Collider col) 
    {
        if(col.CompareTag("Player") && _tutorialButtonAttack != null)
        {
            StartCoroutine(TimerActivate());    
        }
    }

    private IEnumerator TimerActivate()
    {
        yield return new WaitForSeconds(2f);

        Time.timeScale = 0;
        _tutorialButtonAttack.gameObject.SetActive(true);
    }
}
