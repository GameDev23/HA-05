using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeScript : MonoBehaviour
{
    [SerializeField] private Slider VolumeSlider;
    public void OnValueChanged(float volume)
    {
        if(volume > 0)
        {
            Debug.Log("Test " + (Mathf.Log10(volume) * 40));
            AudioManager.Instance.Mixer.SetFloat("MainVol", Mathf.Log10(volume) * 40);
            PlayerPrefs.SetFloat("MainVol", volume);
        }
        else
        {
            AudioManager.Instance.Mixer.SetFloat("MainVol", -80);
            PlayerPrefs.SetFloat("MainVol", -80);
        }

    }

    void Start()
    {
        float savedValue = PlayerPrefs.GetFloat("MainVol", 1f);
        VolumeSlider.value = savedValue;
        AudioManager.Instance.Mixer.SetFloat("MainVol", Mathf.Log10(savedValue) * 40);
        
    }
}
