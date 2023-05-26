using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeapons : MonoBehaviour
{
    [SerializeField] private GameObject Beam;
    [SerializeField] private GameObject SnortCircle;

    [SerializeField] public float CooldownPrimary = 0.5f;
    [SerializeField] public float CooldownSecondary = 5f;
    [SerializeField] public float CooldownDavid = 8f;

    public float cooldownPrimary = 0f;
    public float cooldownSecondary = 0f;
    public float cooldownDavid = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") && cooldownPrimary <= 0)
        {
            //Shoot beam
            GameObject beam = Instantiate(Beam);
            beam.gameObject.transform.position = transform.position + 1f * Vector3.right;
            cooldownPrimary = CooldownPrimary;
        }

        if (Input.GetButton("Fire2") && cooldownSecondary <= 0)
        {
            //Shoot triple beam
            GameObject beam1 = Instantiate(Beam);
            GameObject beam2 = Instantiate(Beam);
            GameObject beam3 = Instantiate(Beam);

            Vector3 pos = transform.position;
            beam1.transform.localScale += new Vector3(1, 1, 1);
            beam1.transform.position = pos + 1f * Vector3.right + 0.5f * Vector3.up;
            
            beam2.transform.position = pos + 1f * Vector3.right;
            beam2.transform.localScale += new Vector3(1, 1, 1);
            
            beam3.transform.position = pos + 1f * Vector3.right + 0.5f * Vector3.down;
            beam3.transform.localScale += new Vector3(1, 1, 1);

            cooldownSecondary = CooldownSecondary;

        }

        if (Input.GetButton("Fire3") && cooldownDavid <= 0)
        {
            GameObject circle = Instantiate(SnortCircle);
            circle.transform.position = transform.position;
            cooldownDavid = CooldownDavid;
        }
        
        //Adjust cooldowns
        float cdSecondary = Manager.toPercent(cooldownSecondary, CooldownSecondary);
        Manager.Instance.TripleShotCooldown.fillAmount = cdSecondary;
        float cdDavid = Manager.toPercent(cooldownDavid, CooldownDavid);
        Manager.Instance.SnortCircleCooldown.fillAmount = cdDavid;
        
        cooldownPrimary -= Time.deltaTime;
        cooldownSecondary -= Time.deltaTime;
        cooldownDavid -= Time.deltaTime;

    }


}
