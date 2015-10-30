using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	[SerializeField] private int controller = 0;
	public bool Taged
	{
		set { _taged = value; }
	}
	[SerializeField] private bool _taged;
	[SerializeField] private bool _controlle = true;
	private Vector2 m_Input;
	private Vector3 m_MoveDir = Vector3.zero;
	private CollisionFlags m_CollisionFlags;
	private Transform _transform;
	private Renderer _renderer;
	private string[] _horizontal  = {"Horizontal1", "Horizontal2", "Horizontal3", "Horizontal4"};
	private string[] _vertical  = {"Vertical1", "Vertical2", "Vertical3", "Vertical4"};
	[SerializeField] private Material[] _materials;

	void Awake ()
	{

	}
	void Start ()
	{
		_transform = GetComponent<Transform>();
		_renderer = GetComponent<Renderer>();

		if(_taged)
		{
			Tag();
		}
	}

	void Update ()
	{
	}

	void FixedUpdate ()
	{
		float speed = 20f;
		if(_controlle)
		{
			GetInput();
			Vector3 desiredMove = transform.forward*m_Input.x + transform.right*m_Input.y;

			_transform.Translate(desiredMove * Time.deltaTime * speed);
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

		m_Input = new Vector2(-horizontal, vertical);

		if (m_Input.sqrMagnitude > 1)
		{
			m_Input.Normalize();
		}
	}

	void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player"){
			if(_taged)
			{
				UnTag();
				//collision.gameObject.GetComponent<PlayerMovement>().Tag();
				Debug.Log("Tag your it!" + collision.gameObject.name);
			}
		}
	}

	public void Tag()
	{
		StartCoroutine(TagRoutine());
	}

	IEnumerator TagRoutine()
	{
		//_renderer.material = _materials[1];
		//_controlle = false;
		yield return new WaitForSeconds(2f);
		//_taged = true;
		//_controlle = true;
	}

	private void UnTag()
	{
		_renderer.material = _materials[0];
		_taged = false;
	}

}

