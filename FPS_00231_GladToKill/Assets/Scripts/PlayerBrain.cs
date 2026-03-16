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

/// <summary>
/// Interact with interactables
/// </summary>
public class Interactor : MonoBehaviour
{
    [SerializeField] private float raycastDistance = 3;
    [SerializeField] private Raycaster raycaster;

    //Store interactable
    private IInteractable currentObject;

    public void FindInteractable()
    {
        //Ray pour trouver interactable
        RaycastHit hit = raycaster.FireShot();

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();

        currentObject = interactable;
    }

    public void Interact()
    {
        /*if(currentObject)
        {
            currentObject.Interact();
        }*/

        currentObject?.Interact();
        //Interact with object
    }
}

public abstract class InteractableObject : MonoBehaviour
{
    public abstract void Interact();
}

public class Door : InteractableObject
{
    public override void Interact()
    {
        OpenDoor();
    }

    private void OpenDoor()
    {
        
    }
}

public class NPC : InteractableObject
{
    public override void Interact()
    {
        StartDialogue();
    }

    private void StartDialogue()
    {

    }
}

public class Lever : InteractableObject
{
    private bool isActive = false;

    public override void Interact()
    {
        isActive = !isActive;
    }
}



public interface IInteractable
{
    public void Interact();
}


public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private int startingHealth;
    [SerializeField] private int maxHealth;

    private int currentHealth;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(this.gameObject);
    }
}

public class Dummy : MonoBehaviour, IDamageable
{
    public void TakeDamage(int amount)
    {
        //Jouer animation
    }
}

public interface IDamageable
{
    public void TakeDamage(int amount);
}
