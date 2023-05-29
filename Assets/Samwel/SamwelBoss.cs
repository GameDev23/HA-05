using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SamwelBoss : MonoBehaviour
{
    [SerializeField] int HealthPoint;
    [SerializeField] GameObject Projectile;
    [SerializeField] GameObject DestroyAnimation;
    [SerializeField] GameObject DestroyParticle;
    [SerializeField] float DestroyAnimationScaling;
    [SerializeField] float MinDelay;
    [SerializeField] float MaxDelay;
    private float ElapsedTime;
    private float CurrentDelay;

    // Start is called before the first frame update
    void Start()
    {
        CurrentDelay = Random.Range(MinDelay, MaxDelay);
    }

    // Update is called once per frame
    void Update()
    {
        if (HealthPoint <= 0)
        { 
            //  Destroy and Show Damage
        }

        if (ElapsedTime >= CurrentDelay)
        { 
            //  Shoot Projectile
            CurrentDelay = Random.Range(MinDelay, MaxDelay);
            ElapsedTime = 0;
            GameObject projectile = Instantiate(Projectile);
            projectile.transform.position = transform.position + (Vector3.left * 0.5f); // Chang this if it isn't placeed in the correct position
        }

        ElapsedTime += Time.deltaTime;
    }
}
