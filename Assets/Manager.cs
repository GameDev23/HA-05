using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public int PlayerScore = 0;
    public Image TripleShotCooldown;
    public Image SnortCircleCooldown;
    public GameObject Player;
    public GameObject WavePanel;
    public TextMeshProUGUI WaveTextMesh;
    public GameObject DamageNumberPrefab;
    
    public float CooldownPrimary = 0.5f;
    public float CooldownSecondary = 5f;
    public float CooldownDavid = 8f;

    public float cooldownPrimary = 0f;
    public float cooldownSecondary = 0f;
    public float cooldownDavid = 0f;
    
    //DECLARE GLOBAL SCENE VARIABLES HERE
    #region VARIABLE DECLARATION

    

    #endregion
    //
    
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
        
        //Adjust cooldowns
        float cdSecondary = toPercent(cooldownSecondary, CooldownSecondary);
        TripleShotCooldown.fillAmount = cdSecondary;
        float cdDavid = toPercent(cooldownDavid, CooldownDavid);
        SnortCircleCooldown.fillAmount = cdDavid;
        
        cooldownPrimary -= Time.deltaTime;
        cooldownSecondary -= Time.deltaTime;
        cooldownDavid -= Time.deltaTime;

    }

    public static float toPercent(float a, float b)
    {
        if (a < 0)
            return 0;
        return a / b;
    }

    public void showDamageNumber(Vector2 pos)
    {
        GameObject number = Instantiate(DamageNumberPrefab);
        number.transform.position = pos + Vector2.left + Vector2.up * 0.5f;
    }

    public void backToMenu()
    {
        StartCoroutine(toMenu());
    }

    IEnumerator toMenu()
    {
        AudioSource SourceToFadeOut = AudioManager.Instance.SourceBGM;
        
        for (int i = 0; i < 20; i++)
        {
            SourceToFadeOut.volume *= 0.72f; // gradually decrease volume
            yield return new WaitForSeconds(0.1f);
        }
        //Switch to menu after music faded out
        SceneManager.LoadScene("Menu");
    }
}

    