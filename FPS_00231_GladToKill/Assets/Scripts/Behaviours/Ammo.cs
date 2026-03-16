using UnityEngine;
using System;

public class Ammo : MonoBehaviour
{
    [Header("Ammo Parameters")]
    [SerializeField] private int maxAmmo = 10;
    [SerializeField] private int maxMagazine = 3;
    [SerializeField] private float reloadTime = 2f;

    private float reloadTimer = 0f;

    private bool isReloading = false;
    public bool IsReloading => isReloading;

    private int remainingAmmo = 10;
    private int remainingMagazines = 3;

    public int RemainingAmmo => remainingAmmo;
    public int RemainingMagazine => remainingMagazines;
    public int MaxAmmo => maxAmmo;

    public event Action OnReloadFinished;



    private void Awake()
    {
        remainingAmmo = maxAmmo;
        remainingMagazines = maxMagazine;
    }


    public void UpdateReload(float deltaTime)
    {
        if (isReloading)
        {
            reloadTimer += deltaTime;
            if (reloadTimer >= reloadTime)
            {
                Reload();
            }
        }
    }

    public void FireShot()
    {
        remainingAmmo = Mathf.Max(0, remainingAmmo - 1);
    }

    public bool HasAmmo()
    {
        return remainingAmmo > 0;
    }

    public bool CanReload()
    {
        return remainingMagazines > 0 && !isReloading && remainingAmmo < maxAmmo;
    }

    public void StartReload()
    {
        if (!CanReload())
            return;

        isReloading = true;
    }

    private void Reload()
    {
        isReloading = false;
        remainingAmmo = maxAmmo;
        reloadTimer = 0f;
        remainingMagazines = Mathf.Max(0, remainingMagazines - 1);
        Debug.Log("Reloaded. Current Magazine: " + remainingMagazines);

        OnReloadFinished?.Invoke();
    }
}
