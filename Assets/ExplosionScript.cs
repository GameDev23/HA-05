using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionScript : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private AudioClip Explosion;

    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
        AudioManager.Instance.SourceSFX.PlayOneShot(Explosion, 1f);
        Destroy (gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
