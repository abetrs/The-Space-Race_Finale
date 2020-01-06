using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialSceneManager : MonoBehaviour
{
    public void OnBack()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
