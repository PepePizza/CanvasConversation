using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SadForum : MonoBehaviour
{
    //public GameObject commentCanvas;
    
    public Button addComment;
    public GameObject write_a_comment;
    public TMP_InputField inputField;
    public TextMeshProUGUI textArea;
    public Button topLikeButton;
    public Button likeButton;

    private int toplikeAmount = 8;
    public TMP_Text numberofTopLikes;
    private int likeAmount = 0;
    public TMP_Text numberofLikes;
    



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
            numberofLikes.text = likeAmount.ToString(); // Initialize the text to the initial value
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
            
        }
    }

    void AddComment()
    {
        if (m_ContentContainer != null && m_ItemPrefab != null)
        {
            var item_go = Instantiate(m_ItemPrefab, m_ContentContainer.transform);

            // Access the TMP_InputField in the instantiated object
            TMP_InputField inputFieldInstance = item_go.GetComponentInChildren<TMP_InputField>();

            if (inputFieldInstance != null)
            {
                // Set the TMP_InputField in the instantiated object to non-interactable
                inputFieldInstance.readOnly = true;
                


            }

            item_go.transform.localScale = Vector2.one;
        }
    }

    public void OnTopLikeButtonClick()
    {

        

        if (numberofTopLikes != null)
        {
            
                if (toplikeAmount == 8)
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

    public void OnLikeButtonClick()
    {



        if (numberofLikes != null)
        {

            if (likeAmount == 0)
            {
                likeAmount += 1;
            }
            else
            {
                likeAmount -= 1;
            }



            // Now you can access and modify the text of the Button
            numberofLikes.text = likeAmount.ToString();
        }



    }

}


