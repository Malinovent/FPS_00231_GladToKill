using UnityEngine;
using TMPro;

public class UIWeaponManager : MonoBehaviour
{
    [SerializeField] private TMP_Text remainingAmmo;
    [SerializeField] private TMP_Text maxAmmo;
    [SerializeField] private TMP_Text remainingMagazine;
    [SerializeField] private TMP_Text weaponName;

    private void OnEnable()
    {
        WeaponBase.onUpdateWeapon += SetText;

        //WeaponInformation info = new WeaponInformation("", "", "", "");
        //WeaponBase.onUpdateWeapon?.Invoke(info);
    }

    private void OnDisable()
    {
        WeaponBase.onUpdateWeapon -= SetText;
    }

    private void SetText(string weaponName, string remainingAmmo, string maxAmmo, string remainingMagaine)
    {
        this.weaponName.SetText(weaponName);
        this.remainingAmmo.SetText(remainingAmmo);
        this.maxAmmo.SetText(maxAmmo);
        this.remainingMagazine.SetText(remainingMagaine);
    }

    private void SetText(WeaponInformation info)
    {
        this.weaponName.SetText(info.weaponName);
        this.remainingAmmo.SetText(info.ammoRemaining);
        this.maxAmmo.SetText(info.ammoMax);
        this.remainingMagazine.SetText(info.magazineRemaining);
    }

}
