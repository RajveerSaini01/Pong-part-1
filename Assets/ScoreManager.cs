using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour
{
    private int player1Score = 0;
    private int player2Score = 0;
    public Text player1ScoreText;
    public Text player2ScoreText;
    public int scoreToReach;
    public void Player1Goal()
    {
        player1Score++;
        player1ScoreText.text = player1Score.ToString();
        Debug.Log("Player 1 Scored");
        Debug.Log($"Player 1 has {player1Score}");
        CheckScore();
    }
    
    public void Player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        Debug.Log("Player 2 Scored");
        Debug.Log($"Player 2 has {player2Score}");
        CheckScore();
        
    }

    private void CheckScore()
    {
        if (player1Score == scoreToReach || player2Score == scoreToReach)
        {
            SceneManager.LoadScene(2);
        }
    }
    
}
    
