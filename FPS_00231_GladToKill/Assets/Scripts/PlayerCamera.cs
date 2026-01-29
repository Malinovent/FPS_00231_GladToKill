using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private Transform cameraTransform;
    [SerializeField] private float minClamp = -30;
    [SerializeField] private float maxClamp = 60;

    private float pitch = 0;

    public void Rotate(float inputY)
    {

        pitch -= inputY;
        pitch = Mathf.Clamp(pitch, minClamp, maxClamp);

        cameraTransform.localEulerAngles = new Vector3(pitch, 0, 0);

    }
}
