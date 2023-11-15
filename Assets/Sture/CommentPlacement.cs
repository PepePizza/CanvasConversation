using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CommentPlacement : MonoBehaviour
{
    [SerializeField, TextArea] private string customText;
    [SerializeField] private Sprite commentImage;
    [SerializeField] private TMP_Text commentText;
    [SerializeField] private GameObject avatarPicture;
    [SerializeField] private TMP_InputField test123;
    private string imageName;
    
    [SerializeField] private Transform commentHolder; // Reference to the comment holder in the Inspector
    [SerializeField] private ScrollRect scrollRect;
    
    void Start()
    {
        // Check if the comment holder and ScrollRect are assigned
        if (commentHolder != null && scrollRect != null)
        {
            transform.SetParent(commentHolder);
            transform.localPosition = Vector3.zero;
            
            Canvas.ForceUpdateCanvases();
            scrollRect.normalizedPosition = new Vector2(0, 1);
            
            imageName = commentImage.name.Split('.')[0];
            imageName = char.ToUpper(imageName[0]) + imageName.Substring(1);

            avatarPicture.GetComponent<Image>().sprite = commentImage;
            
            commentText.text = "<color=#6A6A6A><size=25>Anonymous " + imageName + "</size></color>\n" + customText;
            test123.text = commentText.text;
        }
    }
    
    
}


