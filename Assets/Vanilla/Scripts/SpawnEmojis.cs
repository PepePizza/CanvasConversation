using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.iOS;
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
}
