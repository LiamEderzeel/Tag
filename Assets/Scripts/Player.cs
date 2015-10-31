using UnityEngine;
using System.Collections;


public delegate void Tagger(Player theTagger);

public class Player : MonoBehaviour
{
	public event Tagger _newTagger;
	[SerializeField] private int controller = 0;
	public bool Taged
	{
		set { _taged = value; }
	}
	[SerializeField] private bool _taged;
	[SerializeField] private bool _controlle = true;
	private float r_rot;
	private Vector2 m_Input;
	private Vector3 m_MoveDir = Vector3.zero;
	private CollisionFlags m_CollisionFlags;
	private Transform _transform;
	private Renderer _renderer;
	private string[] _horizontal  = {"Horizontal1", "Horizontal2", "Horizontal3", "Horizontal4"};
	private string[] _vertical  = {"Vertical1", "Vertical2", "Vertical3", "Vertical4"};
	private GameObject _player1;
	private float _angle;



	void Awake ()
	{
		_player1 = this.gameObject.transform.GetChild(0).gameObject;
		if(_taged)
		{
		_player1.GetComponent<Character>().Taged = true;
		}
	}

	void Start ()
	{
		_transform = GetComponent<Transform>();
		_renderer = GetComponent<Renderer>();

		if (_taged) 
		{
			if(_newTagger != null)
			{
				_newTagger (this);
			}
		}
	}

	void Update ()
	{
	}

	void FixedUpdate ()
	{
		float speed = 20f;
		float rSpeed = 60f;
		if(_controlle)
		{
			GetInput();
			Vector3 desiredMove = new Vector3(m_Input.x, 0, m_Input.y);
			this.gameObject.transform.eulerAngles = new Vector3(0, GlobalVars.MainCamera.transform.eulerAngles.y -90, 0);
			this.gameObject.transform.Translate(desiredMove * Time.deltaTime * speed);
		}
	}

	void GetInput ()
	{
		float horizontal = Input.GetAxis(_horizontal[controller]);
		float vertical = Input.GetAxis(_vertical[controller]);
		float threhold =0.2f;

		if(horizontal < threhold && horizontal > -threhold){
			horizontal = 0f;
		}
		if(vertical < threhold && vertical > -threhold){
			vertical = 0f;
		}

		m_Input = new Vector2(-horizontal, -vertical);
		_angle = Mathf.Atan2(-horizontal, -vertical) * Mathf.Rad2Deg + GlobalVars.MainCamera.transform.eulerAngles.y - 180;
		_player1.GetComponent<Character>()._angle = _angle;
		if (m_Input.sqrMagnitude > 1)
		{
			m_Input.Normalize();
		}
	}
}

