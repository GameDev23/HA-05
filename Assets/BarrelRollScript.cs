using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRollScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Rigidbody2D playerRigidbody2D;
    [SerializeField] private BoxCollider2D playerBoxCollider;

    private bool isRolling = false;

    private int step = 0;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    private void FixedUpdate()
    {
        if (isRolling)
        {
            Player.transform.Rotate(Vector3.up, 8f);
            step--;
        }

        if (step == 0 && isRolling)
        {
            isRolling = false;
            playerBoxCollider.enabled = true;
            Manager.Instance.cooldownBarrelRoll = Manager.Instance.CooldownBarrelRoll;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!isRolling && (Manager.Instance.cooldownBarrelRoll <= 0))
            {
                doBarrelRoll();
            }
        }


    }

    void doBarrelRoll()
    {
        isRolling = true;
        step = 45;
        playerBoxCollider.enabled = false;
        //StartCoroutine(BarrelRoll());
    }

    IEnumerator BarrelRoll()
    {
        //does the barrel roll
        playerBoxCollider.enabled = false;
        for(int i = 0; i < 720; i++)
        {
            Player.transform.Rotate(Vector3.up, 0.5f);
            yield return new WaitForSeconds(0.0001f);
        }

        
        Manager.Instance.cooldownBarrelRoll = Manager.Instance.CooldownBarrelRoll;
        playerBoxCollider.enabled = true;
        isRolling = false;
        yield return null;
    }
}
