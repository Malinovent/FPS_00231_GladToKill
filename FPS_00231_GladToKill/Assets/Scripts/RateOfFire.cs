using UnityEngine;

public class RateOfFire : MonoBehaviour
{
    [Header("Rate of Fire")]
    [SerializeField] private float roundsPerSecond = 1f;

    private float timeBetweenShots;
    private float fireTimer;
    private bool canFire = true;

    public bool CanFire => canFire;

    private void Awake()
    {
        timeBetweenShots = 1 / roundsPerSecond;
    }

    public void FireShot()
    { 
        canFire = false;
        fireTimer = 0;
        Debug.Log("Shot Fire!");
    }

    public void UpdateFire(float deltaTime)
    {
        if (canFire)
            return;

        fireTimer += deltaTime;

        if (fireTimer >= timeBetweenShots)
        {
            canFire = true;
        }
    }

}