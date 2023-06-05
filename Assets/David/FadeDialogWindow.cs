using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeDialogWindow : MonoBehaviour
{

    [SerializeField] [Range(0, 1)] private float FadeFactor = 0.5f;
    public static FadeDialogWindow Instance;
    
    private static bool isFaded = false;
    private static Image[] imgList;
    
    // Start is called before the first frame update
    void Start()
    {

        // create singleton
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);
        
        imgList = GetComponentsInChildren<Image>();
        
    }

    // Update is called once per frame
    void Update()
    {

    }


    public  void toggleFade(bool shouldFade)
    {
        //fade the dialog panel if player is infront of it
        if (!shouldFade)
        {
            
            isFaded = false;
            foreach (Image img in imgList)
            {
                Color color = img.color;
                color.a = 1;
                img.color = color;
            }

            
        }
        else
        {
            isFaded = true;
            foreach (Image img in imgList)
            {
                Color color = img.color;
                color.a = FadeFactor;
                img.color = color;
            }
        }
    }
}
