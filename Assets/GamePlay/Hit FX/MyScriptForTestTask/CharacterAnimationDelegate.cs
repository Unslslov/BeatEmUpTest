using UnityEngine;

public class CharacterAnimationDelegate : MonoBehaviour
{
    public GameObject leftLegAttackPoint, rightLegAttackPoint;

    void LeftLegAttackOn()
    {
        leftLegAttackPoint.SetActive(true);
    }
    void LeftLegAttackOff()
    {
        if(leftLegAttackPoint.activeInHierarchy)
        {
            leftLegAttackPoint.SetActive(false);
        }
    }
    void RightLegAttackOn()
    {
        rightLegAttackPoint.SetActive(true);
    }
    void RightLegAttackOff()
    {
        if(rightLegAttackPoint.activeInHierarchy)
        {
            rightLegAttackPoint.SetActive(false);
        }
    }
}
