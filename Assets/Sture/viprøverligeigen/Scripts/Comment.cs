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
    
    //Personligt profilbillede
    public Sprite pAvatar;
    
    //Like System
    public TMP_Text likeText;
    
    //Top comment like
    public Button topLikeButton;
    private int toplikeAmount = 12;
    public TMP_Text numberofTopLikes;

    private int likeAmount = 0;
    private DateTime lastLikeTime = DateTime.MinValue;
    
    //Reply
    public GameObject ReplyPrefab,ReplyBox;
    public Transform contentPane;
    public TMP_InputField ReplyField;

    void Start()
    {
        if (gameObject.name == "Reply(Clone)")
        {
            commentImage = pAvatar;
            imageName = commentImage.name.Split('.')[0];
            imageName = char.ToUpper(imageName[0]) + imageName.Substring(1);
        }

        imageName = commentImage.name.Split('.')[0];
        imageName = char.ToUpper(imageName[0]) + imageName.Substring(1);
        
        avatarPicture.GetComponent<Image>().sprite = commentImage;
            
        Inputfield.text = "<color=#6A6A6A><size=25>Anonymous " + imageName + "</size></color>\n" + customText + "\n";
        Inputfield.readOnly = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (gameObject.name == "Reply(Clone)")
            {
                Debug.Log("test reply");
                customText = ReplyField.text;
                ReplyBox.SetActive(false);
            
                RectTransform uitransform = gameObject.GetComponent<RectTransform>();
                uitransform.anchorMin = new Vector2(1, 1);
                uitransform.anchorMax = new Vector2(1, 1);
                uitransform.pivot = new Vector2(1, 1);
            
                Canvas.ForceUpdateCanvases();
            }
        }
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
        replyPrefab.transform.SetParent(contentPane, false);

        LayoutRebuilder.ForceRebuildLayoutImmediate(replyPrefab.GetComponent<RectTransform>());
        
        int indexnumber = transform.GetSiblingIndex();
        print(indexnumber);
        replyPrefab.transform.SetSiblingIndex(indexnumber + 1);

        replyPrefab.SetActive(true);
    }
    
    public void OnTopLikeButtonClick()
    {
        if (numberofTopLikes != null)
        {
            if (toplikeAmount == 12)
            {
                toplikeAmount += 1;
            }
            else
            {
                toplikeAmount -= 1;
            }
            
            numberofTopLikes.text = toplikeAmount.ToString();
        }
    }
}

