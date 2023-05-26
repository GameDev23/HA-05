using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
 public float moveSpeed = 5f;
    private Vector2 randomDirection;
    private float ElapsedTime = 0f;
    private float ChangeMovement = 0f;
    [SerializeField] Rigidbody2D Rigidbody;
    [SerializeField] Camera Cam;
    private Vector2 xmin;
    private Vector2 xmax;
    private bool OutOfX = false;
    private Vector2 Middle;

    private void Start()
    {
        // Generate initial random direction
        GenerateRandomDirection();
        Middle = Cam.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
    }

    private void Update()
    {
        if(transform.position.x <= Middle.x)
        {
            GenerateRandomDirection();
            Rigidbody.velocity = randomDirection;
            ChangeMovement = Random.Range(0.7f, 2f);
            OutOfX = true;
            ElapsedTime = 0f;

        }

        if (ElapsedTime >= ChangeMovement)
        {
            Debug.Log("Changing movement randomly" + randomDirection);
            // Move the object in the random direction
            Rigidbody.velocity = randomDirection;
            ChangeMovement = Random.Range(0f, 2f);
            ElapsedTime = 0f;
            GenerateRandomDirection();
        }  
        ElapsedTime += Time.deltaTime;
    }

    private void GenerateRandomDirection()
    {

        if (OutOfX)
        {
            // Generate a random direction vector
            randomDirection = new Vector2(Random.Range(2f, 1f), Random.Range(2f, 1f));
            randomDirection.Normalize();
            randomDirection *= 10f; // You can adjust the magnitude of the random direction here
            OutOfX = false;
            return;
        }

        // Generate a random direction vector
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        randomDirection.Normalize();
        randomDirection *= 10f; // You can adjust the magnitude of the random direction here
    }
}
