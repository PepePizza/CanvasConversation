using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Emojis : MonoBehaviour
{
    public GameObject emojisCanvas;
    
    public GameObject emoji;
    //public GameObject laughter;
    //public GameObject surprise;
    //public GameObject sadness;
    //public GameObject anger;

    public GameObject forum;
    //public GameObject laughterForum;
    //public GameObject surprisedForum;
    //public GameObject sadnessForum;
    //public GameObject angerForum;

    
    public Button BackButton;

    // Start is called before the first frame update
    void Start()
    {
        //emojisCanvas.SetActive(false);
    }
    
    
    public void OnMouseUpAsButton()
    {
        forum.SetActive(true);
    
        emojisCanvas.SetActive(false);
    }

    public void OnBackButtonClick()
    {
        if (BackButton != null)
        {
            //bool isActive = forum.activeSelf;
            //forum.SetActive(!isActive);
            forum.SetActive(false);

            emojisCanvas.SetActive(true);

        }
    }
}
