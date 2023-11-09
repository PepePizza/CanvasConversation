using UnityEngine;
using TMPro;
using System;

public class LikeSystem : MonoBehaviour
{
    public TMP_Text likeText;

    private int likeAmount = 0;
    private DateTime lastLikeTime = DateTime.MinValue;

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