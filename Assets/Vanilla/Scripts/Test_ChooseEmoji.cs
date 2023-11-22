using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class Test_ChooseEmoji : MonoBehaviour
{
    
    private Test_SpawnEmojis spawnEmojisScript;

    //public CanvasGroup canvasGroup;
    public GameObject emojisSelectorCanvas;
    
    private ARTrackedImage currentTrackedImage;

    private Button buttonComponent;

    public static string buttontag;

    private void Awake()
    {
        spawnEmojisScript = GetComponent<Test_SpawnEmojis>();
    }

    private void Update()
    {
        currentTrackedImage = spawnEmojisScript.CurrentlyTrackedImage;
    }
    
    /*public void OnPointerClick (PointerEventData eventData)
    {
        // Get the tag of the clicked button's GameObject
        buttontag = eventData.pointerPress.tag;
        emojisSelectorCanvas.SetActive(false);
        spawnEmojisScript.react_to_current_image();
    }*/

    public void onClicked(Button button)
    {
        buttontag = button.name;
        emojisSelectorCanvas.SetActive(false);
        spawnEmojisScript.react_to_current_image();
    }
}


