using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lightning : MonoBehaviour
{
    [SerializeField] private AudioClip Zap;
    [SerializeField] private bool shouldFollow = false;
    [SerializeField] private float DestroyAfterSeconds = 5f;
    GameObject PlayerObject;
    private Transform lightníngTransform;

    private float elapsedTime = 0f;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SourceSFX.PlayOneShot(Zap, 1.5f);
        PlayerObject = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= DestroyAfterSeconds)
            Destroy(gameObject);
        elapsedTime += Time.deltaTime;


        if (PlayerObject != null)
        { 
            transform.position = PlayerObject.transform.position + (Vector3.right * 4.8f) + (Vector3.down * 0.325f);
        }
    }
}
