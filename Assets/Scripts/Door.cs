using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour 
{
	Animator anim;
	bool doorisOpen = false;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	public void open(bool openDoor)
	{
		if (openDoor) 
		{
			anim.SetTrigger ("DoorAnimStart");
			doorisOpen = true;
		}

		if (doorisOpen) 
		{
			if (!openDoor)
			{
				anim.SetTrigger ("DoorAnimClose");
				doorisOpen = false;
			}
		}


	}

}
