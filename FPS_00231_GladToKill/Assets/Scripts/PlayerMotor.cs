using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    [SerializeField] private CharacterController characterController;

    [SerializeField] private float vitesse = 5;

    public void Move(Vector2 input)
    {
        Vector3 direction = transform.right * input.x + transform.forward * input.y;


        characterController.Move(direction * vitesse * Time.deltaTime);
    }

    public void Rotate(float inputX)
    {
        Vector3 rotateInput = new Vector3(0,inputX,0);

        transform.Rotate(rotateInput);
    }
}
