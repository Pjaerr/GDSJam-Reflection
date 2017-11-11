using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	public GameObject Player;

	public Transform startPos;
	
	public static GameManager instance = null;


	void InitializeSingleton()
	{
		if (instance == null)	//Check if an instance of GameManager already exists.
		{
			instance = this; 	//If not, make this that instance.
		}
		else if (instance != this)	//If an instance already exists and it isn't this.
		{
			Destroy(gameObject);	//Destroy this.
		}
	}

	void Awake()
	{
		InitializeSingleton();
	}
}
