using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	private static GameManager _instance;
	private string _mainMenuScene = "MainMenu";

	public static GameManager Instance { get => _instance; set => _instance = value; }

	// Start is called before the first frame update
	void Awake()
	{
		if (_instance == null && _instance != this)
		{
			_instance = this;
		}
	}

	private void Start()
	{
		Init();
	}

	private void Init()
	{
		Time.timeScale = 1;
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void ExitToMainMenu()
	{
		SceneManager.LoadScene(_mainMenuScene);
	}

}
