using System.Linq;
using UnityEngine;

public class FighterAnimation : MonoBehaviour
{
    [SerializeField] private Animator _anim;
    private bool isAlive = true;

    private void OnValidate() 
    {
        _anim ??= transform.GetChild(0).GetComponent<Animator>();
    }

    private  void OnEnable() 
    {
        isAlive = true;
    }

    public void Play_IdleAnimation()
    {
        if (!isAlive)
            return;

        _anim.Play(AnimationTags.IDLE_ANIMATION);
    }

    public void Walk(bool move)
    {
        if (!isAlive)
            return;

        _anim.SetBool(AnimationTags.MOVE_FORWARD_D, move);
    }

    public void Kick_1(out float animationTime, bool needAnimationTime = false)
    {
        animationTime = 0f;
        
        if (!isAlive)
            return;

        if(needAnimationTime == true)
        {
            AnimationClip clip = _anim.runtimeAnimatorController.animationClips.FirstOrDefault(c => c.name == "bk_rh_left_A");
            if (clip == null)
            {
                Debug.LogError($"Animation clip '{AnimationTags.KICK_1_TRIGGER}' not found in Animator.");
                animationTime = 0f; // Устанавливаем значение по умолчанию
                return;
            }

            animationTime = clip.length;
        }
        
        _anim.SetTrigger(AnimationTags.KICK_1_TRIGGER);
    }
    public void Kick_2(out float animationTime, bool needAnimationTime = false)
    {
        animationTime = 0f;

        if (!isAlive)
            return;

        if(needAnimationTime == true)
        {
            AnimationClip clip = _anim.runtimeAnimatorController.animationClips.FirstOrDefault(c => c.name == "bk_knee_right_A");
            if (clip == null)
            {
                Debug.LogError($"Animation clip '{AnimationTags.KICK_1_TRIGGER}' not found in Animator.");
                animationTime = 0f; // Устанавливаем значение по умолчанию
                return;
            }

            animationTime = clip.length;
        }

        _anim.SetTrigger(AnimationTags.KICK_2_TRIGGER);
    }

    public void KnockDown()
    {
        isAlive = false;

        _anim.SetTrigger(AnimationTags.KNOCKDOWN_I);
    }
    public void Death()
    {
         isAlive = false;

        _anim.SetTrigger(AnimationTags.KNOCKDOWN_I);
    }
}