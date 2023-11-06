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
    public float increaseAmount = 5f;
    
    //
    public CanvasGroup canvasGroup;

    public void OnHeartClick()
    {
        IncreaseSize(loving);
        CloseCanvas();
    }

    public void OnLaughingClick()
    {
        IncreaseSize(laughter);
        CloseCanvas();
    }

    public void OnSurprisedClick()
    {
        IncreaseSize(surprise);
        CloseCanvas();
    }

    public void OnSadClick()
    {
        IncreaseSize(sadness);
        CloseCanvas();
    }

    public void OnAngryClick()
    {
        IncreaseSize(anger);
        CloseCanvas();
    }

    void IncreaseSize(GameObject obj)
    {
        Vector3 currentSize = obj.transform.localScale;
        obj.transform.localScale = new Vector3(currentSize.x + increaseAmount, currentSize.y + increaseAmount, currentSize.z + increaseAmount);
    }

    void CloseCanvas()
    {
        // Set canvas transparency to fully transparent (invisible).
        canvasGroup.alpha = 0f;
        
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }
}
