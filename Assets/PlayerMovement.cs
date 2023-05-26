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
    private Rigidbody2D rg;
    
    
    
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
        GameObject destroyAnimation = Instantiate(DestroyAnimation);
        destroyAnimation.transform.position = transform.position;
        
        //Show damage number
        Manager.Instance.showDamageNumber(transform.position);
        
        //TODO put this into IENUMERATOR
        int currentHigh = PlayerPrefs.GetInt("HighscoreNumber", 0);
        if (currentHigh < WaveManager.Instance.waveNumber)
            currentHigh = WaveManager.Instance.waveNumber;
        
        PlayerPrefs.SetInt("HighscoreNumber", currentHigh);
        SceneManager.LoadScene("Menu");
        Destroy(gameObject);
    }
}
