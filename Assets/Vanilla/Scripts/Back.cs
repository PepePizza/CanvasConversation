using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Back : MonoBehaviour
{

    private Button backbutton;
    
    // Start is called before the first frame update
    void Start()
    {
        FindButtonInChildren(transform);
    }
    
    private void FindButtonInChildren(Transform parent)
    {
        foreach (Transform child in parent)
        {
            if (child.CompareTag("GoBackButton"))
            {
                backbutton = child.GetComponent<Button>();
                if (backbutton != null)
                {
                    backbutton.onClick.AddListener(GoBackFunction);
                    return; // Stop searching once the button is found
                }
                else
                {
                    return;
                }
            }

            // Recursively search in the children of the current child
            FindButtonInChildren(child);
        }
    }

    private void GoBackFunction()
    {
        gameObject.SetActive(false);
    }
}
