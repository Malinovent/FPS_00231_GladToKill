using System.Collections.Generic;
using UnityEngine;

//Gerer le pistolet
public class Pistolet : WeaponBase
{
    [SerializeField] private Ammo ammo;
    [SerializeField] private Raycaster raycaster;

    public override void OnFirePressed()
    {
        if (ammo.HasAmmo() && ammo.IsReloading == false)
        {
            ammo.FireShot();
            raycaster.FireShot();
        }
    }

    public override void OnReload()
    {
        ammo.StartReload();
    }

    //Called each frame from PlayerBrain
    public override void UpdateWeapon()
    {
        ammo.UpdateReload(Time.deltaTime);
    }

    public override void OnFireReleased()
    {
        
    }
}
