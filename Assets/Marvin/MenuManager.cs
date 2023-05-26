using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI HighscoreNumberText;
    void Start()
    {
        int Number;

        if (PlayerPrefs.HasKey("HighscoreNumber"))
        {
            Number = PlayerPrefs.GetInt("HighscoreNumber");

        }
        else
            HighscoreNumberText.text = "Highscore: " + 0;






    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
