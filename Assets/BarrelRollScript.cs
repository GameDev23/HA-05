using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelRollScript : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    [SerializeField] private Rigidbody2D playerRigidbody2D;
    [SerializeField] private BoxCollider2D playerBoxCollider;

    private bool isRolling = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if(!isRolling && (Manager.Instance.cooldownBarrelRoll <= 0))
                doBarrelRoll();
        }


    }

    void doBarrelRoll()
    {
        isRolling = true;
        StartCoroutine(BarrelRoll());
    }

    IEnumerator BarrelRoll()
    {
        //does the barrel roll
        playerBoxCollider.enabled = false;
        for(int i = 0; i < 720; i++)
        {
            Player.transform.Rotate(Vector3.up, 0.5f);
            yield return new WaitForSeconds(0.001f);
        }

        
        Manager.Instance.cooldownBarrelRoll = Manager.Instance.CooldownBarrelRoll;
        playerBoxCollider.enabled = true;
        isRolling = false;
        yield return null;
    }
}
