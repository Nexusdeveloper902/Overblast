using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystemUI : MonoBehaviour
{
    [SerializeField] private GameObject[] upgrades;

    private List<GameObject> spawnedUpgrades = new List<GameObject>();

    public static UpgradeSystemUI Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void InstantiateUpgrades()
    {
        foreach (GameObject upgrade in upgrades)
        {
            
            if (upgrade.CompareTag("AutoFireGun") && UpgradeSystem.Instance.hasAutoFireGun)
                continue;

            GameObject panel = Instantiate(upgrade, transform);
            spawnedUpgrades.Add(panel);

            Button button = panel.GetComponentInChildren<Button>();

            if (upgrade.CompareTag("AutoFireGun"))
            {
                button.onClick.AddListener(UpgradeSystem.Instance.AutoFireWeapon);
            }
            else if (upgrade.CompareTag("HealthUpgrade"))
            {
                button.onClick.AddListener(UpgradeSystem.Instance.HealthUpgrade);
            }
        }
    }

    public void DestroyUpgrades()
    {
        foreach (GameObject panel in spawnedUpgrades)
        {
            Destroy(panel);
        }

        spawnedUpgrades.Clear();
    }
}