using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[System.Serializable]
public struct ARObjectPrefab
{
    public string name;
    public GameObject prefab;
}

public class ARTrackImages : MonoBehaviour
{
    
    public List<ARObjectPrefab> objectPrefabs = new List<ARObjectPrefab>();
    private Dictionary<string, GameObject> instantiatedObjects;
    private ARTrackedImageManager trackedImagesManager;


// Start is called before the first frame update
    void Start()
    {
        trackedImagesManager = GetComponent<ARTrackedImageManager>();
        trackedImagesManager.trackedImagesChanged += OnTrackedImagesChanged;
        instantiatedObjects = new Dictionary<string, GameObject>();

    }
    
    
    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        
        foreach (ARTrackedImage trackedImage in eventArgs.added) 
        { 
            foreach (ARObjectPrefab obj in objectPrefabs) 
            { 
                if ((obj.name == trackedImage.referenceImage.name) && (!instantiatedObjects.ContainsKey(obj.name))) 
                {
                    instantiatedObjects[obj.name] = Instantiate(obj.prefab, trackedImage.transform);
                }
            }

        }
    
        foreach (ARTrackedImage trackedImage in eventArgs.updated) 
        { 
            if (trackedImage.trackingState == TrackingState.Tracking) 
            { 
                instantiatedObjects[trackedImage.referenceImage.name].SetActive(true);
            } 
            else 
            { 
                instantiatedObjects[trackedImage.referenceImage.name].SetActive(false); 
            } 
        }
        
        foreach (ARTrackedImage trackedImage in eventArgs.removed) 
        { 
            Destroy(instantiatedObjects[trackedImage.referenceImage.name]);

            instantiatedObjects.Remove(trackedImage.referenceImage.name);
        }
    
    }
    
}
