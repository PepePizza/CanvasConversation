using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;


[RequireComponent(typeof(ARRaycastManager))]
public class PaintingTest : MonoBehaviour
{

    private ARRaycastManager raycastManager;
    private GameObject spawnedObject;

    [SerializeField] private GameObject PlaceablePrefeb;

    static List<ARRaycastHit> s_Hits = new List<ARRaycastHit>();
    
    public Vector3 imageFixedPosition;
    public Quaternion imageFixedRotation;



    private void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    bool TryGetTouchPosition(out Vector2 touchPosition)
    {
        if (Input.touchCount > 0)
        {
            touchPosition = Input.GetTouch(0).position;
            return true;
        }

        touchPosition = default;
        return false;
    }

    private void Update()
    {
        if (!TryGetTouchPosition(out Vector2 touchPosition))
        {
            return;
        }

        if (raycastManager.Raycast(touchPosition, s_Hits, TrackableType.PlaneWithinPolygon))
        {
            var hitPose = s_Hits[0].pose;

            if (spawnedObject == null)
            {
                // Instantiate the 2D image prefab at the fixed position and rotation
                spawnedObject = Instantiate(PlaceablePrefeb, imageFixedPosition, imageFixedRotation);
            }
            else
            {
                spawnedObject.transform.position = hitPose.position;
                spawnedObject.transform.rotation = hitPose.rotation;
            }
        }
    }
}