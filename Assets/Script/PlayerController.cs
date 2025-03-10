using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerLocomotionInput _playerLocomotionInput;
    private Animator _animatior;
    
    [SerializeField] public float speed = 5f;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();
        _animatior = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        UpdateAnimation();
    }

    private void MovePlayer()
    {
        Vector2 movement = _playerLocomotionInput.MovementInput;
        _rb.linearVelocity = movement * speed;
        
    }
    
    private void UpdateAnimation()
    {
        Vector2 movement = _playerLocomotionInput.MovementInput;
        _animatior.SetFloat("Speed_down_f", movement.y <  0 ? Mathf.Abs(movement.y) : 0);
        Debug.Log(_animatior.GetCurrentAnimatorStateInfo(0).normalizedTime);
        _animatior.SetFloat("Speed_up_f", movement.y >  0 ? movement.y : 0);
        Debug.Log(_animatior.GetCurrentAnimatorStateInfo(0).normalizedTime);
        _animatior.SetFloat("Speed_right_f", Mathf.Abs(movement.x));
        Debug.Log(_animatior.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
