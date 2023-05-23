using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamScript : MonoBehaviour
{
    [SerializeField] private float Speed = 10;
    [SerializeField] AudioClip audioClip;
    
    private Rigidbody2D rg;



    // Start is called before the first frame update
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        rg.velocity = new Vector2(10, 0);
        AudioManager.Instance.SourceSFX.PlayOneShot(audioClip, 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("GameBorder"))
        {
            Debug.Log("Destroy Beam");
            Destroy(gameObject);
            
        }

    }
}
