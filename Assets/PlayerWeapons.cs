using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private GameObject Beam;

    [FormerlySerializedAs("Cooldown1")] [SerializeField] private float CooldownPrimary = 0.5f;

    private float cooldown1 = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && cooldown1 <= 0)
        {
            //Shot beam
            GameObject beam = Instantiate(Beam);
            beam.gameObject.transform.position = transform.position + 1f * Vector3.right;
            cooldown1 = CooldownPrimary;
        }
        
        //Adjust cooldowns
        cooldown1 -= Time.deltaTime;

    }
}
