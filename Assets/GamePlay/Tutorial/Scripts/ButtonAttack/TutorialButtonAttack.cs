using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TutorialButtonAttack : MonoBehaviour
{
    [SerializeField] private Button _buttonAttakc;
    [SerializeField] private Animator _arrowAnim;

    private Transform _parentJoystick;

    private void Start() 
    {
        _arrowAnim.SetTrigger("Right");
        
        _parentJoystick = _buttonAttakc.transform.parent;

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

        Destroy(gameObject);
    }

    private void SetParentForJoystick()
    {
        _buttonAttakc.transform.SetParent(transform);
        _buttonAttakc.transform.SetAsFirstSibling();
    }

    private void ResetParentForJoystick()
    {
        _buttonAttakc.transform.SetParent(_parentJoystick);
    }
}
