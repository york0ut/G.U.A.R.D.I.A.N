using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Scientist : MonoBehaviour
{
	public GameObject perdeu, canvas;
	bool walking;
	float speed;

	public void setSpeed(float speed)
	{
		this.speed = speed;
		StartCoroutine(cd());
	}

	void Start()
	{
		this.walking = true;
		this.speed = 0.018f;
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			//this
		}	

		if (walking)
			this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector3(GameObject.Find("Exit").transform.position.x, this.transform.position.y, 0), speed);
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag.Equals ("exit")) 
		{
			SceneManager.LoadScene ("Defeat");
		}
	}

	IEnumerator cd()
	{
		while (true)
		{
			yield return new WaitForSeconds (4);
			this.speed = 0.018f;
			StopAllCoroutines ();
		}
	}
}
