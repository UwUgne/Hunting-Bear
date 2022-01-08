using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{

	public float speed = 2.0f;
	float moveSpeed;
	float currentTime;
	float speedIncrement = 0.2f;
	float timeToIncrease = 8.0f;

	Vector3 directionToTarget;
	Rigidbody2D rb;
	GameObject target;

	

	void Start()
	{
		currentTime = Time.time + timeToIncrease;

		target = GameObject.Find("Player");
		rb = GetComponent<Rigidbody2D>();

	}

	void Update()
	{
		if (Time.time >= currentTime)
        {
			speed += speedIncrement;
			currentTime = Time.time + timeToIncrease;
		}

			Movement();
		moveSpeed = Random.Range(1f, speed);
	}

	void Movement()
	{
		if (target != null)
		{
			directionToTarget = (target.transform.position - transform.position).normalized;
			rb.velocity = new Vector2(directionToTarget.x * moveSpeed,
										directionToTarget.y * moveSpeed);
		}
		else
			rb.velocity = Vector3.zero;
	}

	void OnCollisionEnter2D(Collision2D collision)
	{

		if (collision.gameObject.tag == "Bullets")
        {
			Destroy(gameObject);
			ScoreSystem.Score += 1;
        }


	}

}