using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBounce : MonoBehaviour
{
    public GameObject hitSFX;
    public BallMove ballMove;
    public ScoreManager scoreManager;
    private void bounce(Collision2D collision)
    {
        Vector3 ballPosition =transform.position;
        Vector3 racketPoition =collision.transform.position;
        float racketHeight = collision.collider.bounds.size.y;

        float positionX;
        if(collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }
        float positionY = (ballPosition.y - racketPoition.y) / racketHeight;

        ballMove.IncreasHitCounter();
        ballMove.MoveingBall(new Vector2(positionX, positionY));
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name =="Player 1" || collision.gameObject.name=="Player 2")
        {
            bounce(collision);
        }
        else if(collision.gameObject.name =="Right Border")
        {
            scoreManager.Player1Goal();
            ballMove.player1Start = false;
            StartCoroutine(ballMove.Launch());

        }
        else if (collision.gameObject.name == "Left Border")
        {
            scoreManager.Player2Goal();
            ballMove.player1Start = true;
            StartCoroutine(ballMove.Launch());
        }
        Instantiate(hitSFX, transform.position, transform.rotation);
    }

}
