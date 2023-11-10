using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARRaycastManager))]
public class SpawnEmojis : MonoBehaviour
{
   
   
   private ARRaycastManager raycastManager;
   private GameObject spawnedSmiley;
   [SerializeField]
   private GameObject placeableSmiley;
   private static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
   
   
   private void Awake()
   {
      raycastManager = GetComponent<ARRaycastManager>();
   }
   

   //Record where the user is pressing on the screen (out Vector2)
   bool TryGetTouchPosition(out Vector2 touchposition)
   {
      //We want to check if we have recieved a valid touch on the screen.
      if (Input.touchCount > 0)
      {
         //Store the first touch position
         touchposition = Input.GetTouch(0).position;
         //Return true to say the touch is valid 
         return true;
      }
      //If the touch is not valid 
      touchposition = default;
      return false;
   }

   private void Update()
   {
      if (!TryGetTouchPosition(out Vector2 touchposition))
      {
         return;
      }
      
      if (raycastManager.Raycast(touchposition, s_Hits, TrackableType.PlaneWithinPolygon))
      {
         var hitPose = s_Hits[0].pose;

         if (spawnedSmiley == null)
         {
            spawnedSmiley = Instantiate(placeableSmiley, hitPose.position, hitPose.rotation);
         }
         else
         {
            spawnedSmiley.transform.position = hitPose.position;
            spawnedSmiley.transform.rotation = hitPose.rotation;
         }
      }
   }
}
