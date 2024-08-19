using UnityEngine;
using Zenject;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private float _speed = 10f;
    [SerializeField] private float rotation_Speed = 15f;

    private Joystick _joystick;
    private FighterAnimation _characterAnimation;
    private Vector3 _moveDirection;

    [SerializeField] private Transform prefabPlayer;
    private float _rotationY = -180;

    private void OnValidate() 
    {
        _rb ??= GetComponent<Rigidbody>();
        prefabPlayer ??= transform.GetChild(0);
    }

    [Inject]
    public void Constructor(Joystick joystick,[Inject(Id = FighterType.Player)] FighterAnimation characterAnimation)
    {
        _joystick = joystick;
        _characterAnimation = characterAnimation;
    }

    private void Update() 
    {
        _moveDirection = _joystick.Horizontal * Vector3.forward + _joystick.Vertical * Vector3.left;

        RotatePlayer(); 

        AnimatePlayerWalk();
    }

    private void FixedUpdate() 
    {
        Move(_moveDirection);
    }

    private void Move(Vector3 direction)
    {
        _rb.velocity = new Vector3(direction.x * _speed, _rb.velocity.y, direction.z * _speed);
        // Debug.Log("Direction: " + direction);
    }

    // void RotatePlayer()
    // {
    //     if (_joystick.Horizontal < 0)
    //     {
    //         _rotationY = 180f; 
    //     }
    //     else if (_joystick.Horizontal > 0)
    //     {
    //         _rotationY = 0;
    //     }
    //     else
    //     {
    //         return;
    //     }

    //     Quaternion targetRotation = Quaternion.Euler(0f, _rotationY, 0f);

    //     //TODO : Coroutine change  rotation smoothly

    //     prefabPlayer.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotation_Speed);
    // }

    void RotatePlayer()
{
    if (_moveDirection.magnitude > 0)
    {
        Vector3 targetDirection = _moveDirection.normalized;

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);

        prefabPlayer.rotation = Quaternion.Slerp(prefabPlayer.rotation, targetRotation, rotation_Speed * Time.deltaTime);
    }
}

    void AnimatePlayerWalk()
    {
        bool isMovingOnX = _joystick.Horizontal != 0;
        bool isMovingOnY = _joystick.Vertical != 0;

        if(isMovingOnX || isMovingOnY)
        {
            _characterAnimation.Walk(true);
        }
        else
        {
            _characterAnimation.Walk(false);
        }
    }
}
