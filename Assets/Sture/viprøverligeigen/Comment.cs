using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class Comment : MonoBehaviour
{
    //Kommentartekst & Profilbillede
    public string customText;
    public Sprite commentImage;
    public GameObject avatarPicture;
    public TMP_InputField Inputfield;
    private string imageName;
    
    //Like System
    public TMP_Text likeText;

    private int likeAmount = 0;
    private DateTime lastLikeTime = DateTime.MinValue;
    
    //Reply
    public GameObject ReplyPrefab;

    void Start()
    {
        imageName = commentImage.name.Split('.')[0];
        imageName = char.ToUpper(imageName[0]) + imageName.Substring(1);

        avatarPicture.GetComponent<Image>().sprite = commentImage;
            
        Inputfield.text = "<color=#6A6A6A><size=25>Anonymous " + imageName + "</size></color>\n" + customText + "\n";
        Inputfield.readOnly = true;
    }

    public bool CanLike()
    {
        TimeSpan timeSinceLastLike = DateTime.Now - lastLikeTime;
        return timeSinceLastLike.TotalMinutes >= 2;
    }

    public void OnLikeButtonClick()
    {
        if (CanLike())
        {
            likeAmount += 1;
            lastLikeTime = DateTime.Now;
            UpdateLikeText();
        }
    }

    private void UpdateLikeText()
    {
        if (likeText != null)
        {
            likeText.text = likeAmount.ToString();
        }
    }
    
    public void CreateReply()
    {
        GameObject replyPrefab = Instantiate(ReplyPrefab);
        replyPrefab.transform.SetParent(transform, false);

        // Force a layout update to ensure the ContentSizeFitter has calculated the size
        LayoutRebuilder.ForceRebuildLayoutImmediate(replyPrefab.GetComponent<RectTransform>());

        // Capture the initial position
        Vector3 initialPosition = replyPrefab.transform.position;

        // Adjust the y position to be below the initial position
        float yOffset = -180f; // Adjust this value based on your needs
        replyPrefab.transform.position = new Vector3(initialPosition.x, initialPosition.y + yOffset, initialPosition.z);

        replyPrefab.SetActive(true);
    }
}

