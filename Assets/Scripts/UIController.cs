using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;
    [SerializeField] private Text repairText;
    [SerializeField] private Text carText;

    void Start()
    {
        // initialize all display values
        UpdateScore(0);
        UpdateLives(3);
        UpdateRepairProgress(0, 3);
        ShowNewCar(1);
    }

    // called by GameController whenever values change
    public void UpdateScore(int score)
    {
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }

    // displays progress toward completing the current car (e.g. "Parts: 2/5")
    public void UpdateRepairProgress(int caught, int needed)
    {
        repairText.text = "Parts: " + caught + "/" + needed;
    }

    public void ShowNewCar(int carNumber)
    {
        carText.text = "Car #" + carNumber;
    }
}