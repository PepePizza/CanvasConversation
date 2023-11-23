using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class TestSpawnEmojis : MonoBehaviour
{
    //reference to AR tracked image manager component 
    private ARTrackedImageManager trackedImageManager;
    
    //list of prefabs (with the same name as their corresponding 2D images!!)
    public GameObject[] smileyPrefabs;
    
    //Dictionary of created prefabs
    private readonly Dictionary<string, GameObject> instantiated_smileyPreafbs = new Dictionary<string, GameObject>();
    
    //Dictionary of pictures and a boolean stating if there has already been chosen a reaction to it or not
    private Dictionary<string, bool> image_reaction_bool = new Dictionary<string, bool>();

    private Camera camera;

    public GameObject emojisSelectorCanvas;
    
    // Add a public property to get the currently tracked image
    public ARTrackedImage CurrentlyTrackedImage { get; private set; }

    private List<Transform> children;
    
    //The amount the size should increase by
    public float increaseAmount = 50f;
    public float increaseHeartAmount = 25f;
    
    
    private void Awake()
    {
        //reference to the tracked image manager component
        trackedImageManager = GetComponent<ARTrackedImageManager>();
        
        camera = Camera.main;
    }

    private void OnEnable()
    {
        //attach event handler when tracked images change
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnDisable()
    {
        //remove event handler
        trackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        
        //loop through all new tracked images that has been detected
        foreach (var trackedImage in eventArgs.added)
        {
            //get name of reference image
            var imageName = trackedImage.referenceImage.name;
            
            //check if the dictionary image_reaction_bool contains image
            if (!image_reaction_bool.ContainsKey(imageName))
            {
                emojisSelectorCanvas.SetActive(true);
                
                //add the image to dictionary with a true bool 
                image_reaction_bool[imageName] = false;
            }
            else if (image_reaction_bool[imageName])
            {
                //loop over the array of prefabs 
                foreach (var currentPrefab in smileyPrefabs)
                {
                    //check if prefab name matches tracked image name and prefab has not been instantiated
                    if (string.Compare(currentPrefab.name, imageName, StringComparison.Ordinal) == 0 
                        && !instantiated_smileyPreafbs.ContainsKey(imageName))
                    {
                        //instantiat prefab and parent it to the ARTrackedImage
                        var new_smileyPrefab = Instantiate(currentPrefab, trackedImage.transform.position, currentPrefab.transform.rotation);
                        new_smileyPrefab.transform.parent = trackedImage.transform;

                        // Set the local position of the child object to the center of the parent (ARTrackedImage)
                        new_smileyPrefab.transform.localPosition = Vector3.zero;
                    
                        //ad the instantiated prefab to array with instantiated prefabs
                        instantiated_smileyPreafbs[imageName] = new_smileyPrefab;
                        
                    }
                }
                
                //check if the currently tracked image has changed
                if (trackedImage.trackingState == TrackingState.Tracking)
                {
                    children = GetChildren(trackedImage.transform,  true);
                }
            }
        }

        //set instatiated prefabs to active/ not active depending on if their image is currently being tracked 
        foreach (var trackedImage in eventArgs.updated)
        {
            if (image_reaction_bool[trackedImage.referenceImage.name])
            {
                instantiated_smileyPreafbs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
            
                // Update the CurrentlyTrackedImage when a new image is tracked
                if (trackedImage.trackingState == TrackingState.Tracking)
                {
                    CurrentlyTrackedImage = trackedImage;
                }
            }
        }
        
        //if AR subsystem gives up on looking for a tracked image 
        foreach (var trackedImage in eventArgs.removed)
        {
            if (image_reaction_bool[trackedImage.referenceImage.name])
            {
                //set the prefab to not active
                instantiated_smileyPreafbs[trackedImage.referenceImage.name].SetActive(false);
            }

            if (emojisSelectorCanvas.activeSelf)
            {
                //set the emojiselector to not active 
                emojisSelectorCanvas.SetActive(false);
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
        tag = Test_ChooseEmoji.buttonName;
        
        // Loop through each children inthechildren list
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

    public void react_to_current_image()
    {
        image_reaction_bool[CurrentlyTrackedImage.referenceImage.name] = true;
        
    }
    
}
