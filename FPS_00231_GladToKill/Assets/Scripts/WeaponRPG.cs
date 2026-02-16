using UnityEngine;

public class WeaponRPG : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private ProjectileLauncher launcher;

    public override void OnFirePressed()
    {
        if(ammo.HasAmmo() && !ammo.IsReloading)
        {
            launcher.FireProjectile();
            ammo.FireShot();
            ammo.StartReload();
        } 
    }

    public override void OnFireReleased()
    {
        
    }

    public override void OnReload()
    {
        
    }

    public override void UpdateWeapon()
    {
        ammo.UpdateReload(Time.deltaTime);
    }
}
