using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamwelBossBeam : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.Zap, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
