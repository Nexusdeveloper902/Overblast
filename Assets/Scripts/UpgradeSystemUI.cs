using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystemUI : MonoBehaviour
{
    [SerializeField] private GameObject[] upgrades;
    
    public static  UpgradeSystemUI Instance;
    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        
    }

    public void InstantiateUpgrades()
    {
        foreach (GameObject upgrade in upgrades)
        {
            GameObject panel = Instantiate(upgrade, transform);

            // Find the button inside the spawned panel
            Button button = panel.GetComponentInChildren<Button>();

            // Assign the function
            button.onClick.AddListener(UpgradeSystem.Instance.AutoFireWeapon);
        }
    }
}
