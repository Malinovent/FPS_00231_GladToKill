using UnityEngine;

public class WeaponSMG : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Raycaster raycaster;

    [Header("Rate of Fire")]
    [SerializeField] private float roundsPerSecond = 1f;

    private float timeBetweenShots;
    private float fireTimer;
    private bool isFiring = false;
    private bool canFire = true;

    private void Awake()
    {
        timeBetweenShots = 1 / roundsPerSecond;
    }

    public override void UpdateWeapon()
    {
        UpdateFire(Time.deltaTime);
        ammo.UpdateReload(Time.deltaTime);

        if(isFiring && !ammo.IsReloading && ammo.HasAmmo())
        {
            FireShot();
        }
    }

    public override void OnFirePressed()
    {
        isFiring = true;
    }

    public override void OnFireReleased()
    {
        isFiring = false;
    }

    public override void OnReload()
    {
        ammo.StartReload();
    }

    private void FireShot()
    {
        ammo.FireShot();
        raycaster.FireShot();
    }

    #region RATE OF FIRE

    public void UpdateFire(float deltaTime)
    {
        if (canFire)
            return;

        fireTimer += Time.deltaTime;

        if (fireTimer >= timeBetweenShots)
        {
            canFire = true;
        }
    }

    #endregion

}
