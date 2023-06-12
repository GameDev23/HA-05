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

    private Vector3 topup = (Vector3.left + Vector3.up);
    private Vector3 topupdown = Vector3.left + Vector3.down;
    private Vector3 middleup = Vector3.left * 0.8f + Vector3.down * 3.5f;
    private Vector3 middledown = Vector3.left * 0.8f + Vector3.down * 3.3f;
    private Vector3 downup = (Vector3.left + Vector3.up * 3.5f);
    private Vector3 downdown = (Vector3.left + Vector3.up * 3.3f);
    private Vector3 backup = (Vector3.left * -0.5f + Vector3.up * 1.5f);
    private Vector3 backdown = (Vector3.left * -0.5f + Vector3.down * 1.5f);





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
        {   //middle canon down
            GameObject susmaster2000000 = Instantiate(projectile);
            susmaster2000000.transform.position = transform.position;
            int Rand = Random.Range(0,8);
            switch (Rand)
            {
                case 0:
                    susmaster2000000.transform.position += topup;
                    
                    break;


                case 1:
                    susmaster2000000.transform.position += topupdown;

                    break;

                case 2:
                    susmaster2000000.transform.position += middleup;

                    break;
                case 3:
                    susmaster2000000.transform.position += middledown;

                    break;
                case 4:
                    susmaster2000000.transform.position += downup;

                    break;
                case 5:
                    susmaster2000000.transform.position += downdown;

                    break;
                case 6:
                    susmaster2000000.transform.position += backup;

                    break;
                case 7:
                    susmaster2000000.transform.position += backdown;

                    break;


            }



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
