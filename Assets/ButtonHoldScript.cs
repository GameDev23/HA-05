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

    private bool isPressed = false;
    private bool isStarted = false;

    private float pressedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
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

    }
    
    public void OnPointerDown(BaseEventData eventData)
    {
        isPressed = true;
    }
    
    public void OnPointerUp(BaseEventData eventData)
    {
        isPressed = false;
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
