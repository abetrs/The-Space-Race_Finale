// Responsible for a controlling the game over screen
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public Text text;
    // Start is called before the first frame update
    void Start()
    {
        // Displays the score and high score of the player
        text = GetComponent<Text>();
        text.text = "Score: " + PlayerPrefs.GetInt("Score") + "\nHigh Score: " + PlayerPrefs.GetInt("High Score");
    }

    // This method is called when restart is pressed
    public void OnRestart()
    {
        if (SceneManager.GetActiveScene().name == "MP_GameOver")
        {
            SceneManager.LoadScene("TwoPlayersScene");
        }
        else if (SceneManager.GetActiveScene().name == "SP_GameOver")
        {
            SceneManager.LoadScene("SingePlayerScene");
        }
    }
    // This method is called when the main menu button is pressed
    public void OnMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
