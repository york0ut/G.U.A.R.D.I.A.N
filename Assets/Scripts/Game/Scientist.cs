using UnityEngine;
using System.Collections;

public class Scientist : MonoBehaviour
{
	bool walking;

	void Start()
	{
		this.walking = true;
	}

	void FixedUpdate()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			//this
		}	

		if (walking)
			this.transform.position = Vector2.MoveTowards(this.transform.position, new Vector3(GameObject.Find("Exit").transform.position.x, this.transform.position.y, 0), 0.01f);
		//this.transform.position = Vector3.Lerp(this.transform.position, new Vector3(GameObject.Find("Exit").transform.position.x, this.transform.position.y, 0), 0.0018f);
	}
}
