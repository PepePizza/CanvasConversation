using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    public Transform cameraToFollow; // Reference to the camera's Transform component

    void Update()
    {
        //if (cameraToFollow != null) // Check if the cameraToFollow reference is set
        //{
            // Calculate the direction from the GameObject to the camera
            Vector3 lookDirection = cameraToFollow.position - transform.position;

            // Invert the look direction by multiplying it by -1
            lookDirection *= -1;

            // Create a rotation that faces the camera but keeps the same up direction
            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            // Apply the rotation to the GameObject
            transform.rotation = rotation;
        //}
    }
}