using UnityEngine;

public class FallingItem : MonoBehaviour
{

    public string partName;

    // called automatically when the object leaves camera view
    // prevents offscreen objects from piling up in memory
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}