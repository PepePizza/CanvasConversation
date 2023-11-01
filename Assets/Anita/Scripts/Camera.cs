using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    private static WebCamTexture backcam;
    // Start is called before the first frame update
    void Start()
    {
        if (backcam == null)
            backcam = new WebCamTexture();

        GetComponent<Renderer>().material.mainTexture = backcam;
        
        if (!backcam.isPlaying)
            backcam.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
