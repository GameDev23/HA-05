using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationScript : MonoBehaviour
{
    [SerializeField] float ElapsedTimeToDestroy = 3f;


    // Start is called before the first frame update
    void Start()
    {
        AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.explosion, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        if (ElapsedTimeToDestroy <= 0f)
        {
            AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.explosion, 2f);
            Debug.Log("DESTROY ANIMATION IS TRIGGERED");
            Destroy(gameObject);
        }

        ElapsedTimeToDestroy -= Time.deltaTime;
    }
}
