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
    private Camera Cam;
    [SerializeField] bool isBoss;
    private bool OutOfX = false;
    private bool OutOfLowerY = false;
    private bool OutOfUpperY = false;
    private Vector2 Middle;
    private Vector2 LowerY;
    private Vector2 UpperY;

    private void Start()
    {

        Cam = Manager.Instance.MainCamera;
        

        // Generate initial random direction
        GenerateRandomDirection();
        Middle = Cam.ViewportToWorldPoint(new Vector2(0.5f, 0.5f));
        LowerY = Cam.ViewportToWorldPoint(new Vector2(0f, 0.2f));
        UpperY = Cam.ViewportToWorldPoint(new Vector2(0f, 0.8f));
    }

    private void Update()
    {
        // Exceeding the left lower end of the x axis
        if(transform.position.x <= Middle.x)
        {
            GenerateRandomDirection();
            Rigidbody.velocity = randomDirection;
            ChangeMovement = Random.Range(0.7f, 2f);
            OutOfX = true;
            ElapsedTime = 0f;

        }

        // Exceeding the lower end of the y axis
        if (transform.position.y <= LowerY.y)
        {
            GenerateRandomDirection();
            Rigidbody.velocity = randomDirection;
            ChangeMovement = Random.Range(0.7f, 2f);
            OutOfLowerY = true;
            ElapsedTime = 0f;
        }

        // Exceeding the upper end of the y axis
        if (transform.position.y >= UpperY.y) 
        {
            GenerateRandomDirection();
            Rigidbody.velocity = randomDirection;
            ChangeMovement = Random.Range(0.7f, 2f);
            OutOfUpperY = true;
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
            randomDirection *= 10f; // Adjusting the magnitude of the random direction
            OutOfX = false;
            return;
        }

        if (OutOfLowerY) 
        {
            // Generate a random direction vector
            randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, 2f));
            randomDirection.Normalize();
            randomDirection *= 10f; // Adjusting the magnitude of the random direction
            OutOfLowerY = false;
            return;
        }

        if (OutOfUpperY) 
        {
            // Generate a random direction vector
            randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0f, -2f));
            randomDirection.Normalize();
            randomDirection *= 10f; // Adjusting the magnitude of the random direction
            OutOfUpperY = false;
            return;
        }

        // Generate a random direction vector
        randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(-2f, 1f));
        randomDirection.Normalize();
        randomDirection *= 10f; // // Adjusting the magnitude of the random direction
    }
}
