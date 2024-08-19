using System.Collections;
using UnityEngine;

public class TutorialJoystick : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private Animator _arrowAnim;

    private Animator _anim;
    private Transform _parentJoystick;

    private void Start() 
    {
        _anim = _joystick.GetComponent<Animator>();
        _anim.enabled = true;
        _arrowAnim.SetTrigger("Left");
        
        _parentJoystick = _joystick.transform.parent;

        SetParentForJoystick();
    }

    public void TurnOffTutor()
    {
        ResetParentForJoystick();

        StartCoroutine(Destroy());
    }
    private IEnumerator Destroy()
    {
        yield return  new WaitForSeconds(0.5f);

        Destroy(_anim);
        Destroy(gameObject);
    }

    private void SetParentForJoystick()
    {
        _joystick.transform.SetParent(transform);
        _joystick.transform.SetAsFirstSibling();
    }

    private void ResetParentForJoystick()
    {
        _joystick.transform.SetParent(_parentJoystick);
    }
}
