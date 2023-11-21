using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddComment : MonoBehaviour
{
    public GameObject commentPrefab,commentScreen,commentManager;
    public Transform parentTransform;
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



