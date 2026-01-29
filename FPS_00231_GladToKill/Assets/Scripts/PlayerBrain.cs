using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{

    [SerializeField] PlayerMotor playerMotor;
    [SerializeField] PlayerCamera playerCamera;

    PlayerControls controls;

    private Vector2 moveInput;



    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.FPS.Jump.performed += Jump;

        controls.FPS.Move.performed += Move;
        controls.FPS.Move.canceled += Move;

        controls.FPS.Look.performed += Look;
    }

    private void Update()
    {
        playerMotor.Move(moveInput);
    }

    private void Jump(InputAction.CallbackContext ctx)
    {
        Debug.Log("Jump!");
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        moveInput = ctx.ReadValue<Vector2>();
    }

    private void Look(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        playerMotor.Rotate(input.x);
        playerCamera.Rotate(input.y);
    }

    private void Sprint(InputAction.CallbackContext ctx)
    {
        Debug.Log("Sprint!");
    }
}
