using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{

    [SerializeField] private Text resultText;

    void Start()
    {
        // retrieve the GameData object that persisted from MainScene
        GameData data = FindAnyObjectByType<GameData>();
        if (data != null)
        {
            // check and update the all-time high score
            int best = PlayerPrefs.GetInt("HighScore", 0); // defaults to 0 if no score saved yet
            if (data.finalScore > best)
            {
                PlayerPrefs.SetInt("HighScore", data.finalScore);
                PlayerPrefs.Save();
                best = data.finalScore;
            }

            // display the results
            resultText.text = data.playerName + "\n"
                + "Score: " + data.finalScore + "\n"
                + "Cars Fixed: " + data.carsCompleted + "\n"
                + "Best Score: " + best;
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene("MainMenuScene");
    }
}
