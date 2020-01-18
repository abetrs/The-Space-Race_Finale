using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreSystem : MonoBehaviour
{
    public float noOfPlayers;
    float score1;
    float score2;

    void Start()
    {
        if(SceneManager.GetActiveScene().name == "TwoPlayersScene")
        {
            noOfPlayers = 1;
        } else
        {
            noOfPlayers = 2;
        }
        score1 = 0f;
        score2 = 0f;
    }

    void Update()
    {
        
    }
    public void AddScore(int amount, string player)
    {
        if (player == "Player1")
        {
            score1 += amount;
        } else if (player == "Player2")
        {
            score2 += amount;
        }
    }
}
