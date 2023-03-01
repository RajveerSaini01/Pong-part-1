using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float startSpeed;

    public float extraspeed;
    private int hitCounter = 0;
    public float maxExtraSpeed;
    public bool player1start = true;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Launch());
    }

    public void RestartBall()
    {
        rb.velocity = new Vector2(0, 0);
        transform.position = new Vector2(0, 0); 
    }
    public IEnumerator Launch()
    {
        RestartBall();
        hitCounter = 0;
        yield return new WaitForSeconds(1);
        if (player1start == true)
        {
           MoveBall((new Vector2(-1,0))); 
        }
        else
        {
            MoveBall(new Vector2(1,0));
        }
        
        
    }
    public void MoveBall(Vector2 direction)
    {
        direction = direction.normalized;
        float ballSPeed = startSpeed + hitCounter * extraspeed;

        rb.velocity = direction * ballSPeed;
    }

    public void IncreaseHitCounter()
    {
        if (hitCounter * extraspeed < maxExtraSpeed)
        {
            hitCounter++;
        }
    }

}
