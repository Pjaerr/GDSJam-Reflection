using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour 
{
    [SerializeField] private int id = 0;
	private LineRenderer lineRenderer;
	private Transform trans;
	PlayerController playerScript; //Reference to player functions and variables.

	/*hit holds collision info and ray holds ray origin and direction.*/
	RaycastHit hit;
	Ray ray;

	List<Vector3> origins = new List<Vector3>(); //List containing all generated ray.origins.

	void Start()
	{
		trans = GetComponent<Transform>(); //Reference to Transform cached.
		lineRenderer = GetComponent<LineRenderer>(); //Reference to Transform cached.
		playerScript = GameManager.instance.Player.GetComponent<PlayerController>();
	}

	

	void Update()
	{
		origins.Clear(); //Clears the list of origins.
		ray = new Ray(trans.position, trans.right); //Generates the initial ray.
		//Debug.DrawRay(trans.position,trans.right * 100, Color.magenta);  
		TheReflectionDetectionFunction(); //Makes the initial call.
		drawLines(); //Draws all lines at the origins that were generated recursively acting as vertices.
	}

	void drawLines()
	{
		lineRenderer.positionCount = origins.Count;

		for (int i = 0; i < lineRenderer.positionCount; i++)
		{
			lineRenderer.SetPosition(i, origins[i]);
		}
	}


	
	void TheReflectionDetectionFunction()
	{
		origins.Add(ray.origin); //Adds the first origin to the list.

		//Fires a raycast from the ray origin to the ray direction.
		if (Physics.Raycast(ray.origin, ray.direction, out hit))
		{

			if (hit.collider.tag == "Target") 
			{
				GameManager.instance.openDoor (id);
				origins.Add (hit.point);
			}

			if (hit.collider.tag == "Player")
			{
				GameManager.instance.closeDoor ();
				playerScript.KillPlayer();
			}

			//If the raycast hits an obstacle. Set the current origin to hit.point.
			if (hit.collider.tag == "Obstacle" || hit.collider.tag == "Door")
			{
				GameManager.instance.closeDoor ();
				origins.Add(hit.point);
			}

			if (hit.collider.tag == "Mirror")
			{
				//The direction at which the ray hits a mirror reflected by comparing it to the normal of the mirror.
				Vector3 inDirection = Vector3.Reflect(ray.direction, hit.normal);

				//Creates a new ray with an origin of the current hit point, going in the reflected direction.
				ray = new Ray(hit.point, inDirection);  

				//Draw the normal - can only be seen at the Scene tab, for debugging purposes  
				//Debug.DrawRay(hit.point, hit.normal*3, Color.blue);  
				//represent the ray using a line that can only be viewed at the scene tab  
				//Debug.DrawRay(hit.point, inDirection*100, Color.magenta); 

				TheReflectionDetectionFunction();
			}
		}
	}
}