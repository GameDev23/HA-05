using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager Instance;
    public int PlayerScore = 0;
    public Image TripleShotCooldown;
    public Image SnortCircleCooldown;
    public GameObject Player;
    public GameObject WavePanel;
    public TextMeshProUGUI WaveTextMesh;
    
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

    public static float toPercent(float a, float b)
    {
        if (a < 0)
            return 0;
        return a / b;
    }
}

    