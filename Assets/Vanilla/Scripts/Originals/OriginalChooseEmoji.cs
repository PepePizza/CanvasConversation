using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class OriginalChooseEmoji : MonoBehaviour, IPointerClickHandler
{
    //reference to AR tracked image manager component 
    private ARTrackedImageManager trackedImageManager;
    
    private TestSpawnEmojis spawnEmojisScript;
    private List<Transform> children;

    //public CanvasGroup canvasGroup;
    public GameObject emojisSelectorCanvas;

    //The amount the size should increase by
    public float increaseAmount = 50f;
    public float increaseHeartAmount = 25f;

    private ARTrackedImage currentTrackedImage;

    private Button buttonComponent;

    private void Awake()
    {
        //reference to the tracked image manager component
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        spawnEmojisScript = GetComponent<TestSpawnEmojis>();
    }

    private void Update()
    {
        //reference to the currently  tracked image 
        currentTrackedImage = spawnEmojisScript.CurrentlyTrackedImage;
    }
    
    public void OnPointerClick (PointerEventData eventData)
    {
        // Get the tag of the clicked button's GameObject
        string buttonTag = eventData.pointerPress.tag;
        emojisSelectorCanvas.SetActive(false);
        spawnEmojisScript.react_to_current_image();
    }

    public void onClicked(Button button)
    {
        string button_tag = button.name;
        emojisSelectorCanvas.SetActive(false);
        spawnEmojisScript.react_to_current_image();
    }

    
    private void OnEnable()
    {
        //attach event handler when tracked images change
        trackedImageManager.trackedImagesChanged += CurrentImageChanged;
    }

    private void OnDisable()
    {
        //remove event handler
        trackedImageManager.trackedImagesChanged -= CurrentImageChanged;
    }

    private void CurrentImageChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        //loop through all new tracked images that has been detected
        foreach (var trackedImage in eventArgs.added)
        {
            //check if the currently tracked image has changed
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                children = GetChildren(transform,  true);
            }
        }
    }

    // This method is called when the currentTrackedImage changes and updates the list of children. 
    List<Transform> GetChildren(Transform currentTrackedImage, bool recursive)
    {
        List<Transform> children = new List<Transform>();

        foreach (Transform child in currentTrackedImage)
        {
            children.Add(child);
            if (recursive)
            {
                children.AddRange(GetChildren(child,true));
            }
        }

        return children;
    }

    public void OnClick_IncreaseSize(string tag)
    {
        // Loop through each children in the children list
        for (int i = 0; i < children.Count; i++)
        {
            // Get the i child
            Transform child = children[i];

            // Check if the child's tag matches the target tag
            if (child.CompareTag(tag))
            {
                if (tag == "Heart")
                {
                    IncreaseHeartSize(child.gameObject);
                }
                else
                {
                    IncreaseSize(child.gameObject);
                }
                
            }
        }
        
        emojisSelectorCanvas.SetActive(false);
        spawnEmojisScript.react_to_current_image();
        
    }
    
    void IncreaseSize(GameObject obj)
    {
        Vector3 currentSize = obj.transform.localScale;
        obj.transform.localScale = new Vector3(currentSize.x + increaseAmount, currentSize.y + increaseAmount, currentSize.z + increaseAmount);
    }
    
    void IncreaseHeartSize(GameObject obj)
    {
        Vector3 currentSize = obj.transform.localScale;
        obj.transform.localScale = new Vector3(currentSize.x + increaseHeartAmount, currentSize.y + increaseHeartAmount, currentSize.z + increaseHeartAmount);
    }
}


