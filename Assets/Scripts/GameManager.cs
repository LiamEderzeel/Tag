using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	[SerializeField] private GameObject _tagger;
	[SerializeField] private GameObject[] _spawns = new GameObject[4];
	public GameObject _player;
    private int _playerAmount = 4;
    private List<GameObject> _players = new List<GameObject>();

	private void Awake ()
	{
        bool hand = false;
        bool big = false;
        bool fast = false;
        bool small = false;
		GlobalVars.GetSingleton ();
        _player = Resources.Load("Prefabs/Player") as GameObject;
        for(int i = 0; i < _playerAmount; ++i)
        {
            GameObject player = Instantiate(_player, _spawns[i].transform.position, Quaternion.identity) as GameObject;
            player.gameObject.GetComponent<PlayerMovement>().Controller = i;
            _players.Add(player);
            bool uniceRol = false;
            bool roleSelected = false;
            CharacterType selectedType = CharacterType.Null;
            selectedType = SelectType();
            while(!uniceRol)
            {
                Debug.Log("hand " + hand + " big " + big + " fast " + fast + " small " + small);
                if(!roleSelected)
                {
                    if(selectedType == CharacterType.Hand && hand == false)
                    {
                        Debug.Log("Hand");
                        player.gameObject.GetComponent<Player>().Taged = true;
                        hand = true;
                        roleSelected = true;
                    }
                    else if(selectedType == CharacterType.Big && big == false)
                    {
                        Debug.Log("Big");
                        big = true;
                        roleSelected = true;
                    }
                    else if(selectedType == CharacterType.Fast && fast == false)
                    {
                        Debug.Log("Fast");
                        fast = true;
                        roleSelected = true;
                    }
                    else if(selectedType == CharacterType.Small && small == false)
                    {
                        Debug.Log("Small");
                        small = true;
                        roleSelected = true;
                    }
                    else
                    {
                        Debug.Log("again!");
                        selectedType = SelectType();
                    }
                }
                else
                {
                    player.gameObject.GetComponent<Player>().CharacterType = selectedType;
                    uniceRol = true;
                }
            }
        }
	}

    private CharacterType SelectType()
    {
        int random = (int)Random.Range(0f, 100f);
        if(random < 25)
        {
             return CharacterType.Hand;
        }
        else if( random > 25 && random < 50)
        {
            return CharacterType.Big;
        }
        else if( random > 50 && random < 75)
        {
            return CharacterType.Fast;
        }
        else
        {
            return CharacterType.Small;
        }
    }

    void Start ()
    {
		//_player1 = GameObject.Find("Player");
		//_player2 = GameObject.Find("Player2");
        for(int i = 0; i < _players.Count; ++i)
        {
		_players[i].GetComponent<Player>()._newTagger += newTagger;
        }
    }

	void newTagger( Player theTagger )
	{
		Debug.Log ("IT'S A TAGGER! " + theTagger.gameObject.name);
		_tagger = theTagger.gameObject;
		theTagger.Tag();
    }
}
