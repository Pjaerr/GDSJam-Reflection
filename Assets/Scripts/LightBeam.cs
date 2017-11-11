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
		lineRenderer.positionCount = 2;

		playerScript = GameManager.instance.Player.GetComponent<PlayerController>();
	}

	int lineNumber = 0;

	void Update()
	{
		previousHitPoint = trans.position;
		lineNumber = 0;
		lineRenderer.positionCount = 2;
		TheReflectionDetectionFunction(trans.right);
	}

	Vector3 previousHitPoint;

	void TheReflectionDetectionFunction(Vector3 direction)
	{
		
		//Sets the start position of our laser to the initial objects position
		lineRenderer.SetPosition(lineNumber, previousHitPoint);

		//Fires a raycast from start positon to the right.
		RaycastHit hit;
		if (Physics.Raycast(previousHitPoint, direction, out hit))
		{
			lineNumber++;

			if (lineNumber < 10)
			{
				/*Stops the raycast (which controls where the line goes) when it collides with
				a gameobject tagged as "Obstacle".*/
				if (hit.collider.tag == "Obstacle")
				{
					lineRenderer.SetPosition(lineNumber, hit.point);
				}

				if (hit.collider.tag == "Mirror")
				{
					lineRenderer.positionCount += 1;
					lineRenderer.SetPosition(lineNumber, hit.point);

					Vector3 pos = Vector3.Reflect(hit.point - previousHitPoint, hit.normal) * maxDistance + hit.point;
					lineRenderer.SetPosition(lineNumber + 1, pos);
					previousHitPoint = hit.point;

					TheReflectionDetectionFunction(pos);
				}
			}
			
		}
		else
		{
			lineRenderer.SetPosition(lineNumber, previousHitPoint * maxDistance);
		}
	}
}