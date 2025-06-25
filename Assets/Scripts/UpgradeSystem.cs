using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public static  UpgradeSystem Instance;

    [SerializeField] private  GameObject autoFireWeapon;

    public bool hasAutoFireGun = false;
    
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    // Update is called once per frame
    public void AutoFireWeapon()
    {
        Instantiate(autoFireWeapon);
        UI.Instance.HideLevelUpPanel();
        UpgradeSystemUI.Instance.DestroyUpgrades();
        hasAutoFireGun = true;
    }

    public void HealthUpgrade()
    {
        UI.Instance.maxHealth += 5;
        Player.Instance.maxHealth += 5;
        UI.Instance.SetHealthInUI(Player.Instance.health);
        UI.Instance.HideLevelUpPanel();
        UpgradeSystemUI.Instance.DestroyUpgrades();
    }
}
