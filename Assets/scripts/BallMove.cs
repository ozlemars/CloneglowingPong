using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMove : MonoBehaviour
{
    public float startSpeed;
    public float extraSpeed;
    public float maxExtraSpeed; 

    public bool player1Start = true;

    private int hitCounter = 0;

    private Rigidbody2D rb2;
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }
    private void ReStartBall()
    {
        rb2.velocity = new Vector2(0,0);
        transform.position = new Vector2(0,0);
    }

    public IEnumerator Launch()
    {
        ReStartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(0.5f);

        if(player1Start==true)
        {
            MoveingBall(new Vector2(-1, 0));
        }
        else
        {
            MoveingBall(new Vector2(1, 0));
        }
        
    }
    public void MoveingBall(Vector2 direction)
    {
        direction = direction.normalized;

        float ballSpeed = startSpeed + hitCounter * extraSpeed;

        rb2.velocity = direction * ballSpeed;
    }

    public void IncreasHitCounter()
    {
        if(hitCounter*extraSpeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

}
