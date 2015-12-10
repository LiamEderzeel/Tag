using UnityEngine;
using System.Collections;

public enum GameState {Main, Controls, Ready, Game, End, Pauze};

public class MenuManager : MonoBehaviour
{
    private GameState _menuState;
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _controls;
    [SerializeField] private GameObject _ready;
    [SerializeField] private GameObject _game;
    [SerializeField] private GameObject _end;
    [SerializeField] private GameManager _gameManager;
    private bool _pauzed;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Pauze();
        }
        switch (_menuState)
        {
            case GameState.Main:
                break;
            case GameState.Controls:
                if(Input.GetButtonDown("Fire1"))
                {
                    SetMain();
                }
                break;
        }
    }

    private void Awake ()
    {
        _changeState(GameState.Main);
    }

    private void _changeState(GameState newState)
    {
        _main.SetActive(false);
        _controls.SetActive(false);
        _ready.SetActive(false);
        _game.SetActive(false);
        _end.SetActive(false);

        if(newState == GameState.Main)
        {
            _menuState = GameState.Main;
            _main.SetActive(true);
        }
        else if(newState == GameState.Controls)
        {
            _menuState = GameState.Controls;
            _controls.SetActive(true);
        }
        else if(newState == GameState.Ready)
        {
            _menuState = GameState.Ready;
            _ready.SetActive(true);
        }
        else if(newState == GameState.Game)
        {
            _menuState = GameState.Game;
            _game.SetActive(true);
        }
        else if(newState == GameState.End)
        {
            _menuState = GameState.End;
            _end.SetActive(true);
        }
    }

    public void SetMain()
    {
        _changeState(GameState.Main);
    }

    public void SetControls()
    {
        _changeState(GameState.Controls);
    }

    public void SetReady()
    {
        _changeState(GameState.Ready);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        //Application.LoadLevel("level_2");
        //_gameManager.Reset();
        _changeState(GameState.Game);
    }

    public void SetEnd()
    {
        _changeState(GameState.End);
    }

    private void Pauze()
    {
        if(!_pauzed)
        {
            _changeState(GameState.Pauze);
            Debug.Log("Pauze");
            _pauzed = true;
            Time.timeScale = 0;
        }
        else
        {
            _changeState(GameState.Game);
            Debug.Log("UnPauze");
            _pauzed = false;
            Time.timeScale = 1;
        }
    }
}
