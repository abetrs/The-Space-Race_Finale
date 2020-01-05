// This script is incharge of the score of the player
using UnityEngine;
using UnityEngine.UI;
public class ScoreManager : MonoBehaviour
{
    public float highScore;
    public float score;
    public bool death = false;
    // This is multiplied by the time the player is alive to create a score bonus for staying aliv;
    private float timeAlivMult = 0.15f;
    // This is the time until the timeAlivMult variable's value increases;
    private float timeAlivInc = 10f;
    private float timeTillInc;
    private float timeAlivMultS = 0.05f;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
        highScore = PlayerPrefs.GetInt("High Score");
    }
    void Update()
    {
        // displays the score
        text.text = "Score: " + (int)score;

        if (death == true)
        {
            PlayerPrefs.SetInt("Score", (int)score);
            if (score > highScore)
            {
                PlayerPrefs.SetInt("High Score", (int)score);
            }
        } else
        {

        }
    }
}
