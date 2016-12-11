using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private const float Speed = 60;
    // Use this for initialization
    private void Start()
    {
        GetComponent<Rigidbody2D>().velocity = RandomDirection() * Speed;
    }

    private void Update()
    {
        if (GameManager.IsGameOver)
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the left Racket?
        if (col.gameObject.name == "RacketLeft")
        {
            // Calculate hit Factor
            var y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            var dir = new Vector2(1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * Speed;
        }

        // Hit the right Racket?
        if (col.gameObject.name == "RacketRight")
        {
            // Calculate hit Factor
            var y = HitFactor(transform.position,
                                col.transform.position,
                                col.collider.bounds.size.y);

            // Calculate direction, make length=1 via .normalized
            var dir = new Vector2(-1, y).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * Speed;
        }

        if (col.gameObject.name == "LeftWall")
        {
            GameManager.Score0 += 1;
            ResetBall();
        }

        if (col.gameObject.name == "RightWall")
        {
            GameManager.Score1 += 1;
            ResetBall();
        }
    }

    private static float HitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketHeight)
    {
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    private void ResetBall()
    {
        transform.position = Vector3.zero;
        GetComponent<Rigidbody2D>().velocity = RandomDirection() * Speed;
    }

    private Vector2 RandomDirection()
    {
        var rand = new System.Random(Guid.NewGuid().GetHashCode());
        var direction = rand.Next(0, 100);
        return direction % 2 == 0? Vector2.left : Vector2.right;
    }
}