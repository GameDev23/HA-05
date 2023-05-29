using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonHoldScript : MonoBehaviour
{
    [SerializeField] private float holdDuration = 1f;

    [SerializeField] private Image image;
    [SerializeField] private SpriteRenderer GlowImage;
    
    [SerializeField] private string name;
    [SerializeField] private float fadeFactor = 1f;


    private bool isPressed = false;
    private static bool isStarted = false;
    private bool isHover = false;

    private float pressedTime = 0f;
    

    private Color color;

    private void Awake()
    {
        isStarted = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        color = GlowImage.color;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed && pressedTime < holdDuration)
            pressedTime += Time.deltaTime;
        else if(pressedTime > 0 && !isStarted )
            pressedTime -= Time.deltaTime;
        image.fillAmount = pressedTime / holdDuration;

        if (image.fillAmount > 0.99f && !isStarted)
        {
            isStarted = true;
            StartCoroutine(startGame());
        }

        if (isHover)
        {
            color.a = color.a >= 1 ? 1 : color.a + Time.deltaTime * fadeFactor;
            GlowImage.color = color;
        }
        else
        {
            color.a = color.a = color.a <= 0 ? 0 : color.a - Time.deltaTime * fadeFactor;
            GlowImage.color = color;
        }

    }
    
    public void OnPointerDown(BaseEventData eventData)
    {
        if(isStarted)
            return;
        isPressed = true;
        PlayerPrefs.SetString("Character", name);
    }
    
    public void OnPointerUp(BaseEventData eventData)
    {
        if(isStarted)
            return;
        isPressed = false;
    }

    public void OnPointerEnter(BaseEventData eventData)
    {
        if(isStarted)
            return;
        isHover = true;
    }    
    public void OnPointerExit(BaseEventData eventData)
    {
        if(isStarted)
            return;
        isHover = false;
    }

    IEnumerator startGame()
    {
        Debug.Log("Start Quaso");
        AudioManager.Instance.SourceSFXEcho.clip = AudioManager.Instance.Quaso;
        AudioManager.Instance.SourceSFXEcho.Play();
        AudioManager.Instance.SourceSFXEcho.volume = 2f;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene("SampleScene");
        yield return null;
    }
}
