using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	[SerializeField] private bool isSingleLine = false;
    bool[] targetHits = new bool[2];
	public GameObject Player;

	public Transform startPos;
	[SerializeField] private GameObject popUpUI;
	[SerializeField] private GameObject endImage;

	public Door doorScript;
	
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
		
	}
			
	public void enablePopUpUI(bool state)
	{
		popUpUI.SetActive(state);
	}


	public void openDoor(int mirrorNumber)
	{
		for (int i = 0; i < targetHits.Length; i++) 
		{
			targetHits [i] = false;
		}

		if (isSingleLine) 
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
			
		if (targetHits [0] && targetHits [1]) 
		{
			//Show ui.
			Debug.Log("YTOU EI4RNBGERIUHE");
			doorScript.open (true);
		} 
		else if (targetHits [0]) 
		{
			doorScript.open (true);
		}

	}

	public void closeDoor()
	{
		doorScript.open (false);
	}

	public void nextLevel()
	{
		endImage.SetActive (true);
		Time.timeScale = 0;
	}


	public void launchGame(int scene)
	{
		SceneManager.LoadScene (scene);
	}
}


