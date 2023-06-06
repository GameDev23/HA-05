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
    public AudioMixer Mixer;
    
    public AudioClip BGMMenu;
    public AudioClip BGMGame;
    public AudioClip BossBeam;
    public AudioClip GodModeMusic;
    public AudioClip Snort;
    public AudioClip LetMeDoItForYou;
    public AudioClip Quaso;
    public List<AudioClip> DavidDialog;
    public List<AudioClip> MarvinDialog;
    public List<AudioClip> SamwelDialog;
    public AudioClip Zap;
    public AudioClip explosion;
    public AudioClip Applause;
    public AudioClip Reflector;

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
        AudioManager.Instance.SourceBGM.clip = BGMMenu;
        AudioManager.Instance.SourceBGM.volume = 0.4f;
        AudioManager.Instance.SourceBGM.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
