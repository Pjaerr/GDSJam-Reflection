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

		playerScript = GameManager.instance.Player.GetComponent<PlayerController>();
		Vector3 direction = trans.right;
	}

	
	void Update()
	{
		lineRenderer.SetPosition(0, trans.position);

		RaycastHit hit;
		if (Physics.Raycast(trans.position, trans.right, out hit))
		{
			
			if (hit.collider.tag == "Mirror")
			{
				lineRenderer.SetPosition(1, hit.point);

				Reflect(trans.position, hit.point, hit.collider.transform.rotation);
			}
			if (hit.collider.tag == "Obstacle")
			{
				lineRenderer.SetPosition(1, hit.point);
			}
			if (hit.collider.tag == "Player")
			{
				playerScript.KillPlayer();
			}

			if (hit.collider)
			{
				lineRenderer.SetPosition(1, hit.point);
			}
		}
		else
		{
			lineRenderer.SetPosition(1, trans.right * maxDistance);
		}
	}

	void Reflect(Vector3 startPoint, Vector3 endPoint, Quaternion rotation)
	{
		Debug.Log("EndPoint: " + endPoint + " , Rotation: " + rotation.eulerAngles);

		RaycastHit hit;
		if (Physics.Raycast(endPoint, new Vector3(-endPoint.x, -endPoint.y + 10, -endPoint.z), out hit))
		{
			if (hit.collider.tag == "Mirror")
			{
				lineRenderer.SetPosition(1, hit.point);
				Reflect(hit.point, hit.collider.transform.rotation);
			}
			if (hit.collider.tag == "Obstacle")
			{
				lineRenderer.SetPosition(1, hit.point);
			}
			if (hit.collider.tag == "Player")
			{
				playerScript.KillPlayer();
			}
		}
		else
		{
			lineRenderer.SetPosition(1, direction * maxDistance);
		}
	}
}
