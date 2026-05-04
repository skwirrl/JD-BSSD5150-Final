using UnityEngine;
using UnityEngine.SceneManagement; // required for SceneManager.LoadScene

public class GameController : MonoBehaviour
{
    private int score = 0;
    private int lives = 3;
    private int carsCompleted = 0;

    // collect enough parts to finish each car
    private int partsNeeded = 3;   // first car requires 3 parts
    private int partsCaught = 0;


    [SerializeField] private SpawnController spawner;

    void Start()
    {
        partsCaught = 0;
        partsNeeded = 3;
        // reset music to calm on restart
        AudioController audio = FindAnyObjectByType<AudioController>();
        if (audio != null) audio.GoCalm();
    }

    // called by PlayerController when the player touches a Part-tagged item
    public void PartCaught()
    {
        partsCaught++;
        score += 10;

        // update the HUD
        UIController ui = FindAnyObjectByType<UIController>();
        ui.UpdateScore(score);
        ui.UpdateRepairProgress(partsCaught, partsNeeded);

        // check if this car's repair is complete
        if (partsCaught >= partsNeeded)
        {
            CarComplete();
        }
    }

    void CarComplete()
    {
        carsCompleted++;
        score += 50; // bonus for completing a car

        // each new car requires 2 more parts than the last
        partsNeeded = 3 + (carsCompleted * 2);
        partsCaught = 0;

        // increase spawn speed, minimum 0.5s between spawns
        float newRate = Mathf.Max(0.5f, 2f - (carsCompleted * 0.3f));
        spawner.SetSpawnRate(newRate);

        // refresh the HUD
        UIController ui = FindAnyObjectByType<UIController>();
        ui.UpdateScore(score);
        ui.UpdateRepairProgress(partsCaught, partsNeeded);
        ui.ShowNewCar(carsCompleted + 1);

        // transition to intense music after completing 2 cars
        if (carsCompleted == 2)
        {
            AudioController audio = FindAnyObjectByType<AudioController>();
            if (audio != null) audio.GoIntense();
        }
    }

    // called by PlayerController when the player touches a Junk-tagged item
    public void LoseLife()
    {
        lives--;

        UIController ui = FindAnyObjectByType<UIController>();
        ui.UpdateLives(lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    void GameOver()
    {
        // store score data in GameData so it survives the scene transition
        GameData data = FindAnyObjectByType<GameData>();
        data.finalScore = score;
        data.carsCompleted = carsCompleted;
        data.playerName = PlayerPrefs.GetString("PlayerName", "Player");

        SceneManager.LoadScene("GameOverScene");
    }

    public int GetScore() { return score; }
    public int GetCarsCompleted() { return carsCompleted; }
}
