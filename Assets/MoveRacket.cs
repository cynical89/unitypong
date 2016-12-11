using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRacket : MonoBehaviour
{
    public float Speed = 30f;
	void FixedUpdate ()
	{
	    if (!GameManager.IsGameOver)
	    {
	        GetComponent<Rigidbody2D>().velocity = new Vector2(0, Input.GetAxisRaw("Vertical")) * Speed;
	    }
	}
}
