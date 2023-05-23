using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public int PlayerScore = 0;
    
    //DECLARE GLOBAL SCENE VARIABLES HERE
    #region VARIABLE DECLARATION

    

    #endregion
    //
    
    // Start is called before the first frame update
    void Start()
    {
        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
