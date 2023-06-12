using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BossMarvin : MonoBehaviour
{
    [SerializeField] private int Health = 1;

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject DestroyAnimation;
    [SerializeField] private GameObject DestroyParticle;


    [SerializeField] private float DestroyAnimationScaling = 1f;

    [SerializeField] private float nextProjectileDelay = 2f;
    [SerializeField] private float minDelay = 0.5f;
    [SerializeField] private float maxDelay = 5f;
    [SerializeField] private int minLaser = 5;
    [SerializeField] private int maxLaser = 20;
    [SerializeField] private float laserDelay = 0.1f;




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
            //Show dialog
            //Manager.Instance.ShouldShowDialog = true;
            Destroy(gameObject);
        }

        if (nextProjectileDelay <= 0)
        {
            GameObject susmaster2000000 = Instantiate(projectile);
            //set initial pos to boss pos
            susmaster2000000.transform.position = transform.position;
            //adjust pos to the right cannon
            susmaster2000000.transform.position += (Vector3.left + Vector3.up);


            nextProjectileDelay = Random.Range(minDelay, maxDelay);
        }
        nextProjectileDelay -= Time.deltaTime;




    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Debug.Log("Hit Trigger on Boss");
            //Manager.Instance.showDamageNumber(transform.position);
            Health -= 1;
            Manager.Instance.showDamageNumber(transform.position);
            if (Health <= 0)
            {
                Manager.Instance.PlayerScore += 1;
                GameObject explosion = Instantiate(DestroyAnimation);
                explosion.transform.localScale += Vector3.one * DestroyAnimationScaling;
                explosion.transform.position = transform.position;
                GameObject particle = Instantiate(DestroyParticle);
                particle.transform.position = transform.position;
                particle.transform.localScale *= 3;

            }
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Collider on Boss");
            Manager.Instance.showDamageNumber(transform.position);
            Health -= 1;
            if (Health <= 0)
            {
                Manager.Instance.PlayerScore += 1;
                GameObject explosion = Instantiate(DestroyAnimation);
                explosion.transform.localScale += Vector3.one * DestroyAnimationScaling;
                explosion.transform.position = transform.position;
                GameObject particle = Instantiate(DestroyParticle);
                particle.transform.position = transform.position;
                particle.transform.localScale *= 3;
            }
        }
    }




}
