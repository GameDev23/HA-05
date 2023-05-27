using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private float xMov;
    private float yMov;

    [SerializeField] private Camera camera;
    [SerializeField] float Speed = 10;
    [SerializeField] private GameObject DestroyAnimation;
    [SerializeField] private GameObject DestroyParticle;
    private Rigidbody2D rg;
    private bool isGodmode = false;
    private float toggleGodmodeCD = 1f;
    private float elapsedTime = 0f;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        
    }

    private void FixedUpdate()
    {
        rg.velocity = rg.velocity * (float) (0.9);
        
        xMov = Input.GetAxis("Horizontal");
        yMov = Input.GetAxis("Vertical");
        Vector3 mov = new Vector3(xMov, yMov, 0);

        if (mov != Vector3.zero)
        {
            rg.AddForce(new Vector2(xMov * Speed, yMov * Speed));
        }
        

        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Enable Debug Button 1"))
        {
            Debug.Log("Toggle Godmode: " + !isGodmode);
            //toggle godmode
            isGodmode = !isGodmode;
            if(isGodmode)
            {
                AudioManager.Instance.SourceSFX.PlayOneShot(AudioManager.Instance.LetMeDoItForYou, 2f);
                //TODO indicate godmode
            }

            
        }
        
    }
    
    public void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collision on Player");
        if (other.gameObject.CompareTag("Enemy"))
        {

            endGame();

        }
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger on Player");
        if (other.gameObject.CompareTag("EnemyProjectile"))
        {
            endGame();
        }
    }

    public void endGame()
    {
        if (isGodmode)
            return;  // dont do any damage calculations in godmode
        
        GameObject destroyAnimation = Instantiate(DestroyAnimation);
        destroyAnimation.transform.position = transform.position;
        
        GameObject particle = Instantiate(DestroyParticle);
        particle.transform.position = transform.position;

        
        //Show damage number
        Manager.Instance.showDamageNumber(transform.position);
        
        int currentHigh = PlayerPrefs.GetInt("HighscoreNumber", 0);
        if (currentHigh < WaveManager.Instance.waveNumber)
            currentHigh = WaveManager.Instance.waveNumber;
        
        PlayerPrefs.SetInt("HighscoreNumber", currentHigh);
        Manager.Instance.backToMenu();
        Destroy(gameObject);
    }
}
