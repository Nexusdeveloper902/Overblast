using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSystem : MonoBehaviour
{
    public static  UpgradeSystem Instance;

    [SerializeField] private  GameObject autoFireWeapon;
    
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
    }
}
