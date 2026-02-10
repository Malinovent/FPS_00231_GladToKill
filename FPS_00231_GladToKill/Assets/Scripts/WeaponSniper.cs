using UnityEngine;

public class WeaponSniper : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Raycaster raycaster;
    [SerializeField] private RateOfFire rateOfFire;

    public override void OnFirePressed()
    {
        if (rateOfFire.CanFire && ammo.HasAmmo() && ammo.IsReloading == false)
        {
            ammo.FireShot();
            raycaster.FireShot();
            rateOfFire.FireShot();
        }
    }

    public override void OnFireReleased()
    {
        
    }

    public override void OnReload()
    {
        ammo.StartReload();
    }

    public override void UpdateWeapon()
    {
        ammo.UpdateReload(Time.deltaTime);
        rateOfFire.UpdateFire(Time.deltaTime);
    }
}
