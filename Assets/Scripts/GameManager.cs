using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	[SerializeField] private Player _tagger;
	[SerializeField] private GameObject[] _spawns = new GameObject[4];
	public GameObject _player;
    private int _playerAmount = 4;
    public List<GameObject> _players = new List<GameObject>();

	private void Awake ()
	{
		GlobalVars.GetSingleton ();
        _player = Resources.Load("Prefabs/Player") as GameObject;
        GiveRole();
		foreach (GameObject p in _players)
		{
			p.GetComponent<Abilities>().FillPlayerList(_players);
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

    private void Start ()
    {
        for(int i = 0; i < _players.Count; ++i)
        {
		_players[i].GetComponent<Player>()._newTagger += newTagger;
        }
    }

	private void newTagger( Player theTagger )
	{
        _tagger = theTagger;
        GiveRole2();
        for(int j = 0; j < _players.Count; ++j)
        {
            if(_players[j].name == theTagger.gameObject.name)
            {
                if(_tagger == _players[j].GetComponent<Player>())
                {
                }
            }
        }
    }
	


    private void GiveRole ()
    {
        bool hand = false;
        bool big = false;
        bool fast = false;
        bool small = false;
        for(int i = 0; i < _playerAmount; ++i)
        {
            if(_players.Count <= _playerAmount - 1)
            {
                GameObject player = Instantiate(_player, _spawns[i].transform.position, Quaternion.identity) as GameObject;
                player.gameObject.GetComponent<PlayerMovement>().Controller = i;
                player.name = "player"+i;
				//player.AddComponent<Abilities>();
                _players.Add(player);
            }
            bool uniceRol = false;
            bool roleSelected = false;
            CharacterType selectedType = CharacterType.Null;
            selectedType = SelectType();
            while(!uniceRol)
            {
                if(!roleSelected)
                {
                    if(_tagger == _players[i] || (_tagger == null && selectedType == CharacterType.Hand && hand == false))
                    {
                        _players[i].gameObject.GetComponent<Player>().Taged = true;
                        hand = true;
                        roleSelected = true;
                    }
                    else if(selectedType == CharacterType.Big && big == false)
                    {
                        big = true;
                        roleSelected = true;
                    }
                    else if(selectedType == CharacterType.Fast && fast == false)
                    {
                        fast = true;
                        roleSelected = true;
                    }
                    else if(selectedType == CharacterType.Small && small == false)
                    {
                        small = true;
                        roleSelected = true;
                    }
                    else
                    {
                        selectedType = SelectType();
                    }
                }
                else
                {
                    _players[i].gameObject.GetComponent<Player>().CharacterType = selectedType;
					_players[i].gameObject.GetComponent<Abilities>().CharacterType = selectedType;
                    uniceRol = true;
                }
            }
        }
    }

    private void GiveRole2 ()
    {
        bool hand = false;
        bool big = false;
        bool fast = false;
        bool small = false;
        for(int i = 0; i < _players.Count; ++i)
        {
            _players[i].transform.position = _spawns[i].transform.position;
            bool uniceRol = false;
            bool roleSelected = false;
            CharacterType selectedType = CharacterType.Null;
            selectedType = SelectType();
            while(!uniceRol)
            {
                if(!roleSelected)
                {
                    if(selectedType == CharacterType.Hand && hand == false)
                    {
                        hand = true;
                        roleSelected = true;
						_players[i].gameObject.GetComponent<Player>().Taged = true;
                    }
                    else if(selectedType == CharacterType.Big && big == false)
                    {
                        big = true;
                        roleSelected = true;
                    }
                    else if(selectedType == CharacterType.Fast && fast == false)
                    {
                        fast = true;
                        roleSelected = true;
                    }
                    else if(selectedType == CharacterType.Small && small == false)
                    {
                        small = true;
                        roleSelected = true;
                    }
                    else
                    {
                        selectedType = SelectType();
                    }
                }
                else
                {
                    _players[i].gameObject.GetComponent<Player>().CharacterType = selectedType;
					_players[i].gameObject.GetComponent<Abilities>().CharacterType = selectedType;
					_players[i].gameObject.GetComponent<Player>().NewModel();
                    uniceRol = true;
                }
            }
        }
    }

	public List<GameObject> Players
	{
		get{return _players;}
	}
}
