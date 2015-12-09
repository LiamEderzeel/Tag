using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuReady : MonoBehaviour
{
    [SerializeField] private Sprite[] _playerSprites = new Sprite[8];
    [SerializeField] private Sprite[] _nextSprites = new Sprite[2];
    [SerializeField] private Image[] _images = new Image[4];
    [SerializeField] private Image _next;
    [SerializeField] private bool[] _ready = new bool[4];
    [SerializeField] private MenuManager _menuManager;

    void Start ()
    {

        for(int i = 0; i > _images.Length; ++i)
        {
            _images[i].sprite = _playerSprites[i];
        }
    }

    void Update ()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            _menuManager.Play();
        }

        if(_ready[0] && _ready[1] && _ready[2] && _ready[3])
        {
            _next.sprite = _nextSprites[1];
            if(Input.GetButtonDown("A1") || Input.GetButtonDown("A2") || Input.GetButtonDown("A3") || Input.GetButtonDown("A4"))
            {
                _menuManager.Play();
            }
        }
        else
        {
            _next.sprite = _nextSprites[0];
            if(Input.GetButtonDown("A1") && _ready[0] == false)
            {
                Debug.Log("hallo");
                ReadyUp(0);
            }
            if(Input.GetButtonDown("A2") && _ready[1] == false)
            {
                Debug.Log("hallo");
                ReadyUp(1);
            }
            if(Input.GetButtonDown("A3") && _ready[2] == false)
            {
                ReadyUp(2);
            }
            if(Input.GetButtonDown("A4") && _ready[3] == false)
            {
                ReadyUp(3);
            }
        }
        if(Input.GetButtonDown("B1") )
        {
            if(_ready[0] == true)
            {
                UnReady(0);
            }
            else
            {
                _menuManager.SetMain();
            }
        }
        if(Input.GetButtonDown("B2") )
        {
            if(_ready[1] == true)
            {
                UnReady(1);
            }
            else
            {
                _menuManager.SetMain();
            }
        }
        if(Input.GetButtonDown("B3") )
        {
            if(_ready[2] == true)
            {
                UnReady(2);
            }
            else
            {
                _menuManager.SetMain();
            }
        }
        if(Input.GetButtonDown("B4") )
        {
            if(_ready[3] == true)
            {
                UnReady(3);
            }
            else
            {
                _menuManager.SetMain();
            }
        }
    }

    private void ReadyUp(int controller)
    {
        Debug.Log("hallo");
        _ready[controller] = true;
        _images[controller].sprite = _playerSprites[controller+4];
    }

    private void UnReady(int controller)
    {
        Debug.Log("Doei");
        _ready[controller] = false;
        _images[controller].sprite = _playerSprites[controller];
    }
}
