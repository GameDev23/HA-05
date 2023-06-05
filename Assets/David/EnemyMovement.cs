using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private bool Vertical = false;
    [SerializeField] private bool Horizontal = false;
    [SerializeField] private bool Sinus = false;
    [SerializeField] private bool Cosinus = false;

    [SerializeField] private float SpeedVertical;
    [SerializeField] private float SpeedHorizontal;
    [SerializeField] private float SpeedSinus;
    [SerializeField] private float SpeedCosinus;

    [SerializeField] private float timeVertical;
    [SerializeField] private float timeHorizontal;
    [SerializeField] private float timeSinus;
    [SerializeField] private float timeCosinus;
    [SerializeField] private bool DebugTest;

    private float elapsedTimeVertical = 0f;
    private float elapsedTimeHorizontal = 0f;
    private float elapsedTimeSinus = 0f;
    private float elapsedTimeCosinus = 0f;

    public float radius = 1f;
    public float speed = 2f;

    private float angle;
    private Vector3 center;
    private Vector3 startPosition;

    private Rigidbody2D rg;

    // Start is called before the first frame update
    void Start()
    {
        rg = gameObject.GetComponent<Rigidbody2D>();
        rg.velocity = CalculateVelocity(); // Anfangsgeschwindigkeit setzen
        center = transform.position;
        startPosition = transform.position;
        if (DebugTest)
        {
            elapsedTimeVertical = timeVertical / 2;
        }
    }

    private void FixedUpdate()
    {
        rg.velocity = fieldsToVector();


        //adjust time

        if (elapsedTimeVertical >= timeVertical)
        {
            SpeedVertical = -1 * (SpeedVertical);
            elapsedTimeVertical = 0f;
        }
        if (elapsedTimeHorizontal >= timeHorizontal)
        {
            SpeedHorizontal = -1 * (SpeedHorizontal);
            elapsedTimeHorizontal = 0f;
        }
        if (elapsedTimeSinus >= timeSinus)
        {
            SpeedSinus = -1 * (SpeedSinus);
            elapsedTimeSinus = 0f;
        }
        if (elapsedTimeCosinus >= timeCosinus)
        {
            SpeedCosinus = -1 * (SpeedCosinus);
            elapsedTimeCosinus = 0f;
        }

        if (Vertical)
            elapsedTimeVertical += Time.deltaTime;
        if (Horizontal)
            elapsedTimeHorizontal += Time.deltaTime;
        if (Sinus)
            elapsedTimeSinus += Time.deltaTime;
        if (Cosinus)
            elapsedTimeCosinus += Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {


    }

    private Vector3 fieldsToVector()
    {
        Vector3 v = new Vector3();
        if (Vertical)
        {
            v += (Vector3.up * Time.deltaTime * SpeedVertical);
        }
        if (Horizontal)
        {
            v += (Vector3.right * Time.deltaTime * SpeedHorizontal);
        }
        if (Sinus)
        {
            // Den Winkel basierend auf der Zeit und Geschwindigkeit ändern
            angle += speed * Time.deltaTime;

            // Neue Position des Objekts berechnen
            float x = Mathf.Cos(angle) * radius;
            float y = Mathf.Sin(angle) * radius;
            Vector3 newPosition = center + new Vector3(x, y, 0f);

            // Die Richtung und Geschwindigkeit der Bewegung aktualisieren
            v += (newPosition - transform.position) / Time.deltaTime;
        }
        if (Cosinus)
        {
            //Implement cosinus movement here
        }

        return v;
    }

    private Vector2 CalculateVelocity()
    {
        // Startposition des Objekts berechnen
        float x = Mathf.Cos(angle) * radius;
        float y = Mathf.Sin(angle) * radius;
        Vector3 startPos = center + new Vector3(x, y, 0f);

        // Geschwindigkeit berechnen
        return (startPos - transform.position) / Time.deltaTime;
    }
}

