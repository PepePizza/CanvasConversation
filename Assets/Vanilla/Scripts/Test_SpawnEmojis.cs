using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class Test_SpawnEmojis : MonoBehaviour
{
    //reference to AR tracked image manager component 
    private ARTrackedImageManager trackedImageManager;
    
    //list of prefabs (with the same name as their corresponding 2D images!!)
    public GameObject[] smileyPrefabs;
    
    //Dictionary array of created prefabs
    private readonly Dictionary<string, GameObject> instantiated_smileyPreafbs = new Dictionary<string, GameObject>();

    private Camera camera;

    public GameObject emojisSelectorCanvas;
    
    // Add a public property to get the currently tracked image
    public ARTrackedImage CurrentlyTrackedImage { get; private set; }

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
            //get name of  reference image
            var imageName = trackedImage.referenceImage.name;
            
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
            
            emojisSelectorCanvas.SetActive(true);
        }
        

        //set instatiated prefabs to active/ not active depending on if their image is currently being tracked 
        foreach (var trackedImage in eventArgs.updated)
        {
            instantiated_smileyPreafbs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
            
            // Update the CurrentlyTrackedImage when a new image is tracked
            if (trackedImage.trackingState == TrackingState.Tracking)
            {
                CurrentlyTrackedImage = trackedImage;
            }
        }
        
        //if AR subsystem gives up on looking for a tracked image 
        foreach (var trackedImage in eventArgs.removed)
        {
            //set the prefab to not active
           instantiated_smileyPreafbs[trackedImage.referenceImage.name].SetActive(false);
           
           //set the emojiselector to not active 
           emojisSelectorCanvas.SetActive(false);
        }
    }
}
