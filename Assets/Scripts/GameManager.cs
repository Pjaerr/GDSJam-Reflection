using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	//References
	public GameObject Player;
	public Transform startPos;
	public Door doorScript;
	[HideInInspector] public UI ui;

	//Variables
	[SerializeField] private bool isSingleLine = false; 	//I WILL CREATE A BETTER SOLUTION THAT IS EFFICIENT - JOSH J.
    private bool[] targetHits = new bool[2];
	
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
		ui = GetComponent<UI>();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ui.togglePauseScreen(true);
		}
	}
			
	
	public void openDoor(int mirrorNumber)
	{
		for (int i = 0; i < targetHits.Length; i++) 
		{
			targetHits [i] = false;
		}

		if (isSingleLine) //I WILL CREATE A BETTER SOLUTION THAT IS EFFICIENT - JOSH J.
		{
			targetHits[1] = true;
		}

        if (mirrorNumber == 0)
        {
            targetHits[0] = true;
        }
        else if (mirrorNumber == 1)
        {
            targetHits[1] = true;
        }
			
		if (targetHits [0] && targetHits [1])  //If both lights are inside of a target.
		{
			doorScript.open (true);
		} 

	}

	public void closeDoor() //Used in external scripts to access the door functionality.
	{
		doorScript.open (false);
	}

	public void nextLevel()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
	}
}


