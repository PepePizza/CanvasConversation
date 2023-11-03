using UnityEngine;
using UnityEngine.UI;

public class CaptureButton : MonoBehaviour
{
    [SerializeField] private PictureCapture pictureCapture; // Reference to your PictureCapture script

    private void Start()
    {
        Button captureButton = GetComponent<Button>(); // Get the button component
        captureButton.onClick.AddListener(OnCaptureButtonClick); // Add a click event listener
    }

    private void OnCaptureButtonClick()
    {
        // Call the CapturePicture method in your PictureCapture script
        pictureCapture.CapturePicture();
    }
}

