using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamwelBossBeam : MonoBehaviour
{
    [SerializeField] private float xSpeed = 10f;
    [SerializeField] private float ySpeed;
    [SerializeField] private float SwitchTime = 0.4f;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] AudioClip HitSound;
    [SerializeField] private bool isChild = false;

    private Rigidbody2D rg;
    private float elapsedTime;

    // Start is called before the first frame update
    void Start()
    {
        if (isChild)
        {
            ySpeed = 10f;
            rg = gameObject.GetComponent<Rigidbody2D>();
            rg.velocity = new Vector2(xSpeed, ySpeed);
        }

        else
        {
            ySpeed = 0f;
            rg = gameObject.GetComponent<Rigidbody2D>();
            rg.velocity = new Vector2(xSpeed, ySpeed);
            AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.Zap, 1f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
