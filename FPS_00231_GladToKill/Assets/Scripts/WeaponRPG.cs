using UnityEngine;

public class WeaponRPG : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private ProjectileLauncher launcher;

    private void OnEnable()
    {
        SendInfo();
        ammo.OnReloadFinished += SendInfo;
    }

    private void OnDisable()
    {
        ammo.OnReloadFinished -= SendInfo;
    }

    public override void OnFirePressed()
    {
        if(ammo.HasAmmo() && !ammo.IsReloading)
        {
            launcher.FireProjectile();
            ammo.FireShot();
            ammo.StartReload();

            SendInfo();
        } 
    }

    public override void OnFireReleased()
    {
        
    }

    public override void OnReload()
    {
        SendInfo();
    }

    private void SendInfo()
    {
        WeaponInformation info = new WeaponInformation(weaponName, ammo.RemainingAmmo.ToString(), "__\n" + ammo.RemainingMagazine.ToString(),"");
        SendUpdateWeapon(info);
    }

    public override void UpdateWeapon()
    {
        ammo.UpdateReload(Time.deltaTime);
    }
}
