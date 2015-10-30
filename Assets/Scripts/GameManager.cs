using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    private GameObject _tagger;
	private GameObject _player1;
    void Start ()
    {
		_player1 = gameObject.Find("Fast");
		_player1.GetComponent<Character>()._newTagger += SomeEnemyDied;
    }

    void Update ()
    {
    }
	void SomeEnemyDied( Character theTagger )
	{
		Debug.Log ("IT'S A TAGGER!");
    }
}
