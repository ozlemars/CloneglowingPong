using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerTwo : MonoBehaviour
{
    public float racketSpeed;

    private Rigidbody2D rb2;
    private Vector2 racketDirection;

    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        float directionY = Input.GetAxisRaw("Cancel");
        racketDirection = new Vector2(0, directionY).normalized;
    }
    private void FixedUpdate()
    {
        rb2.velocity = racketDirection * racketSpeed;
    }
}
