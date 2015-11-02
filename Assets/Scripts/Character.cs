using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum CharacterType {Hand=0, Fat=1, Fast=2, Small=3};

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType _characterType;
    [SerializeField] private Mesh[] _meshs = new Mesh[4];
	[SerializeField] private Material[] _materials = new Material[4];
	[SerializeField] private bool _taged;
    private MeshFilter _meshFilter;
    private Renderer _renderer;
	public float _angle;

	public bool Taged
	{
		set { _taged = value; }
	}

    private void Awake ()
    {
        _meshFilter = this.gameObject.GetComponent<MeshFilter>();
        _renderer = this.gameObject.GetComponent<Renderer>();
    }

    private void Start ()
    {
        if(_taged)
        {
            _characterType = CharacterType.Hand;
        }
		_meshFilter.mesh = _meshs[(int)_characterType];
		_renderer.material = _materials[(int)_characterType];
    }

	private void Update()
	{
		this.gameObject.transform.eulerAngles = new Vector3(0, _angle, 0);
	}

    public void Tag()
    {
        Taged = true;
		_meshFilter.mesh = _meshs[(int)_characterType];
		_renderer.material = _materials[(int)_characterType];
    }

	private void OnCollisionEnter (Collision collision)
	{
		if(collision.gameObject.GetComponent<Character>() != null)
		{

			if(_taged)
			{
				Debug.Log(gameObject.transform.parent.name);
				gameObject.transform.parent.GetComponent<Player>().CharacterCollison(collision.gameObject.GetComponent<Character>());
			}
		}
	}
}
