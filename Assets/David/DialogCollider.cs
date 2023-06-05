using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogCollider : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Someone entered");
        if (other.CompareTag("Player"))
        {
            // fade out the dialog panel
            FadeDialogWindow.Instance.toggleFade(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Someone exited");
        if (other.CompareTag("Player"))
        {
            // fade in the dialog panel
            FadeDialogWindow.Instance.toggleFade(false);
        }
    }
}
