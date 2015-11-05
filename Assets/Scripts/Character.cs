using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour
{
    [SerializeField] private CharacterType _characterType;
    [SerializeField] private Mesh[] _meshs = new Mesh[4];
	[SerializeField] private Material[] _materials = new Material[4];
	[SerializeField] private bool _taged;
    private MeshFilter _meshFilter;
    private Renderer _renderer;
	public float _angle;

    public CharacterType CharacterType
    {
        set { _characterType = value; }
    }

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
				gameObject.transform.parent.GetComponent<Player>().CharacterCollison(collision.gameObject.GetComponent<Character>());
		}
	}
}
