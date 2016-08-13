using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public Texture2D[] cursorTexture;
	public GameObject[] robo;
	public GameObject scientist;
	public Slider timeBar;
	public Text timeText, pointText;
	Vector3 mousePosition, objectPosition;
	float time;
	int points;
	bool started;

	public Image tooltip;
	public Text textName, textDesc, textCost;

	public enum mouseState
	{
		NONE,
		PUSHER,
		SLOW,
		STUN
	};
	mouseState state = mouseState.NONE;

	void Start()
	{
		this.started = false;
		this.points = 20;
		StartCoroutine(decrease ());
	}

	void FixedUpdate()
	{
		if (started)
		{
			Game ();

			if (time < 0)
				SceneManager.LoadScene ("Fase 2");
		}
		else 
		{
			Pre();
		}
	}

	public void setPusher()
	{
		if (points >= 15)
		this.state = mouseState.PUSHER;
	}

	public void setSlow()
	{
		if (points >= 10)
		this.state = mouseState.SLOW;
	}

	public void setStun()
	{
		if (points >= 20)
			this.state = mouseState.STUN;
	}

	public void StartGame()
	{
		started = true;
		Instantiate (scientist, new Vector3 (-9, -3, 0), Quaternion.identity);
		this.time = 15;
		this.timeBar.minValue = 0;
		this.timeBar.maxValue = time;
		this.timeBar.value = time;
		this.timeText.text = time.ToString ();
	}

	void Game()
	{
		this.timeBar.value = time;
		this.timeText.text = ((int)time).ToString ();
	}

	void Pre()
	{
		this.mousePosition = Input.mousePosition;
		this.objectPosition = Camera.main.ScreenToWorldPoint (mousePosition);
		this.pointText.text = "Points: " + points.ToString ();

		if (tooltip != null)
			tooltip.transform.position = new Vector2(mousePosition.x + tooltip.GetComponent<RectTransform>().rect.width/2 + 10, mousePosition.y - tooltip.GetComponent<RectTransform>().rect.height/2 - 10);

		switch (this.state) 
		{
		case mouseState.NONE:
			Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
			break;
		case mouseState.PUSHER:
			Cursor.SetCursor(cursorTexture[0], Vector2.zero, CursorMode.Auto);
			if (Input.GetMouseButtonDown (0)) 
			{
				Instantiate (robo [0], new Vector3 (objectPosition.x, objectPosition.y, 0), Quaternion.identity);
				points -= 15;
				this.state = mouseState.NONE;
			}
			break;
		case mouseState.SLOW:
			Cursor.SetCursor(cursorTexture[1], Vector2.zero, CursorMode.Auto);
			if (Input.GetMouseButtonDown (0)) 
			{
				Instantiate (robo [1], new Vector3 (objectPosition.x, objectPosition.y, 0), Quaternion.identity);
				points -= 10;
				this.state = mouseState.NONE;
			}
			break;
		case mouseState.STUN:
			Cursor.SetCursor(cursorTexture[2], Vector2.zero, CursorMode.Auto);
			if (Input.GetMouseButtonDown (0)) 
			{
				Instantiate (robo [2], new Vector3 (objectPosition.x, objectPosition.y, 0), Quaternion.identity);
				points -= 20;
				this.state = mouseState.NONE;
			}
			break;
		}
	}

	public void tooltipEnter(GameObject r)
	{
		if (this.state == mouseState.NONE) 
		{
			textName.text = r.name;
			textDesc.text = r.GetComponent<Robo> ().description;
			textCost.text = "Cost: " + r.GetComponent<Robo> ().cost.ToString ();
		}
	}

	IEnumerator decrease()
	{
		while (true) 
		{
			yield return new WaitForSeconds (0.1f);
			time -= 0.1f;
		}
	}
}
