using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Collections.Generic;
using Button = UnityEngine.UIElements.Button;

public class AddComment : MonoBehaviour
{
    public GameObject commentPrefab,commentScreen,commentManager; // Assign your Comment prefab in the Unity Editor
    public Transform parentTransform; // Assign your Comment prefab in the Unity Editor
    public TMP_InputField newCommentText;
    public Sprite Commentavatar;
    public List<Sprite> spriteList = new List<Sprite>();
    public int Avatarselection;
    
public void PostNewComment()
{
    GameObject newCommentObject = Instantiate(commentPrefab);
    
    Comment newCommentScript = newCommentObject.GetComponent<Comment>();
    newCommentObject.transform.SetParent(parentTransform, false);

    if (newCommentScript != null)
    {
        newCommentScript.customText = newCommentText.text;
        //newCommentScript.commentImage = Commentavatar;
        commentScreen.SetActive(false);
        Image imageComponent = commentManager.GetComponent<Image>();
        imageComponent.enabled = false;

    }
    else
    {
        Debug.LogError("Comment component not found on the instantiated GameObject.");
    }
}

public void NewCommentScreen()
{
    commentScreen.SetActive(true);
    Image imageComponent = commentManager.GetComponent<Image>();
    imageComponent.enabled = true;
}

public void AvatarSelection()
{
    Comment newCommentScript = commentPrefab.GetComponent<Comment>();
    newCommentScript.commentImage = spriteList[Avatarselection];
}

public void Avatar1()
{
    Avatarselection = 0;
    AvatarSelection();
}
public void Avatar2()
{
    Avatarselection = 1;
    AvatarSelection();
}
public void Avatar3()
{
    Avatarselection = 2;
    AvatarSelection();
}
public void Avatar4()
{
    Avatarselection = 3;
    AvatarSelection();
}
}



