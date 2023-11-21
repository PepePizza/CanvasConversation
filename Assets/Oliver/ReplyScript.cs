using UnityEngine;
using TMPro;
using System;


public class ReplyScript : MonoBehaviour
{
    public GameObject Reply;
    
    public TMP_Text likeText;

    private int likeAmount = 0;
    private DateTime lastLikeTime = DateTime.MinValue;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            TMP_InputField commentInputField = Reply.GetComponentInChildren<TMP_InputField>();
            if (commentInputField != null)
            {
                commentInputField.readOnly = true;
            }
        }
    }

    public void OnReplyButtonClick()
    {
        if (Reply != null)
        {
            bool isActive = Reply.activeSelf;
            Reply.SetActive(!isActive);
        }
    }
    
    public void InitializeLikeCount(int initialLikes)
    {
        likeAmount = initialLikes;
        UpdateLikeText();
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

}
