using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    
    // Start is called before the first frame update
    void Start()
    {
        //emojisCanvas.SetActive(false);
    }
    
    
    private void OnMouseUpAsButton()
    {
        forum.SetActive(true);
    
        emojisCanvas.SetActive(false);
    }
    
}
