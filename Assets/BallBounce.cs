using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BallBounce : MonoBehaviour
{
    // Start is called before the first frame update
    public BallMovement ballMovement;
    public ScoreManager scoreManager;
    public GameObject hitSFX;
    private void Bounce(Collision2D collision)
    {
        Vector3 ballPosition = transform.position;
        Vector3 racketPosition = collision.transform.position;
        float racketheight = collision.collider.bounds.size.y;

        float positionX;
        if (collision.gameObject.name == "Player 1")
        {
            positionX = 1;
        }
        else
        {
            positionX = -1;
        }
        
        float positionY = (ballPosition.y - racketPosition.y)/ racketheight;
        ballMovement.IncreaseHitCounter();
        ballMovement.MoveBall((new Vector2(positionX,positionY)));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player 1" || collision.gameObject.name == "PLayer 2")
        {
            Bounce(collision);
        }
        else if (collision.gameObject.name == "Right Boarder")
        {
            scoreManager.Player1Goal();
            ballMovement.player1start = false;
            StartCoroutine((ballMovement.Launch()));
        }
        else if (collision.gameObject.name == "Left Boarder")
        {
            scoreManager.Player2Goal();
            ballMovement.player1start = true;
            StartCoroutine((ballMovement.Launch()));
        }

        Instantiate(hitSFX, transform.position, transform.rotation);
    }
}
