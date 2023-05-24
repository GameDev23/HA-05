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

    [SerializeField] private float DestroyAnimationScaling = 1f;

    [SerializeField] private float nextProjectileDelay = 2f;
    [SerializeField] private float minDelay = 0.5f;
    [SerializeField] private float maxDelay = 5f;
    
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
            Destroy(gameObject);
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
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Health -= 1;
        }
    }
}
