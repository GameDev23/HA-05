using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] TextMeshProUGUI HighscoreNumberText;

    void Start()
    {
        int Number;


            Number = PlayerPrefs.GetInt("HighscoreNumber", 0);
            HighscoreNumberText.text = "Highscore: " + (Number == 0 ? 0 : Number - 1);







    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartClick()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
