using UnityEngine;
using System.Collections;

public delegate void Tagger(Player theTagger);
public enum CharacterType {Null=-1, Hand=0, Big=1, Fast=2, Small=3};

public class Player : MonoBehaviour
{
    [SerializeField] private bool _taged;
    [SerializeField] private CharacterType _characterType;
    public event Tagger _newTagger;
    private CollisionFlags m_CollisionFlags;
    private Transform _transform;
    private Renderer _renderer;
    private GameObject _character;

    public CharacterType CharacterType
    {
        get { return _characterType; }
        set { _characterType = value; }
    }

    public bool Taged
    {
        set { _taged = value; }
    }

    private void Awake ()
    {
        GameObject character = Resources.Load("Prefabs/Character") as GameObject;
        _character = Instantiate(character, gameObject.transform.position, Quaternion.identity) as GameObject;
        _character.transform.parent = gameObject.transform;
        //_character = this.gameObject.transform.GetChild(0).gameObject;
        if(_taged)
        {
            _character.GetComponent<Character>().Taged = true;
        }
    }

    private void Start ()
    {
        _character.GetComponent<Character>().CharacterType = _characterType;
        _transform = GetComponent<Transform>();
        _renderer = GetComponent<Renderer>();
    }

    public void CharacterCollison(Character theCharacter)
    {
        if (_taged)
        {
            if(_newTagger != null)
            {
                _newTagger (theCharacter.gameObject.transform.parent.GetComponent<Player>());
                //theCharacter.gameObject.transform.parent.GetComponent<Player>().Tag();
                Debug.Log (theCharacter.gameObject.name);
                UnTag();
            }
        }
    }

    public void Tag ()
    {
        _taged = true;
        _character.GetComponent<Character>().Tag();
    }

    public void UnTag ()
    {
        _taged = false;
        _character.GetComponent<Character>().Taged = false;
    }
}

