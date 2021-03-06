﻿using UnityEngine;
using System.Collections;

public class Pusher : Robo
{
	STATE state = STATE.IDLE;

	void Start()
	{
		this.audioSource = gameObject.AddComponent<AudioSource>();
		this.cooldown = 10;
		this.cost = 15;
		this.description = "Robô que empurra";
		//audioSource.clip = Resources.Load("Sounds/1") as AudioClip;	
	}

	void FixedUpdate()
	{
		this.target = GameObject.FindGameObjectWithTag("Scientist");

		switch (this.state) 
		{
		case STATE.IDLE:
			break;
		case STATE.COOLDOWN:
			Physics2D.IgnoreCollision (this.gameObject.GetComponent<BoxCollider2D> (), target.gameObject.GetComponent<BoxCollider2D> ());
			break;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag.Equals ("Scientist") && this.state == STATE.IDLE) 
		{
			c.gameObject.GetComponent<Rigidbody2D> ().AddForce(new Vector2(-5, 0), ForceMode2D.Impulse);
			this.state = STATE.COOLDOWN;
			StartCoroutine (Cooldown ());
		}				
	}

	IEnumerator Cooldown()
	{
		while (true) 
		{
			yield return new WaitForSeconds(this.cooldown);
			this.state = STATE.IDLE;
		}
	}
}
