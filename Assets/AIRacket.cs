using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIRacket : MonoBehaviour
{
    public float Speed = 4.5f;
    public GameObject Ball;

    private Vector3 _move;

	// Update is called once per frame
	void Update ()
	{
	    if (!GameManager.IsGameOver)
	    {
	        var direction = Ball.transform.position.y - transform.position.y;
	        _move.y = direction > 0 ? Speed*Mathf.Min(direction, 40) : -Speed*Mathf.Min(-direction, 40);
	        transform.position += _move*Time.deltaTime;
	    }
	}
}
