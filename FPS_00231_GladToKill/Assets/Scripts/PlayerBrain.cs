using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBrain : MonoBehaviour
{

    [SerializeField] PlayerMotor playerMotor;
    [SerializeField] PlayerCamera playerCamera;
    [SerializeField] PlayerGunManager playerGunManager;

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

        controls.FPS.Fire.performed += OnFirePressed;
        controls.FPS.Fire.canceled += OnFireReleased;
        
        controls.FPS.Reload.performed += OnReload;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnReload(InputAction.CallbackContext obj)
    {
        playerGunManager.OnReload();
    }

    private void OnFireReleased(InputAction.CallbackContext obj)
    {
        playerGunManager.OnFireReleased();
    }

    private void OnFirePressed(InputAction.CallbackContext ctx)
    {
        playerGunManager.OnFirePressed();
    }

    private void Update()
    {
        playerMotor.Move(moveInput);
        playerGunManager.UpdateWeapon();
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
