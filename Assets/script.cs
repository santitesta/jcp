using UnityEngine;

public class SceneCleaner : MonoBehaviour
{
    void Start()
    {
        // Find all objects in the scene
        GameObject[] allObjects = FindObjectsOfType<GameObject>();

        foreach (GameObject obj in allObjects)
        {
            // If the object is not one of our players or the floor, disable it
            if (obj.name != "Player1" 
            && obj.name != "Player2" 
            && obj.name != "Floor" 
            && obj.name != "Main Camera" 
            && obj.name != "Ball" 
            && obj.name != "Goal1" 
            && obj.name != "Goal2"
            && obj.name != "Canvas"
            )
            {
                obj.SetActive(false);
            }
        }
    }
}
