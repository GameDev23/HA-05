using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("GameMusic");
        if (musicObject.Length > 1)
        {
            Debug.Log("Destroyed one AUDIOMANAGER");
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);
    }
}
