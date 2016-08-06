using UnityEngine;
using System.Collections;

public abstract class Robo : MonoBehaviour 
{
	public int cooldown;
	public float range;
	public AudioSource audioSource;
	public GameObject target;

	public enum STATE
	{
		IDLE,
		COOLDOWN,
		WALK,
		JUMP,
		STUN
	};
}
