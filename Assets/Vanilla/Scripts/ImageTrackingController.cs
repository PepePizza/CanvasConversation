using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class PlaceEmojies : MonoBehaviour
{
    public ARTrackedImageManager trackedImageManager;
    
    [SerializeField]
    private GameObject objectPrefab; // The prefab you want to place around the image.

    private Transform imageTransform;

    private void Awake()
    {
        trackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    private void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {
        foreach (var trackedImage in eventArgs.added)
        {
            imageTransform = trackedImage.transform;
            PlaceObjectsAroundImage(imageTransform);
        }
    }

    private void PlaceObjectsAroundImage(Transform imageTransform)
    {
        // You can calculate the positions around the tracked image here and instantiate the objects.
        // Example: Calculate positions and instantiate objects as children of imageTransform.

        for (int i = 0; i < 5; i++)
        {
            Vector3 position = CalculatePositionAroundImage(i);
            GameObject placedObject = Instantiate(objectPrefab, position, Quaternion.identity);
            placedObject.transform.parent = imageTransform;
        }
    }

    private Vector3 CalculatePositionAroundImage(int index)
    {
        // Calculate the position based on your desired layout around the image.
        // You can use trigonometry to evenly position the objects in a circle, for example.

        float angle = (360.0f / 5) * index; // 5 objects evenly spaced.
        Vector3 offset = Quaternion.Euler(0, angle, 0) * Vector3.forward;
        return imageTransform.position + offset;
    }
}




