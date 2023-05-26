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
    public AudioMixer mixer;
    
    public AudioClip CorneriaTheme;
    public AudioClip BossBeam;
    public AudioClip Snort;

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

        SourceBGM.clip = CorneriaTheme;
        SourceBGM.Play();
        SourceBGM.volume = 0.5f;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
