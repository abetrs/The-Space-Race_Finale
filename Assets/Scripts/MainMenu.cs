// This scripts is responsible for controlling the Main Menu scene
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    // This method is called if the 1 Player button is pressed
    public void On1PlayersPress()
    {
        SceneManager.LoadScene("SingeplayerScene");
    }
    // This method is called if the 2 players button is pressed
    public void On2PlayersPress()
    {
        SceneManager.LoadScene("TwoPlayersScene");
    }
    // This method is called if the Help Button is pressed
    public void OnHelpPress()
    {
        SceneManager.LoadScene("Help");
    }

}
