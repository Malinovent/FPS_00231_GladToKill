using UnityEngine;
using System;

public abstract class WeaponBase : MonoBehaviour
{
    [SerializeField] protected string weaponName;
    public static event Action<WeaponInformation> onUpdateWeapon;

    public void SendUpdateWeapon(WeaponInformation info)
    {
        //Envoyer message aux class connecte
        onUpdateWeapon?.Invoke(info);
    }

    public abstract void UpdateWeapon();
    public abstract void OnFirePressed();
    public abstract void OnFireReleased();
    public abstract void OnReload();
}

public struct WeaponInformation
{
    public string weaponName;
    public string ammoRemaining;
    public string ammoMax;
    public string magazineRemaining;

    public WeaponInformation(string weaponName, string ammoRemaining, string ammoMax, string magazineRemaining)
    {
        this.weaponName = weaponName;
        this.ammoRemaining = ammoRemaining;
        this.ammoMax = ammoMax;
        this.magazineRemaining = magazineRemaining;
    }
}
