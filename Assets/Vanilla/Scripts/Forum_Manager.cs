using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System;
using Unity.VisualScripting;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[System.Serializable]
public struct canvas_forum_Prefabs
{
    public string corrosponding_emoji_tag;
    public GameObject forum_prefab;
}

public class Forum_Manager : MonoBehaviour
{

    public List<canvas_forum_Prefabs> forumPrefabs = new List<canvas_forum_Prefabs>();
    
    private String[] emoji_tags = new String[]{"Heart", "Angry", "Laughter", "Sadness", "Surprise"};
    
    private Camera camera;
    private GameObject selectedCanvas;
    private ChooseEmoji chooseEmojiScript;
    
    //Dictionary array of created prefabs
    private Dictionary<string, GameObject> instantiated_forumPrefabs = new Dictionary<string, GameObject>();

    private void Start()
    {
        chooseEmojiScript = GetComponent<ChooseEmoji>();
        
        camera = Camera.main;

        //instantiated and deactivates all canvases at the start
        foreach (var current_forum in forumPrefabs)
        {
            var new_forumGameobject = Instantiate(current_forum.forum_prefab);

            instantiated_forumPrefabs[current_forum.corrosponding_emoji_tag] = new_forumGameobject;
            new_forumGameobject.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (!chooseEmojiScript.emojisSelectorCanvas.activeSelf)
        {
            Select_Deselect_forum();
        }
    }

    private void Select_Deselect_forum()
    {
        //Select emoji 
        if (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Began)
        {
            //detect touch-position and create ray from it 
            Ray ray = camera.ScreenPointToRay(Input.touches[0].position);
            RaycastHit hit;
            
            //returns true if the ray hits something and stores the collision position in hit
            if (Physics.Raycast(ray, out hit))
            {
                foreach (var tag in emoji_tags)
                {
                    if (hit.collider.gameObject != null && hit.collider.gameObject.CompareTag(tag))
                    {
                        //activate the canvas corresponding to the emoji tag
                        instantiated_forumPrefabs[tag].gameObject.SetActive(true);
                        selectedCanvas = instantiated_forumPrefabs[tag];
                    }
                    //set the canvas to not active if the back button is pressed
                    else if (hit.collider.gameObject != null && hit.collider.gameObject.CompareTag("GoBackButton"))
                    {
                        selectedCanvas.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}
