using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int scoreToReach = 3;  

   private int player1Score = 0;
   private int player2Score = 0;

    public Text player1ScoreText;
    public Text player2ScoreText;

    public void Player1Goal()
    {
        player1Score++;
        player1ScoreText.text=player1Score.ToString();
        checkScore();
    }
    public void Player2Goal()
    {
        player2Score++;
        player2ScoreText.text = player2Score.ToString();
        checkScore();
    }
    private void checkScore()
    {
      if(player1Score==scoreToReach || player2Score == scoreToReach)
        {
            SceneManager.LoadScene(2);
        }
    }
}
