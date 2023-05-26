using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class BossScript : MonoBehaviour
{
    [SerializeField] private int Health = 1;

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject DestroyAnimation;
    [SerializeField] private GameObject LaserBuilder;

    [SerializeField] private float DestroyAnimationScaling = 1f;

    [SerializeField] private float nextProjectileDelay = 2f;
    [SerializeField] private float minDelay = 0.5f;
    [SerializeField] private float maxDelay = 5f;
    [SerializeField] private int minLaser = 5;
    [SerializeField] private int maxLaser = 20;
    [SerializeField] private float laserDelay = 0.1f;
    
    private int LaserCount = 0;
    private bool isLaser = false;
    
    
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

        LaserCount = Random.Range(minLaser, maxLaser + 1);
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
            LaserCount = Random.Range(minLaser, maxLaser + 1);
            StartCoroutine(fireLaser());
            nextProjectileDelay = Random.Range(minDelay, maxDelay);
        }

        

        if(!isLaser)
            nextProjectileDelay -= Time.deltaTime;
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile") || other.gameObject.CompareTag("Player"))
        {
            Manager.Instance.showDamageNumber(transform.position);
            Health -= 1;
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

    IEnumerator fireLaser()
    {
        isLaser = true;
        Debug.Log("Now playing shoot sound of Beam");
        LaserBuilder.SetActive(true);
        AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.BossBeam, 2f);
        yield return new WaitForSeconds(2f);
        LaserBuilder.SetActive(false);
        while (LaserCount > 0)
        {
            GameObject pro1 = Instantiate(projectile);
            GameObject pro2 = Instantiate(projectile);
            pro1.transform.position = transform.position + Vector3.left * 0.8f + Vector3.up * 0.3f;
            pro2.transform.position = transform.position + Vector3.left * 0.8f - Vector3.up * 0.3f;
            LaserCount--;
            yield return new WaitForSeconds(laserDelay);
        }
        

        isLaser = false;
    }
    

}
   