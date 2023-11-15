using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ChooseEmoji : MonoBehaviour
{

    private string buttonTag;
    

    // This method will be called when the button is clicked
    public void OnButtonClick()
    {
        // Get the tag of the button's GameObject
        buttonTag = gameObject.tag;

    }

    public void OnClick_IncreaseSize()
    {
        // Loop through each child of the GameObject
        for (int i = 0; i < transform.childCount; i++)
        {
            // Get the i-th child
            Transform child = transform.GetChild(i);

            // Check if the child's tag matches the target tag
            if (child.CompareTag(buttonTag))
            {
                // Do something when the tag matches
            }
        }

    }
}

