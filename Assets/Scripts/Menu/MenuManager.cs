using UnityEngine;
using System.Collections;

public enum MenuState {Main, Controls, Ready, Game};

public class MenuManager : MonoBehaviour
{
    private MenuState _menuState;
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _controls;
    [SerializeField] private GameObject _ready;
    [SerializeField] private GameObject _game;

    private void Update()
    {
        switch (_menuState)
        {
            case MenuState.Main:
                break;
            case MenuState.Controls:
			if(Input.GetButtonDown("Fire1"))
                {
                    SetMain();
                }
                break;
        }
    }

	private void Awake ()
    {
        ChangeState(MenuState.Main);
	}

    private void ChangeState(MenuState newState)
    {
        _main.SetActive(false);
        _controls.SetActive(false);
        _ready.SetActive(false);
        _game.SetActive(false);

        if(newState == MenuState.Main)
        {
            _menuState = MenuState.Main;
            _main.SetActive(true);
        }
        else if(newState == MenuState.Controls)
        {
            _menuState = MenuState.Controls;
            _controls.SetActive(true);
        }
        else if(newState == MenuState.Ready)
        {
            _menuState = MenuState.Ready;
            _ready.SetActive(true);
        }
        else if(newState == MenuState.Game)
        {
            _menuState = MenuState.Game;
            _game.SetActive(true);
        }
    }

    public void SetMain()
    {
        ChangeState(MenuState.Main);
    }

    public void SetControls()
    {
        ChangeState(MenuState.Controls);
    }

    public void SetReady()
    {
        ChangeState(MenuState.Ready);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
         //Application.LoadLevel("level_2");
        ChangeState(MenuState.Game);
    }
}
