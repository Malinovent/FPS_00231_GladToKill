using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{

    PlayerControls controls;

    private void Awake()
    {
        controls = new PlayerControls();
        controls.Enable();

        controls.FPS.Jump.performed += Jump;

        controls.FPS.Move.performed += Move;
        controls.FPS.Move.canceled += Move;
    }


    private void Jump(InputAction.CallbackContext ctx)
    {
        Debug.Log("Jump!");
    }

    private void Move(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        Debug.Log($"Moving: {input}");
    }

    private void Look(InputAction.CallbackContext ctx)
    {
       
    }

    private void Sprint(InputAction.CallbackContext ctx)
    {
        Debug.Log("Sprint!");
    }
}
