using UnityEngine;
using UnityEngine.EventSystems;

public class DisactivateJoystickTutorial : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private TutorialJoystick _tutorialJoystick;

    public void OnPointerDown(PointerEventData eventData)
    {
        _tutorialJoystick.TurnOffTutor();
    }
}
