using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSystemUI : MonoBehaviour
{
    [SerializeField] private GameObject[] upgrades;

    private List<GameObject> spawnedUpgrades = new List<GameObject>();

    private List<GameObject> elegibleUpgrades = new List<GameObject>();
    
    private List<GameObject> upgradesToSpawn = new List<GameObject>();

    public static UpgradeSystemUI Instance;

    void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void InstantiateUpgrades()
    {
        elegibleUpgrades.Clear();
        upgradesToSpawn.Clear();
        foreach (GameObject upgrade in upgrades)
        {
            if (upgrade.CompareTag("AutoFireGun") && UpgradeSystem.Instance.hasAutoFireGun)
            {
                continue;
            }

            if (upgrade.CompareTag("OrbUpgrade") && UpgradeSystem.Instance.hasOrbUpgrade)
            {
                continue;
            }
            elegibleUpgrades.Add(upgrade);
        }
        
        Shuffle(elegibleUpgrades);

        int count = Mathf.Min(3, elegibleUpgrades.Count);
        for (var i = 0; i < count; i++)
        {
            upgradesToSpawn.Add(elegibleUpgrades[i]);
        }
        
        foreach (GameObject upgrade in upgradesToSpawn)
        {
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
            else if (upgrade.CompareTag("DamageUpgrade"))
            {
                button.onClick.AddListener(UpgradeSystem.Instance.DamageUpgrade);
            }
            else if (upgrade.CompareTag("SpeedUpgrade"))
            {
                button.onClick.AddListener(UpgradeSystem.Instance.SpeedUpgrade);
            }
            else if (upgrade.CompareTag("HealUpgrade"))
            {
                button.onClick.AddListener(UpgradeSystem.Instance.HealUpgrade);
            }
            else if (upgrade.CompareTag("OrbUpgrade"))
            {
                button.onClick.AddListener(UpgradeSystem.Instance.OrbUpgrade);
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
    
    private static void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }


}
