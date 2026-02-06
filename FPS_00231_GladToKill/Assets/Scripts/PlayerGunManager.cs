using System;
using UnityEngine;

//Gerer les armes
public class PlayerGunManager : MonoBehaviour
{
    [SerializeField] WeaponBase[] weapons;

    private int weaponIndex = 0;

    private WeaponBase CurrentWeapon => weapons[weaponIndex];

    public void UpdateWeapon()
    {
        CurrentWeapon.UpdateWeapon();
    }

    public void OnFirePressed()
    {
        CurrentWeapon.OnFirePressed();
    }

    public void OnFireReleased()
    {
        CurrentWeapon.OnFireReleased();
    }

    public void OnReload()
    {
        CurrentWeapon.OnReload();
    }
}
