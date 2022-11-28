using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
	[SerializeField] GameObject _deadCanvas;

	private static UIManager _instance;

	public static UIManager Instance { get => _instance; set => _instance = value; }

	// Start is called before the first frame update
	void Start()
	{
		if (_instance == null && _instance != this)
		{
			_instance = this;
		}
	}

	public void ShowDeadCanvas()
	{
		_deadCanvas.SetActive(true);
		Time.timeScale = 0;
	}

}
