using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ForumManager : MonoBehaviour
{
    public Button addComment;
    public TMP_InputField inputField;
    public Transform commentParent; // Parent transform to hold comments
    public GameObject commentPrefab; // Prefab for comments
    public Transform replyParent; // Parent transform to hold replies
    public GameObject replyPrefab; // Prefab for replies

    private Dictionary<string, int> commentLikes = new Dictionary<string, int>(); // To track likes for each comment

    public Button likeButton;
    public Button replyButton;

    // Start is called before the first frame update
    void Start()
    {
        addComment.onClick.AddListener(AddComment);
        likeButton.onClick.AddListener(OnLike);
        replyButton.onClick.AddListener(AddReply);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnLike()
    {
        string currentComment = inputField.text; // Assuming inputField.text contains the current comment being viewed
        if (!string.IsNullOrEmpty(currentComment))
        {
            if (commentLikes.ContainsKey(currentComment))
            {
                commentLikes[currentComment]++; // Increment likes for the current comment
            }
            else
            {
                commentLikes.Add(currentComment, 1); // If the comment doesn't exist in the dictionary, add it with one like
            }

            DisplayComments(); // Update the UI to display the updated like count for the current comment
        }
    }

    public void AddComment()
    {
        string commentText = inputField.text;
        if (!string.IsNullOrEmpty(commentText))
        {
            // Instantiate comment prefab and set its text
            GameObject newComment = Instantiate(commentPrefab, commentParent);
            newComment.GetComponentInChildren<TextMeshProUGUI>().text = commentText;

            // Adding comment with zero likes initially
            commentLikes.Add(commentText, 0);

            inputField.text = ""; // Clear the input field after adding the comment
            DisplayComments(); // Update the UI to display the added comment
        }
    }

    public void AddReply()
    {
        // Placeholder for adding replies to comments
        // You'd need additional logic to identify the comment being replied to
        // Instantiate reply prefab and set its text
        GameObject newReply = Instantiate(replyPrefab, replyParent);
        newReply.GetComponentInChildren<TextMeshProUGUI>().text = "This is a reply."; // Set reply text

        // You may need additional logic to position the reply appropriately within the comment layout
    }

    private void DisplayComments()
    {
        // Clear the text area before displaying comments
        // textArea.text = "";

        foreach (Transform child in commentParent)
        {
            // Fetch each comment text and update its display with like count
            string commentText = child.GetComponentInChildren<TextMeshProUGUI>().text;
            int likes = commentLikes.ContainsKey(commentText) ? commentLikes[commentText] : 0;
            child.GetComponentInChildren<TextMeshProUGUI>().text = $"{commentText}\nLikes: {likes}";

            // You can add more formatting or UI elements here if needed for better display
        }
    }
}
