using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private InputField nameInput;

    // constant prevents typos when referencing the same PlayerPrefs key
    private const string NAME_KEY = "PlayerName";

    void Start()
    {
        // if a name was saved from a previous session, pre-fill it
        if (PlayerPrefs.HasKey(NAME_KEY))
        {
            nameInput.text = PlayerPrefs.GetString(NAME_KEY);
        }
    }

    public void StartGame()
    {
        // save the entered name so it persists between sessions
        PlayerPrefs.SetString(NAME_KEY, nameInput.text);
        PlayerPrefs.Save();

        // load the gameplay scene
        SceneManager.LoadScene("MainScene");
    }
}