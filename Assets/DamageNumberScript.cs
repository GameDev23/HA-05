using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumberScript : MonoBehaviour
{
    [SerializeField] private float TimeUntilDestroy = 5f;
    [SerializeField] private float AscendSpeed = 1f;

    private float elapsedTime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * Time.deltaTime * AscendSpeed;
        if (TimeUntilDestroy <= elapsedTime)
            Destroy(gameObject);
        elapsedTime += Time.deltaTime;
    }
}
