using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public string mainSceneName;
    public string GameSceneName;
    public UIManager uiManager;
    private Ball ball;
    public static GameManager instance
	{
		get
		{
			return _instance;
		}
	} 

    void Awake()
	{
		if (_instance == null)
		{
			_instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			if (_instance != this)
				Destroy(gameObject);
		}
	}
    // Start is called before the first frame update
    void Start()
    {
        LoadMainMenu();
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(mainSceneName);
        uiManager.OnMainMenu();
    }
    public void NewGame()
    {
        uiManager.OnGame();
        loadGameScene();
    }
    public void loadGameScene()
    {
        uiManager.OnGame();
        GameSceneName = "level 1";
        SceneManager.LoadScene(GameSceneName);
    }
    public void Quit()
    {
        Application.Quit();
    }
    void StartGameAt()
    {
        //starts new game
        loadGameScene();
    }

    public void LoadLevelSelect()
    {
        SceneManager.LoadScene(mainSceneName);
        uiManager.OnLevelSelect();
    }
    public void Restart()
    {
        GameSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(GameSceneName);
    }

    public void NextLevel()
    {
        GameSceneName = SceneManager.GetActiveScene().name;
        string[] temp = GameSceneName.Split(" "[0]);
        int level = int.Parse(temp[1]);
        level++;
        GameSceneName = temp[0] + " " + level;
        if(GameSceneName == "Level 11")
        {
            GameSceneName = "Main Menu";
        }
        loadGameScene();
    }

    public void Level1()
    {
        GameSceneName ="level 1";
        loadGameScene();
    }
    public void Level2()
    {
        GameSceneName ="level 2";
        loadGameScene();
    }
    public void Level3()
    {
        GameSceneName ="level 3";
        loadGameScene();
    }
    public void Level4()
    {
        GameSceneName ="level 4";
        loadGameScene();
    }
    public void Level5()
    {
        GameSceneName ="level 5";
        loadGameScene();
    }
    public void Level6()
    {
        GameSceneName ="level 6";
        loadGameScene();
    }
    public void Level7()
    {
        GameSceneName ="level 7";
        loadGameScene();
    }
    public void Level8()
    {
        GameSceneName ="level 8";
        loadGameScene();
    }
    public void Level9()
    {
        GameSceneName ="level 9";
        loadGameScene();
    }
    public void Level10()
    {
        GameSceneName ="level 10";
        loadGameScene();
    }    
}
