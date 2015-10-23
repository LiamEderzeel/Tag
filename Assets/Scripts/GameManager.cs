using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum GameState {Menu, Game}
	private static GameState _gameState;
	private string _selectedLevel = "level_1";
    private Dropdown _levelSelect;

	private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        _levelSelect = GameObject.Find("LevelSelect").GetComponent<Dropdown>();
	}

	private void Update()
    {
		//_menuTicket.SetActive(true);
	}

	private void _changeState(GameState newGameState)
	{
		//_menuTicket.SetActive(false);
        if(newGameState == GameState.Menu)
        {
        }
        else if(newGameState == GameState.Game)
        {
            Application.LoadLevel(_selectedLevel);
        }
	}

    public void ToGame()
    {
        _changeState(GameState.Game);
    }

    public void SelectLevel()
    {
        if(_levelSelect.value == 0)
        {
            _selectedLevel = "level_1";
        }
        else if(_levelSelect.value == 1)
        {
            _selectedLevel = "level_2";
        }
        else if(_levelSelect.value == 2)
        {
            _selectedLevel = "level_3";
        }
    }
}
