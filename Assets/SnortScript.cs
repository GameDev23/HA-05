using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnortScript : MonoBehaviour
{
    [SerializeField] private AudioClip Snort;
    [SerializeField] private bool shouldGrow = false;
    [SerializeField] private float DestroyAfterSeconds = 5f;

    private float elapsedTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SourceSFX.PlayOneShot(Snort, 3f);
    }

    // Update is called once per frame
    void Update()
    {
        if(shouldGrow)
            transform.localScale += transform.localScale * 1.4f * Time.deltaTime;

        if (elapsedTime >= DestroyAfterSeconds)
            Destroy(gameObject);
        elapsedTime += Time.deltaTime;
    }
}