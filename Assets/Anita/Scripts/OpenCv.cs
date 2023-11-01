using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;
using UnityEngine.UI;

public class OpenCv : MonoBehaviour
{
    public Image traininngPhoto;

    static void main()
    {
        double contrast = 1.5;
        double brightness = 1;
        
        Mat painting = Cv2.ImRead("IMG_2152.jpeg", ImreadModes.Color);

        Mat adjustedImage = new Mat();
        Cv2.ConvertScaleAbs(painting, adjustedImage, contrast, brightness);
        
        Mat grayImage = new Mat();
        Cv2.CvtColor(adjustedImage, grayImage, ColorConversionCodes.BGR2GRAY);

        Mat edges = new Mat();
        Cv2.Canny(grayImage, edges, 200, 100);

        Cv2.ImShow($"Processed {painting}", edges);
        Cv2.WaitKey(0);
        Cv2.DestroyAllWindows();
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
