using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum MenuMainState {Play = 0, Controls = 1, Quit = 1};

public class MenuMain : MonoBehaviour
{
    [SerializeField] private MenuManager _menuManager;
    private MenuMainState _menuMainState;
    [SerializeField] private Sprite[] _sprites= new Sprite[6];
    [SerializeField] private Image[] _images= new Image[3];
    private bool input = true;

    private void Awake ()
    {
        _menuMainState = MenuMainState.Play;
    }

    private void Update ()
    {

        if(Input.GetButtonDown("A1") || Input.GetButtonDown("A2") || Input.GetButtonDown("A3") || Input.GetButtonDown("A4"))
        {
            if(_menuMainState == MenuMainState.Play)
            {
                _menuManager.SetReady();
            }
            else if(_menuMainState == MenuMainState.Controls)
            {
                _menuManager.SetControls();
            }
            else if(_menuMainState == MenuMainState.Quit)
            {
                _menuManager.Quit();
            }
        }

        if(input)
        {
            StartCoroutine(WaitControlles(0.5f));
            if(Input.GetAxis("Vertical") > 0)
            {
                ChangeState(_menuMainState, true);
            }
            if(Input.GetAxis("Vertical") < 0)
            {
                ChangeState(_menuMainState, false);
            }
        }
    }

    private  void ChangeState( MenuMainState lastState, bool up)
    {
        int nextState = 0;
        int previousState = 0;

        if((int)lastState == 0)
        {
            nextState = 2;
            previousState = 1;
        }
        else if((int)lastState == 1)
        {
            nextState = 0;
            previousState = 2;
        }
        else if((int)lastState == 2)
        {
            nextState = 1;
            previousState = 0;
        }

        if(up)
        {
            _menuMainState = (MenuMainState)nextState;
        }
        else
        {
            _menuMainState = (MenuMainState)previousState;
        }
        UpdateSprites();
    }

    private void UpdateSprites()
    {
        for(int i = 0; i < _images.Length; ++i)
        {
            if((int)_menuMainState == i)
            {
                _images[i].sprite = _sprites[i];
            }
            else
            {
                _images[i].sprite = _sprites[i+3];
            }
        }
    }

    private IEnumerator WaitControlles(float sec)
    {
        input = false;
        yield return new WaitForSeconds(sec);
        input = true;
    }
}

