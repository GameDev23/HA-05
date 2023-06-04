using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Random = System.Random;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public int PlayerScore = 0;
    public Image TripleShotCooldown;
    public Image SnortCircleCooldown;
    public Image LighningCoolDown;
    public GameObject Player;
    public GameObject WavePanel;
    public TextMeshProUGUI WaveTextMesh;
    public GameObject DamageNumberPrefab;
    public GameObject GodModePanel;
    public GameObject audioManager;
    public TextMeshProUGUI GodModeText;
    public AudioClip BGMMenu;
    public AudioClip BGMGame;
    
    public TextMeshProUGUI DialogTextMesh;
    public GameObject DialogPanel;
    public Image DialogPanelImage;
    public Image DialogCharacterImage;
    public Image DialogCircleImage;
    public List<String> DialogesDavid = new List<string>();
    public List<String> DialogesMarvin = new List<string>();
    public List<String> DialogesSamwel = new List<string>();

    public Sprite DavidCharacterImage;
    public Sprite MarvinCharacterImage;
    public Sprite SamwelCharacterImage;

    public Color32 DavidColor = new Color32(126, 131, 255, 255);
    public Color32 MarvinColor =new Color32(72, 183, 144, 255);
    public Color32 SamwelColor = new Color32(255, 144, 20, 255);
    public Color32 PickedColor = new Color32(126, 131, 255, 255);

    public float CooldownPrimary = 0.5f;
    public float CooldownSecondary = 5f;
    public float CooldownDavid = 8f;
    public float CooldownSamwel = 8f;

    public float cooldownPrimary = 0f;
    public float cooldownSecondary = 0f;
    public float cooldownDavid = 0f;
    public float cooldownSamwel = 0f;

    public bool ShouldShowDialog = false;
    public bool isGodmode = false;
    public bool isMenu = true;
    private bool showingDialog = false;
    private int lastIndex = 0;
    
    private float godmodePanelWidth;
    String character = "David";

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
        
        //init player dialog window
        String character = PlayerPrefs.GetString("Character", this.character);
        
        Color32 charColor;
        Sprite img;
        switch (character)
        {
            case "David":
                charColor = DavidColor;
                img = DavidCharacterImage;
                break;
            case "Marvin":
                charColor = MarvinColor;
                img = MarvinCharacterImage;
                break;
            case "Samwel":
                charColor = SamwelColor;
                img = SamwelCharacterImage;
                break;
            default:
                charColor = DavidColor;
                img = DavidCharacterImage;
                break;
        }
        Debug.Log("Char: " + character + " and color of: " + charColor);
        PickedColor = charColor;
        Color temp = charColor;
        temp.a = 255;
        DialogCharacterImage.sprite = img;
        DialogCircleImage.color = temp;
        DialogTextMesh.color = temp;
        DialogPanelImage.color = temp;
        RectTransform rect = ((RectTransform)GodModePanel.transform);
        godmodePanelWidth = rect.rect.width;
        // fade panel in
        rect.sizeDelta = new Vector2(-2000, -1000);
        
        //init sound
        if (AudioManager.Instance.SourceBGM.clip != AudioManager.Instance.BGMGame)
            AudioManager.Instance.SourceBGM.clip = AudioManager.Instance.BGMGame;
        

        AudioManager.Instance.SourceBGM.Play();
    }

    // Update is called once per frame
    void Update()
    {

        //Adjust cooldowns
        float cdSecondary = toPercent(cooldownSecondary, CooldownSecondary);
        TripleShotCooldown.fillAmount = cdSecondary;
        float cdDavid = toPercent(cooldownDavid, CooldownDavid);
        SnortCircleCooldown.fillAmount = cdDavid;
        float cdSamwel = toPercent(cooldownSamwel, CooldownSamwel);
        LighningCoolDown.fillAmount = cdSamwel;
        if(ShouldShowDialog && !showingDialog)
            startDialog();
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
        number.transform.position += new Vector3(1, 0, 0) * UnityEngine.Random.Range(-0.3f, 0.3f);
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

    public void startDialog()
    {
        showingDialog = true;
        StartCoroutine(Dialog());

    }

    public void toggleGodmode()
    {
        if (isGodmode)
        {
            //hide panel here
            StartCoroutine(toggleGMod(isGodmode));
        }
        else
        {
            //show panel here
            StartCoroutine(toggleGMod(isGodmode));
        }
        //toggle godmode
        isGodmode = !isGodmode;
    }

    IEnumerator Dialog()
    {
        
        RectTransform rect = ((RectTransform)DialogPanel.transform);
        // fade panel in
        while ((rect.rect.width <= 750))
        {
            rect.sizeDelta += new Vector2(1000 * Time.deltaTime, 0);
            yield return null;
        }

        character = PlayerPrefs.GetString("Character", "David");
        
        //init character specific things
        List<String> charDialogs = new List<string>();
        List<AudioClip> DialogClips = new List<AudioClip>();
        switch (character)
        {
            case "David":
                charDialogs = DialogesDavid;
                DialogClips = AudioManager.Instance.DavidDialog;
                break;
            case "Marvin":
                charDialogs = DialogesMarvin;
                DialogClips = AudioManager.Instance.MarvinDialog;
                break;
            case "Samwel":
                charDialogs = DialogesSamwel;
                DialogClips = AudioManager.Instance.SamwelDialog;
                break;
            
            default:
                charDialogs = DialogesDavid;
                DialogClips = AudioManager.Instance.DavidDialog;
                break;
        }
        
        Debug.Log("DIALOG: " + character + " and array of: " + charDialogs);
        
        // get random prompt and type it to panel
        if(charDialogs.Count > 0)
        {
            
            // get random voiceline
            if (DialogClips.Count > 0)
            {
                int rand = 0;
                //try to get voiceline which is not played before
                for (int i = 0; i < 10; i++)
                {
                    Debug.Log("INSIDE OF RAND FUNCTION with parameters " + 0 + "  " + DialogClips.Count);
                    rand = UnityEngine.Random.Range(0, DialogClips.Count);
                    if (rand != lastIndex)
                    {
                        lastIndex = rand;
                        break;
                    }
                }
                Debug.Log("Using Rand: " + rand);
                AudioManager.Instance.SourceSFX.PlayOneShot(DialogClips[rand]);
            }
            // get random prompt
            String text = "";
            if(charDialogs.Count > 0)
            {
                int index = UnityEngine.Random.Range(0, charDialogs.Count);
                text = charDialogs[index];
                text = text.Replace("\\n", "\n");
            }
            

            foreach (char let in text)
            {
                DialogTextMesh.text += let;
                yield return new WaitForSeconds(0.03f);
            }
            // reset dialog text after a second
            yield return new WaitForSeconds(1f);
            DialogTextMesh.text = "";
            // fade panel out
            while ((rect.rect.width > 0))
            {
                rect.sizeDelta -= new Vector2(1000 * Time.deltaTime, 0);
                yield return null;
            }
        }

        ShouldShowDialog = false;
        showingDialog = false;
    }

    IEnumerator toggleGMod(bool shouldHide)
    {
        RectTransform rect = (RectTransform) GodModePanel.transform;
        if (shouldHide)
        {
            // hide godmode text
            while (GodModeText.text != "")
            {
                String curStr = GodModeText.text;
                List<String> arr = curStr.Split(new char[] {}).ToList();
                arr.RemoveAt(arr.Count - 1);
                GodModeText.text = string.Join("", arr);
                yield return new WaitForSeconds(0.01f);
            }
            // fade panel in
            while ((rect.rect.width > 0))
            {
                rect.sizeDelta -= new Vector2(1000 * Time.deltaTime, 0);
                yield return null;
            }
        }
        else
        {
            // fade panel in
            while ((rect.rect.width <= godmodePanelWidth))
            {
                rect.sizeDelta += new Vector2(1000 * Time.deltaTime, 0);
                yield return null;
            }
            // show godmode text
            foreach (char let in "Godmode")
            {
                GodModeText.text += let;
                yield return new WaitForSeconds(0.01f);
            }
        }

        yield return null;
    }
}
    

    