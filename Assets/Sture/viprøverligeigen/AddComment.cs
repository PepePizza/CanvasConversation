using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddComment : MonoBehaviour
{
    public GameObject commentPrefab,commentScreen,commentManager; // Assign your Comment prefab in the Unity Editor
    public Transform parentTransform; // Assign your Comment prefab in the Unity Editor
    public TMP_InputField newCommentText;
    public Sprite UserProfilePicture;

    public void PostNewComment()
{
    GameObject newCommentObject = Instantiate(commentPrefab);
    
    Comment newCommentScript = newCommentObject.GetComponent<Comment>();
    newCommentObject.transform.SetParent(parentTransform, false);

    if (newCommentScript != null)
    {
        newCommentScript.customText = newCommentText.text;
        newCommentScript.commentImage = UserProfilePicture;
        //newCommentScript.commentImage = Commentavatar;
        commentScreen.SetActive(false);
        Image imageComponent = commentManager.GetComponent<Image>();
        imageComponent.enabled = false;
        

    }
}

public void NewCommentScreen()
{
    commentScreen.SetActive(true);
    Image imageComponent = commentManager.GetComponent<Image>();
    imageComponent.enabled = true;
}
}



