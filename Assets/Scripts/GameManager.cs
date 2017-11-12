using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	[SerializeField] private bool isSingleLine = false;
    bool[] targetHits = new bool[2];
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

	void Start()
	{
		if (isSingleLine) 
		{
			targetHits[1] = true;
		}

	}

	public void openDoor(int mirrorNumber)
	{
        if (mirrorNumber == 0)
        {
            targetHits[0] = true;
        }
        else if (mirrorNumber == 1)
        {
            targetHits[1] = true;
        }
			
		if (targetHits [0] && targetHits [1]) 
		{
			//Do end level stuff.
			Debug.Log ("Door Open!");
		} 
	}

	public void nextLevel()
	{
		
	}
}


