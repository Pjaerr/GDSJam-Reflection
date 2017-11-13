using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mirror : MonoBehaviour 
{
	private Transform trans;
	[SerializeField] private float turnSpeed;

	private bool playerIsTouching = false;

	void Start()
	{
		trans = GetComponent<Transform>();
	}

	void TurnMirror(int direction)
	{
		if (direction == 0)
		{
			trans.Rotate(new Vector3(0, 0, 1), -turnSpeed * Time.deltaTime);
		}
		else if (direction == 1)
		{
			trans.Rotate(new Vector3(0, 0, 1), turnSpeed * Time.deltaTime);
		}
		
	}

	void Update()
	{
		if (playerIsTouching)
		{
			if (Input.GetKey(KeyCode.LeftArrow))
			{
				TurnMirror(0);
			}
			else if (Input.GetKey(KeyCode.RightArrow))
			{
				TurnMirror(1);
			}
		}
	}

	//Enable the arrow keys UI when in range of the mirror.
	void showUI(bool state)
	{
		GameManager.instance.ui.enablePopUpUI(state);
	}


	void OnTriggerEnter(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			playerIsTouching = true;
			showUI(playerIsTouching);
		}
	}
	void OnTriggerExit(Collider col)
	{
		if (col.gameObject.tag == "Player")
		{
			playerIsTouching = false;
			showUI(playerIsTouching);
		}
	}
}
