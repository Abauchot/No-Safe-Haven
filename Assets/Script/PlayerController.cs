using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D _rb;
    private PlayerLocomotionInput _playerLocomotionInput;
    
    [SerializeField] public float speed = 5f;
    

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerLocomotionInput = GetComponent<PlayerLocomotionInput>();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 movement = _playerLocomotionInput.MovementInput;
        _rb.linearVelocity = movement * speed;
    }
}
