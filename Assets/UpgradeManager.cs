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
    [SerializeField] private Rigidbody2D Player;
    
    
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
        if (Input.GetKeyDown(KeyCode.Comma))
        {
            ShowUpgradePanel();
        }
    }

    public void ShowUpgradePanel()
    {
        // shows the upgrade panel
        isChoosing = true;
        // make the player invicible during upgrade selection
        Player.simulated = false;
        AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.Applause, 2f);
        UpgradePanel.SetActive(true);
    }

    public void HideUpgradePanel()
    {
        // hides the currently shown panel
        isChoosing = false;
        
        // make the player no longer invicible 
        Player.simulated = true;
        UpgradePanel.SetActive(false);
    }

    public void OnSlotOne()
    {
        Debug.Log("Slot 1");
        
        PrimaryFireMultiplier *= 1.25f;

        HideUpgradePanel();
    } 
    
    public void OnSlotTwo()
    {
        Debug.Log("Slot 2");
        CooldownMultiplier *= 0.8f;
        Manager.Instance.ModifyCooldowns(CooldownMultiplier);
        HideUpgradePanel();
    } 
    
    public void OnSlotThree()
    {
        Debug.Log("Slot 3");
        if(ProjectileSize <= 3)
            ProjectileSize += 0.2f;
        else
        {
            Slot3.SetActive(false);
        }
        HideUpgradePanel();
    }
}
