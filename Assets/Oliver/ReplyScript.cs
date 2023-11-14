using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReplyScript : MonoBehaviour
{
    public GameObject Reply;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
