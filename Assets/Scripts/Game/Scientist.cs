using UnityEngine;
using UnityEngine.SceneManagement;

public class Scientist : MonoBehaviour
{
    public float speed = 0.05f;
    bool walking;

    private Transform target;
    private int waypointIndex = 0;

	void Start()
	{
		this.walking = true;
        target = Waypoints.points[0];
	}

    void Update()
    {
        Vector2 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, target.position) <= 0.02f)
        {
            GetNextWaypoint();
            
        }
    }

    void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag.Equals ("exit")) 
		{
			SceneManager.LoadScene ("Menu");			
		}				
	}
}
