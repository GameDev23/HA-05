using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private int Health = 1;

    [SerializeField] private GameObject projectile;
    [SerializeField] private GameObject DestroyAnimation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            //Do explosion

            Manager.Instance.PlayerScore += 1;
            GameObject explosion = Instantiate(DestroyAnimation);
            explosion.transform.position = transform.position;
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PlayerProjectile"))
        {
            Health -= 1;
        }
    }
}
