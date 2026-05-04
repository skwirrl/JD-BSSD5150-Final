using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    // early initialization with awake
    void Awake()
    {
        // check if a music object already exists from a previous scene load
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Music");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject); 
            return;
        }

        // tells Unity to preserve this object when loading a new scene
        DontDestroyOnLoad(this.gameObject);
    }
}
