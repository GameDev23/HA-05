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
        Rigid.velocity = Vector3.left;

    }

    // Update is called once per frame
    void Update()
    {
        if (TimeElapsed >= TimeToSplit && isParent && !hasSplit)
        {
            hasSplit = true;
            GameObject child1 = Instantiate(Children);
            GameObject child2 = Instantiate(Children);
            GameObject child3 = Instantiate(Children);
            GameObject child4 = Instantiate(Children);
            GameObject child5 = Instantiate(Children);
            child1.transform.position = transform.position + (Vector3.up * 0.5f);
            child2.transform.position = transform.position + (Vector3.up * 0.25f);
            child3.transform.position = transform.position + (Vector3.left * 0.5f);
            child4.transform.position = transform.position + (Vector3.down * 0.25f);
            child5.transform.position = transform.position + (Vector3.down * 0.5f);

        }

        TimeElapsed += Time.deltaTime;

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
