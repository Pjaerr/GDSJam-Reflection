﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	Transform trans; //Cached reference to this object's transform.
	[SerializeField] float movementSpeed; //Movement Speed, adjustable in the editor.

	void Start()
	{
		trans = GetComponent<Transform>(); //Stores reference to this object's transform.
	}

	//Update() is called every frame.
	void Update()
	{
		Movement();
	}
	

	void Movement()
	{
		float step = movementSpeed * Time.deltaTime; //Stores movementspeed * deltatime to keep movement non-fps dependant.

		/*Checks for WASD, and increases or decreases x/y by 1, and then translates this player by those amounts
		multiplied by the step created above.*/
		
		/*
		float angleX = Mathf.Cos(30);
		float angleY = Mathf.Sin(45);*/

		float x = 0;
		float y = 0;

		if (Input.GetKey(KeyCode.D))
		{
			y += 1;
		}
		if (Input.GetKey(KeyCode.A))
		{
			y -= 1;
		}
		if (Input.GetKey(KeyCode.S))
		{
			x -= 1;
		}
		if (Input.GetKey(KeyCode.W))
		{
			x += 1;
		}

		trans.Translate(new Vector3(x * step, y * step));
	}

	public void KillPlayer()
	{
		trans.position = GameManager.instance.startPos.position;
	}
	
}