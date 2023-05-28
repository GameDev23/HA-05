using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class BeamScript : MonoBehaviour
{
    [SerializeField] private float xSpeed = 10;
    [SerializeField] private float ySpeed = 0;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] AudioClip HitSound;
    [SerializeField] private bool isPlayerProjectile;
    
    private Rigidbody2D rg;



    // Start is called before the first frame update
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(xSpeed, ySpeed);
        if(isPlayerProjectile)
        {
            SpriteRenderer img = gameObject.GetComponent<SpriteRenderer>();
            Color temp = Manager.Instance.PickedColor;
            temp.a = 255;
            img.color = temp;
        }
        
        AudioManager.Instance.SourceSFX.PlayOneShot(ShootSound, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameBorder"))
        {
            Destroy(gameObject);
        }else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            //Manager.Instance.showDamageNumber(transform.position);
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
