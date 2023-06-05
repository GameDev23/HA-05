using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public static UpgradeManager Instance;

    public float CooldownMultiplier = 1f;
    public float PrimaryFireMultiplier = 1f;
    public float ProjectileSize = 1f;
    public bool isChoosing = false;
    
    

    [SerializeField] private GameObject UpgradePanel;
    [SerializeField] private GameObject Slot1;
    [SerializeField] private GameObject Slot2;
    [SerializeField] private GameObject Slot3;
    [SerializeField] private GameObject Confetti;
    
    
    // Start is called before the first frame update
    void Start()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            ShowUpgradePanel();
        }

        if (Input.GetKeyDown(KeyCode.J))
        {
            HideUpgradePanel();
        }
    }

    public void ShowUpgradePanel()
    {
        // shows the upgrade panel
        isChoosing = true;
        UpgradePanel.SetActive(true);
    }

    public void HideUpgradePanel()
    {
        // hides the currently shown panel
        isChoosing = false;
        UpgradePanel.SetActive(false);
    }

    public void OnSlotOne()
    {
        Debug.Log("Slot 1");
        
        PrimaryFireMultiplier *= 1.15f;

        HideUpgradePanel();
    } 
    
    public void OnSlotTwo()
    {
        Debug.Log("Slot 2");
        CooldownMultiplier += 0.8f;
        Manager.Instance.ModifyCooldowns(CooldownMultiplier);
        HideUpgradePanel();
    } 
    
    public void OnSlotThree()
    {
        Debug.Log("Slot 3");
        ProjectileSize += 0.2f;
        HideUpgradePanel();
    }
}
