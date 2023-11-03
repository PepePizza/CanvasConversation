using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionController : MonoBehaviour
{
    //Reference to the camera's Transform component
    public Transform cameraToFollow; 

    void Update()
    {
            //lookDirection is a Vector3 variable that stores the direction from the camera's position to the object's position
            //cameraToFollow is a variable representing the position of a camera in the scene
            //transform.position is a reference to the position of the emojis
            Vector3 lookDirection = cameraToFollow.position - transform.position;

            //Inverts the lookDirection vector. Multiplying a vector by -1 essentially flips its direction
            lookDirection *= -1;
            
            /*Quaternion.LookRotation is a function that creates a rotation quaternion based on the specified direction.
            It computes a rotation that aligns the forward direction with the given lookDirection*/
            Quaternion rotation = Quaternion.LookRotation(lookDirection, Vector3.up);

            //sets the rotation of the object's transform to the rotation quaternion calculated. It makes the object face in the direction of the camera
            transform.rotation = rotation;
        
    }
}