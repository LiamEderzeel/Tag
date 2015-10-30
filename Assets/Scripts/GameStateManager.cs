using UnityEngine;
using System.Collections;

public class GameStateManager : MonoBehaviour {

	public enum GameState {Menu, Game}
	private static GameState _gameState;
	public string _selectedLevel = "level_1";

	private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
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
}
