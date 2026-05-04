using UnityEngine;

// carries data from MainScene to GameOverScene
public class GameData : MonoBehaviour
{
    public int finalScore = 0;
    public int carsCompleted = 0;
    public string playerName = "";

    void Awake()
    {
        // same duplicate-prevention pattern as DontDestroy
        GameObject[] objs = GameObject.FindGameObjectsWithTag("GameData");
        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
            return;
        }

        // persist across scene loads so GameOverScene can read the data
        DontDestroyOnLoad(this.gameObject);
    }
}