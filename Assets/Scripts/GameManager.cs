using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public enum GameState {Menu, Game}
	private static GameState _gameState;
	public string _selectedLevel = "level_1";
	
	void Awake () {

	}

	void Update () {
		//switch(_gameState)
		//{
		//case GameState.Menu:
		//	break;
		//case GameState.Game:
		//	break;
		//}
	}

	public void ToMenu ()
	{
		ResetState();
		//_menuTicket.SetActive(true);
	}
	
	public void ToGame ()
	{
		ResetState();
		Application.LoadLevel(_selectedLevel);
	}
	
	private static void ResetState()
	{
		//_menuMain.SetActive(false);
		//_menuTicket.SetActive(false);
		//_menuInfo.SetActive(false);
	}
}
