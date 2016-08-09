using UnityEngine;
using System.Collections;

public abstract class Robo : MonoBehaviour 
{
	public int cooldown, cost;
	public float range;
	public AudioSource audioSource;
	public GameObject target;
	public string description;

	public enum STATE
	{
		IDLE,
		COOLDOWN,
		WALK,
		JUMP,
		STUN
	};

	public string getText()
	{return description;}

	public string getCost()
	{return cost.ToString();}
}
