using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnortScript : MonoBehaviour
{
    [SerializeField] private AudioClip Snort;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SourceSFX.PlayOneShot(Snort, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += transform.localScale * 1.4f * Time.deltaTime;
    }
}
