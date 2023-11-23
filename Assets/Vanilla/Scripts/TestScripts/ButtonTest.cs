using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class ButtonTest : MonoBehaviour
{

    //public TMP_Text text;
    
    private SpawnEmojis spawnEmojiScript;

    //public CanvasGroup canvasGroup;
    public GameObject emojisSelectorCanvas;

    private ARTrackedImage currentTrackedImage;


    // Start is called before the first frame update
    void Start()
    {
        spawnEmojiScript = GetComponent<SpawnEmojis>();
    }

    // Update is called once per frame
    void Update()
    {
        currentTrackedImage = spawnEmojiScript.CurrentlyTrackedImage;

    }

    public void clickButton(Button button)
    {
        //text.text = spawnEmojiScript.CurrentlyTrackedImage.name;
        spawnEmojiScript.react_to_current_image();
        emojisSelectorCanvas.SetActive(false);
        spawnEmojiScript.OnClick_IncreaseSize(button.name);
    }
}
