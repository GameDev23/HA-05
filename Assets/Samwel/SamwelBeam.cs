using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SamwelBeam : MonoBehaviour
{
    [SerializeField] bool isParent = false;
    [SerializeField] GameObject Parent;
    [SerializeField] GameObject Children;
    [SerializeField] float TimeToSplit = 1f;
    [SerializeField] private float xSpeed = 10f;
    [SerializeField] private float ySpeed;
    [SerializeField] AudioClip ShootSound;
    [SerializeField] AudioClip HitSound;
    [SerializeField] float speedUpFactor = 1f;
    [SerializeField][Range(0, 100)] float rotationSpeed;
    private float TimeElapsed = 0f;
    private Rigidbody2D Rigid;
    private bool hasSplit = false;

    // Start is called before the first frame update
    void Start()
    {
        TimeElapsed = 0f;
        //GameObject parent = Instantiate(Parent);
        Rigid = GetComponent<Rigidbody2D>();
        // To fly left
        if (isParent)
        {
            Rigid.velocity = Vector3.left;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeElapsed >= TimeToSplit && isParent && !hasSplit)
        {
            hasSplit = true;
            GameObject child1 = Instantiate(Children);
            Rigidbody2D rb1 = child1.GetComponent<Rigidbody2D>();
            GameObject child2 = Instantiate(Children);
            Rigidbody2D rb2 = child2.GetComponent<Rigidbody2D>();
            GameObject child3 = Instantiate(Children);
            Rigidbody2D rb3 = child3.GetComponent<Rigidbody2D>();
            GameObject child4 = Instantiate(Children);
            Rigidbody2D rb4 = child4.GetComponent<Rigidbody2D>();
            GameObject child5 = Instantiate(Children);
            Rigidbody2D rb5 = child5.GetComponent<Rigidbody2D>();
            //GameObject child6 = Instantiate(Children);
            //Rigidbody2D rb6 = child6.GetComponent<Rigidbody2D>();
            //GameObject child7 = Instantiate(Children);
            //Rigidbody2D rb7 = child7.GetComponent<Rigidbody2D>();


            child1.transform.position = transform.position + (Vector3.up * 0.6f);
            child1.transform.Rotate(Vector3.back, 45f);
            child2.transform.position = transform.position + (Vector3.up * 0.4f) + (Vector3.left * 0.4f);
            child2.transform.Rotate(Vector3.back, 30f);
            child3.transform.position = transform.position + (Vector3.left * 0.6f);
            child4.transform.position = transform.position + (Vector3.down * 0.4f) + (Vector3.left * 0.4f);
            child4.transform.Rotate(Vector3.back, -30f);
            child5.transform.position = transform.position + (Vector3.down * 0.6f);
            child5.transform.Rotate(Vector3.back, -45f);
            //child6.transform.position = transform.position + (Vector3.up * 0.2f) + (Vector3.left * 0.2f);
            //child6.transform.Rotate(Vector3.back, 15f);
            //child7.transform.position = transform.position + (Vector3.down * 0.2f) + (Vector3.left * 0.2f);
            //child7.transform.Rotate(Vector3.back, -15f);


            rb1.velocity = (Vector3.left + Vector3.up).normalized * speedUpFactor;
            rb2.velocity = (Vector3.left + ((Vector3.up) * 0.5f)).normalized * speedUpFactor;
            rb3.velocity = (Vector3.left) * speedUpFactor;
            rb4.velocity = (Vector3.left + ((Vector3.down) * 0.5f)).normalized * speedUpFactor;
            rb5.velocity = (Vector3.left + Vector3.down).normalized * speedUpFactor;
            //rb6.velocity = (Vector3.left + ((Vector3.up) * 0.5f)).normalized * speedUpFactor;
            //rb7.velocity = (Vector3.left + ((Vector3.down) * 0.5f)).normalized * speedUpFactor;



            if (isParent) 
            {
                Destroy(gameObject);
            }
        }

        TimeElapsed += Time.deltaTime;

        // Making it rotate
        if (isParent)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("GameBorder"))
        {
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy");
            if (gameObject.CompareTag("EnemyProjectile"))
                return; // dont collide with Enemy itself

            //Manager.Instance.showDamageNumber(transform.position);
            // AudioManager.Instance.SourceSFX.PlayOneShot(HitSound, 0.6f); //  After choosing the hitsound and attach it here
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("EnemyProjectile") && gameObject.CompareTag("PlayerProjectile"))
        {
            //different projectiles collided
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("PlayerProjectile") && gameObject.CompareTag("EnemyProjectile"))
        {
            //different projectiles collided
            Destroy(gameObject);
        }
    }
}
