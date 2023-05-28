using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource SourceBGM;
    public AudioSource SourceSFX;
    public AudioSource SourceSFXEcho;
    public AudioMixer mixer;
    
    public AudioClip CorneriaTheme;
    public AudioClip BossBeam;
    public AudioClip GodModeMusic;
    public AudioClip Snort;
    public AudioClip LetMeDoItForYou;
    public AudioClip Quaso;
    public List<AudioClip> DavidDialog;
    public List<AudioClip> MarvinDialog;
    public List<AudioClip> SamwelDialog;

    //DECLARE GLOBAL AUDIO VARIABLES HERE
    #region VARIABLE DECLARATION

    

    #endregion
    //
    private void Awake()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        //SourceBGM.clip = CorneriaTheme;
        //SourceBGM.Play();
        SourceBGM.volume = 0.4f;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
