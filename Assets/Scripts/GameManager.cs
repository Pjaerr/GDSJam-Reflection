using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    bool[] targetHits = new bool[2];
	public GameObject Player;

	public Transform startPos;
	[SerializeField] private GameObject popUpUI;
	
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

	public void enablePopUpUI(bool state)
	{
		popUpUI.SetActive(state);
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

        if (targetHits[0] && targetHits[1])
        {
            //Do end level stuff.
            Debug.Log("Door Open!");
        }
	}

	public void nextLevel()
	{
		
	}
}


