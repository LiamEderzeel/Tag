using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerManager : MonoBehaviour {

    public static float Score1
    {
        get{ return _scorePlayer1 ;}
    }

    private static float _scorePlayer1, _scorePlayer2, _scorePlayer3, _scorePlayer4;
    private Player[] _players = new Player[4];
    private Slider[] _sliders = new Slider[4];

	void Awake ()
    {
        _players[0] = GameObject.Find("Player1").GetComponent<Player>();
        _players[1] = GameObject.Find("Player2").GetComponent<Player>();
        _players[2] = GameObject.Find("Player3").GetComponent<Player>();
        _players[3] = GameObject.Find("Player4").GetComponent<Player>();

        _sliders[0] = GameObject.Find("Slider1").GetComponent<Slider>();
        _sliders[1] = GameObject.Find("Slider2").GetComponent<Slider>();
        _sliders[2] = GameObject.Find("Slider3").GetComponent<Slider>();
        _sliders[3] = GameObject.Find("Slider4").GetComponent<Slider>();
	}

	void Update ()
    {

	}
}
