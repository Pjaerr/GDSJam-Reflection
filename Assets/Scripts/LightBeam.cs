using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour 
{
	private LineRenderer lineRenderer;
	private Transform trans;
	[SerializeField] float maxDistance = 5000.0f;
	PlayerController playerScript;

	void Start()
	{
		trans = GetComponent<Transform>();
		lineRenderer = GetComponent<LineRenderer>();
		lineRenderer.positionCount = 3;

		playerScript = GameManager.instance.Player.GetComponent<PlayerController>();
	}

	int lineNumber = 0;

	void Update()
	{
		lineNumber = 0;
		TheReflectionDetectionFunction();
	}

	void TheReflectionDetectionFunction()
	{
		//Sets the start position of our laser to the initial objects position
		lineRenderer.SetPosition(lineNumber, trans.position);

		//Fires a raycast from start positon to the right.
		RaycastHit hit;
		if (Physics.Raycast(trans.position, trans.right, out hit))
		{
			lineNumber++;
			/*Stops the raycast (which controls where the line goes) when it collides with
			a gameobject tagged as "Obstacle".*/
			if (hit.collider.tag == "Obstacle")
			{
				lineRenderer.SetPosition(lineNumber, hit.point);

				while (lineNumber < lineRenderer.positionCount)
				{
					lineNumber++;
					lineRenderer.SetPosition(lineNumber, hit.point);
				}
			}

			if (hit.collider.tag == "Mirror")
			{
				lineRenderer.SetPosition(1, hit.point);

				Vector3 pos = Vector3.Reflect(hit.point - trans.position, hit.normal) * maxDistance + hit.point;
				lineRenderer.SetPosition(2, pos);

				TheReflectionDetectionFunction();
			}
		}
		else
		{
			lineRenderer.SetPosition(lineNumber, hit.point * maxDistance);
		}
	}
}