using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    //The different emoji gameobjects that should increase in size
    public GameObject loving;
    public GameObject laughter;
    public GameObject surprise;
    public GameObject sadness;
    public GameObject anger;

    //The amount the size should increase by
    public float increaseAmount = 50f;
    public float increaseHeartAmount = 25f;
    
    
    //public CanvasGroup canvasGroup;
    public GameObject emojisSelectorCanvas;
    public GameObject emojisCanvas;
    
    public void OnHeartClick()
    {
        IncreaseHeartSize(loving);
        //CloseCanvas();
        emojisSelectorCanvas.SetActive(false);
        emojisCanvas.SetActive(true);
    }

    public void OnLaughingClick()
    {
        IncreaseSize(laughter);
        //CloseCanvas();
        emojisSelectorCanvas.SetActive(false);
        emojisCanvas.SetActive(true);
    }

    public void OnSurprisedClick()
    {
        IncreaseSize(surprise);
        //CloseCanvas();
        emojisSelectorCanvas.SetActive(false);
        emojisCanvas.SetActive(true);
    }

    public void OnSadClick()
    {
        IncreaseSize(sadness);
        //CloseCanvas();
        emojisSelectorCanvas.SetActive(false);
        emojisCanvas.SetActive(true);
    }

    public void OnAngryClick()
    {
        IncreaseSize(anger);
        //CloseCanvas();
        emojisSelectorCanvas.SetActive(false);
        emojisCanvas.SetActive(true);
    }

    void IncreaseSize(GameObject obj)
    {
        Vector3 currentSize = obj.transform.localScale;
        obj.transform.localScale = new Vector3(currentSize.x + increaseAmount, currentSize.y + increaseAmount, currentSize.z + increaseAmount);
    }
    
    void IncreaseHeartSize(GameObject obj)
    {
        Vector3 currentSize = obj.transform.localScale;
        obj.transform.localScale = new Vector3(currentSize.x + increaseHeartAmount, currentSize.y + increaseHeartAmount, currentSize.z + increaseHeartAmount);
    }


    /*void CloseCanvas()
    {
        // Set canvas transparency to fully transparent (invisible).
        canvasGroup.alpha = 0f;
        
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }*/
}
