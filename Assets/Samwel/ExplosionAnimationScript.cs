using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationScript : MonoBehaviour
{
    [SerializeField] float ElapsedTimeToDestroy = 3f;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ElapsedTimeToDestroy <= 0f)
        {
            Debug.Log("DESTROY ANIMATION IS TRIGGERED");
            Destroy(gameObject);
        }

        ElapsedTimeToDestroy -= Time.deltaTime;
    }
}
