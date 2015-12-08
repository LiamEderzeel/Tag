using UnityEngine;
using System.Collections;

public enum MenuState {Main, Controls};

public class MenuManager : MonoBehaviour
{
    private MenuState _menuState;
    [SerializeField] private GameObject _main;
    [SerializeField] private GameObject _controls;

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
        _menuState = MenuState.Main;
        _controls.SetActive(false);
	}

    private void ChangeState(MenuState newState)
    {
        _main.SetActive(false);
        _controls.SetActive(false);

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
    }

    public void SetMain()
    {
        ChangeState(MenuState.Main);
    }

    public void SetControls()
    {
        ChangeState(MenuState.Controls);
    }
}
