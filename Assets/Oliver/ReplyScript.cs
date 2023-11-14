using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ReplyScript : MonoBehaviour
{
    public TMP_InputField inputField;
    public GameObject Reply;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // The Enter key was pressed, so add a new comment

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

}
