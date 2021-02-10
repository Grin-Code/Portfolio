using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
	public GameObject gameMenu;
	public GameObject levelSelect;
	public GameObject nextLevel;
	public GameObject Instructions;


	// Use this for initialization
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			ToggleUI();
		}
	}
    public void ToggleUI()
	{
		gameMenu.SetActive(!gameMenu.activeSelf);
	}
	public void OnMainMenu()
	{
		gameMenu.SetActive(false);
		levelSelect.SetActive(false);
		mainMenu.SetActive(true);
		Instructions.SetActive(false);
	}

	public void OnGame()
	{
		mainMenu.SetActive(false);
		levelSelect.SetActive(false);
		nextLevel.SetActive(false);
	}

	public void OnLevelSelect()
    {
        mainMenu.SetActive(false);
		levelSelect.SetActive(true);
		gameMenu.SetActive(false);
    }
	public void OnLevelFinish()
	{
		nextLevel.SetActive(true);
		mainMenu.SetActive(false);
		levelSelect.SetActive(false);
		gameMenu.SetActive(false);
	}
	public void OnInstructions()
	{
		nextLevel.SetActive(false);
		mainMenu.SetActive(false);
		levelSelect.SetActive(false);
		gameMenu.SetActive(false);
		Instructions.SetActive(true);
	}
}