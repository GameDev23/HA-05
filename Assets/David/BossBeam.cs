using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BossBeam : MonoBehaviour
{
    [SerializeField] private float xSpeed = 10;
    [SerializeField] private float ySpeed = 0;
    [SerializeField] private float SwitchTime = 0.4f;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] AudioClip HitSound;
    
    private Rigidbody2D rg;
    private float elapsedTime = 0f;



    // Start is called before the first frame update
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(xSpeed, ySpeed);
        //AudioManager.Instance.SourceSFX.PlayOneShot(ShootSound, 1f);
    }

    private void FixedUpdate()
    {
        rg.velocity = new Vector2(xSpeed, ySpeed);
    }

    // Update is called once per frame
    void Update()
    {
        if (elapsedTime >= SwitchTime)
        {
            elapsedTime = 0f;
            ySpeed = (-1) * ySpeed;
        }
        else
            elapsedTime += Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameBorder"))
        {
            Destroy(gameObject);
        }else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            AudioManager.Instance.SourceSFX.PlayOneShot(HitSound, 0.6f);
            Destroy(gameObject);
        }else if (other.gameObject.CompareTag("EnemyProjectile") && gameObject.CompareTag("PlayerProjectile"))
        {
            //different projectiles collided
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("PlayerProjectile") && gameObject.CompareTag("EnemyProjectile"))
        {
            //different projectiles collided
            Destroy(gameObject);
        }
        

    }
}
