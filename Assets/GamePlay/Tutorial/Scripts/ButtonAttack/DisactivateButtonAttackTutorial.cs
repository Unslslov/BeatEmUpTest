using UnityEngine;
using UnityEngine.EventSystems;

public class DisactivateButtonAttackTutorial : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TutorialButtonAttack _tutorialButtonAttack;

    public void OnPointerDown(PointerEventData eventData)
    {
        _tutorialButtonAttack.TurnOffTutor();
        Time.timeScale = 1;
    }
}
