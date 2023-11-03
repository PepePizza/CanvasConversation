using UnityEngine;

public class PictureCapture : MonoBehaviour
{
    public void CapturePicture()
    {
        // Capture the screenshot
        ScreenCapture.CaptureScreenshot("CapturedPicture.png");
        Debug.Log("Picture captured!");
    }
}



