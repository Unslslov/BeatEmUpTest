using System.Collections;
using UnityEngine;

public class ActivateJoystickTutorial : MonoBehaviour
{
    [SerializeField] private TutorialJoystick _joystickTutor;
    private void Awake() 
    {
        StartCoroutine(TimerActivate());
    }

    private IEnumerator TimerActivate()
    {
        yield return new WaitForSeconds(1f);

        _joystickTutor.gameObject.SetActive(true);
    }
}
