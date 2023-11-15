using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LaughingForum1 : MonoBehaviour
{
    //public GameObject commentCanvas;

    public Button addComment;
    public GameObject write_a_comment;
    public TMP_InputField inputField;
    public TextMeshProUGUI textArea;
    public Button topLikeButton;
    public Button likeButton;

    private int toplikeAmount = 12;
    public TMP_Text numberofTopLikes;
    //private int likeAmount = 0;
    //public TMP_Text numberofLikes;


    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Transform m_ContentContainer;
    [SerializeField] private GameObject m_ItemPrefab;


    void Start()
    {
        //commentCanvas.SetActive(false);
        Text numberofTopLikes = topLikeButton.GetComponentInChildren<Text>();
        Text numberofLikes = likeButton.GetComponentInChildren<Text>();

        if (numberofTopLikes != null)
        {
            numberofTopLikes.text = toplikeAmount.ToString(); // Initialize the text to the initial value
            //numberofLikes.text = likeAmount.ToString(); // Initialize the text to the initial value
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // The Enter key was pressed, so add a new comment
            AddComment();
            OnAddButtonClick();

            // Clear the text in the TMP_InputField
            inputField.text = string.Empty;
        }
    }

    public void OnAddButtonClick()
    {
        if (write_a_comment != null)
        {
            bool isActive = write_a_comment.activeSelf;
            write_a_comment.SetActive(!isActive);

            Canvas.ForceUpdateCanvases(); // Ensure layout calculations are up to date
            scrollRect.normalizedPosition = new Vector2(0, 1);

        }
    }

    void AddComment()
    {
        if (m_ContentContainer != null && m_ItemPrefab != null)
        {
            var item_go = Instantiate(m_ItemPrefab, m_ContentContainer.transform);

            LikeSystem likeSystem = item_go.GetComponent<LikeSystem>();

            if (likeSystem != null)
            {
                likeSystem.InitializeLikeCount(0);
            }
        }
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
            // Now you can access and modify the text of the Button
            numberofTopLikes.text = toplikeAmount.ToString();
        }
    }


}


