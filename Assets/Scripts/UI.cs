using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{

	//References
	[SerializeField] private GameObject popUpUI;
	[SerializeField] private GameObject pauseMenuMain;
	[SerializeField] private GameObject pauseMenuHelp;
	
	[SerializeField] bool isEndScene = false;

	void Update()
	{
		if (isEndScene)
		{
			if (Input.GetKeyDown(KeyCode.Space)) //Replay Game.
			{
				loadScene(0);
			}
			else if (Input.GetKeyDown(KeyCode.Escape))
			{
				Application.Quit();
			}
		}
	}


	public void exitGame()
	{
		Application.Quit();
	}

	public void togglePauseScreen(bool isOpen)
	{
		pauseMenuMain.SetActive(isOpen);

		if (isOpen)
		{
			Time.timeScale = 0;
		}
		else
		{
			Time.timeScale = 1;
		}
	}

	public void toggleHelpScreen(bool isOpen)
	{
		pauseMenuHelp.SetActive(isOpen);
		pauseMenuMain.SetActive(!isOpen);
	}

	public void loadScene(int buildIndex)
	{
		SceneManager.LoadScene(buildIndex);
	}


	public void enablePopUpUI(bool state)
	{
		popUpUI.SetActive(state);
	}
	
}
