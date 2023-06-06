using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerWeapons : MonoBehaviour
{
    // David
    [SerializeField] private GameObject Beam;
    [SerializeField] private GameObject SnortCircle;

    //  Samwel
    [SerializeField] private GameObject Lightning;
    
    [SerializeField] public float CoolddownSamwel = 8f;
    
    public float cooldownSamwel= 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!Manager.Instance.isPause)
        {
            if (Input.GetButton("Fire1") && Manager.Instance.cooldownPrimary <= 0)
            {
                //Shoot beam
                GameObject beam = Instantiate(Beam);
                beam.gameObject.transform.position = transform.position + 1f * Vector3.right;
                //increase beam size corresponding to upgraded size
                if(UpgradeManager.Instance.ProjectileSize > 1)
                    beam.gameObject.transform.localScale += new Vector3(1, 0.3f, 0) * UpgradeManager.Instance.ProjectileSize;
                Manager.Instance.cooldownPrimary = Manager.Instance.CooldownPrimary * (1f / UpgradeManager.Instance.PrimaryFireMultiplier);
            }

            if (Input.GetButton("Fire2") && Manager.Instance.cooldownSecondary <= 0)
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

            Manager.Instance.cooldownSecondary = Manager.Instance.CooldownSecondary;

        }

        if (Input.GetButton("Fire3") && Manager.Instance.cooldownDavid <= 0)
        {
            GameObject circle = Instantiate(SnortCircle);
            circle.transform.position = transform.position;
            Manager.Instance.cooldownDavid = Manager.Instance.CooldownDavid;
        }

        if (Input.GetButton("Fire4") && Manager.Instance.cooldownSamwel <= 0)
        {
            //GameObject lightning = Instantiate(Lightning);
            StartCoroutine(shockSamwel());
            Manager.Instance.cooldownSamwel = Manager.Instance.CooldownSamwel;
        }

        //Adjust cooldowns
        float cdSecondary = Manager.toPercent(Manager.Instance.cooldownSecondary, Manager.Instance.CooldownSecondary);
        Manager.Instance.TripleShotCooldown.fillAmount = cdSecondary;
        float cdDavid = Manager.toPercent(Manager.Instance.cooldownDavid, Manager.Instance.CooldownDavid);
        Manager.Instance.SnortCircleCooldown.fillAmount = cdDavid;
        
        Manager.Instance.cooldownPrimary -= Time.deltaTime;
        Manager.Instance.cooldownSecondary -= Time.deltaTime;
        Manager.Instance.cooldownDavid -= Time.deltaTime;
        Manager.Instance.cooldownSamwel -= Time.deltaTime;


    }

    IEnumerator shockSamwel()
    {
        for (int i = 0; i < 5; i++)
        {
            GameObject lightning = Instantiate(Lightning);
            yield return new WaitForSeconds(1f);
        }
        yield return null;
    }


}
