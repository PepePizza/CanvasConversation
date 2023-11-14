using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class SpawnEmojis : MonoBehaviour
{
    //reference to AR tracked image manager component 
    private ARTrackedImageManager trackedImageManager;
    
    //list of prefabs (with the same name as their corresponding 2D images!!)
    public GameObject[] smileyPrefabs;
    
    //Dictionary array of created prefabs
    private readonly Dictionary<string, GameObject> instantiated_smileyPreafbs = new Dictionary<string, GameObject>();

    

    private void Awake()
    {
        //reference to the tracked image manager component
        trackedImageManager = GetComponent<ARTrackedImageManager>();
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
        /*foreach (var trackedImage in eventArgs.added)
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
                    var new_smileyPrefab = Instantiate(currentPrefab, new Vector3(), currentPrefab.transform.rotation);
                    new_smileyPrefab.transform.parent = trackedImage.transform; // Set the tracked image as the parent
                    
                    // Set the local position of the child object to the center of the image
                    new_smileyPrefab.transform.localPosition = trackedImage.transform.position;
                    
                    //ad the instantiated prefab to array with instantiated prefabs 
                    instantiated_smileyPreafbs[imageName] = new_smileyPrefab;
                }
            }
        }*/
        
        foreach (var trackedImage in eventArgs.added)
        {
            var imageName = trackedImage.referenceImage.name;

            foreach (var currentPrefab in smileyPrefabs)
            {
                if (string.Compare(currentPrefab.name, imageName, StringComparison.Ordinal) == 0 
                    && !instantiated_smileyPreafbs.ContainsKey(imageName))
                {
                    var new_smileyPrefab = Instantiate(currentPrefab, trackedImage.transform.position, currentPrefab.transform.rotation);
                    new_smileyPrefab.transform.parent = trackedImage.transform;

                    // Set the local position of the child object to the center of the parent (ARTrackedImage)
                    new_smileyPrefab.transform.localPosition = Vector3.zero;

                    instantiated_smileyPreafbs[imageName] = new_smileyPrefab;
                }
            }
        }

        //set instatiated prefabs to active/ not active depending on if their image is currently being tracked 
        foreach (var trackedImage in eventArgs.updated)
        {
            instantiated_smileyPreafbs[trackedImage.referenceImage.name].SetActive(trackedImage.trackingState == TrackingState.Tracking);
        }
        
        //if AR subsystem gives up on looking for a tracked image 
        foreach (var trackedImage in eventArgs.removed)
        {
            //set the prefab to not active
           instantiated_smileyPreafbs[trackedImage.referenceImage.name].SetActive(false);
        }
    }
}
