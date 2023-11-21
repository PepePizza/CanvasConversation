using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emojis : MonoBehaviour
{
    
    public GameObject emojisCanvas;
    public GameObject forum;

    public Button BackButton;
    
    public void OnMouseUpAsButton()
    {
        forum.SetActive(true);
        emojisCanvas.SetActive(false);
    }

    public void OnBackButtonClick()
    {
        if (BackButton != null)
        {
            forum.SetActive(false);
            emojisCanvas.SetActive(true);
        }
    }
}
