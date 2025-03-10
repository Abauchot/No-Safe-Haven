using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerLocomotionInput : MonoBehaviour, PlayerControls.IPlayerLocomotionMapActions
{
    public PlayerControls PlayerControls { get; private set; }
    public Vector2 MovementInput { get; private set; }

    private void OnEnable()
    {
        PlayerControls = new PlayerControls();
        PlayerControls.Enable();
        PlayerControls.PlayerLocomotionMap.Enable();
        PlayerControls.PlayerLocomotionMap.SetCallbacks(this);
    }

    private void OnDisable()
    {
        PlayerControls.PlayerLocomotionMap.Disable();
        PlayerControls.PlayerLocomotionMap.RemoveCallbacks(this);
    }

    public void OnMovement(InputAction.CallbackContext context)
    {
        MovementInput = context.ReadValue<Vector2>();
        if (context.canceled)
        {
            MovementInput = Vector2.zero;
        }
    }
}