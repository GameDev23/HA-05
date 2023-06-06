using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int Health = 1;

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject DestroyAnimation;
    [SerializeField] private GameObject DestroyParticle;

    [SerializeField] private float DestroyAnimationScaling = 1f;

    [SerializeField] private float nextProjectileDelay = 2f;
    [SerializeField] private float minDelay = 0.5f;
    [SerializeField] private float maxDelay = 5f;
    [SerializeField] private bool isReflector = false;
    
    // Start is called before the first frame update
    void Start()
    {
        if (maxDelay < 3f)
        {
            nextProjectileDelay = Random.Range(2f, 5f);
        }
        else
        {
            nextProjectileDelay = Random.Range(2f, maxDelay);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            //Do explosion

            Manager.Instance.PlayerScore += 1;
            GameObject explosion = Instantiate(DestroyAnimation);
            explosion.transform.localScale += Vector3.one * DestroyAnimationScaling;
            explosion.transform.position = transform.position;
            
            GameObject particle = Instantiate(DestroyParticle);
            particle.transform.position = transform.position;
            Destroy(gameObject);
            //Show dialog
            Manager.Instance.ShouldShowDialog = true;
        }

        if (nextProjectileDelay <= 0)
        {
            nextProjectileDelay = Random.Range(minDelay, maxDelay);
            GameObject pro = Instantiate(projectile);
            pro.transform.position = transform.position + Vector3.left * 0.5f;
        }
        nextProjectileDelay -= Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile") || other.gameObject.CompareTag("Player"))
        {
            Health -= 1;
            if (other.gameObject.CompareTag("PlayerProjectile") && !gameObject.CompareTag("Enemy") && isReflector)
            {
                if (other.gameObject.name.Contains("glowCircle") || other.gameObject.name.Contains("Lightning"))
                    return;
                Debug.Log("Other: " + other.gameObject.tag + "  " + other.gameObject.name + " this: " + gameObject.tag+ "  " + gameObject.name);
                GameObject reflectedProjectile = Instantiate(projectile);
                AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.Reflector, 3f);
                reflectedProjectile.transform.position = other.transform.position;
                return;
            }
            Manager.Instance.showDamageNumber(transform.position);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Manager.Instance.showDamageNumber(transform.position);
            Health -= 1;

        }
    }
}
