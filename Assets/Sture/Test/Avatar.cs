using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Avatar : MonoBehaviour
{
    public List<Sprite> avatarImages = new List<Sprite>();
    private List<GameObject> avatarObjects = new List<GameObject>();
    private HashSet<Sprite> usedImages = new HashSet<Sprite>();

    void Update()
    {
        GameObject[] avatars = GameObject.FindGameObjectsWithTag("Avatar");

        foreach (GameObject avatar in avatars)
        {
            if (!avatarObjects.Contains(avatar))
            {
                avatarObjects.Add(avatar);

                Image imageComponent = avatar.GetComponent<Image>();

                if (imageComponent != null && avatarImages != null && avatarImages.Count > 0)
                {
                    List<Sprite> unusedImages = avatarImages.FindAll(image => !usedImages.Contains(image));

                    if (unusedImages.Count > 0)
                    {
                        Sprite randomSprite = unusedImages[Random.Range(0, unusedImages.Count)];
                        usedImages.Add(randomSprite);
                        imageComponent.sprite = randomSprite;
                    }
                }
            }
        }
    }
}