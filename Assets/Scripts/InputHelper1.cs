using UnityEngine;
using System.Collections;

public class InputHelper1 : MonoBehaviour {
	
	[SerializeField] private bool _control = true;
	[SerializeField] private int _controller = 0;
	private float r_rot;
	private Vector2 m_Input;
	private Vector3 m_MoveDir = Vector3.zero;
	private string[] _horizontal  = {"Horizontal1", "Horizontal2", "Horizontal3", "Horizontal4"};
	private string[] _vertical  = {"Vertical1", "Vertical2", "Vertical3", "Vertical4"};
	private string[] _fire = {"Fire1", "Fire2", "Fire3", "Fire4"};
	private float _angle;
	private GameObject _player;
	private float _movementSpeed = 20f;
	
	public int Controller
	{
		set { _controller = value; }
	}
	
	public float MovementSpeed
	{
		set { _movementSpeed = value; }
	}
	
	private void Start ()
	{
		_player = this.gameObject;
	}
	
	private void FixedUpdate ()
	{
		if(_control)
		{
			GetInput();
			Vector3 desiredMove = new Vector3(m_Input.x, 0, m_Input.y);
			this.gameObject.transform.eulerAngles = new Vector3(0, Camera.main.transform.eulerAngles.y - 90, 0);
			this.gameObject.transform.Translate(desiredMove * Time.deltaTime * _movementSpeed);
		}
	}
	
	private void GetInput ()
	{
		float horizontal = Input.GetAxis(_horizontal[_controller]);
		float vertical = Input.GetAxis(_vertical[_controller]);
		float aButton = Input.GetAxis (_fire[_controller]);
		//Debug.Log (aButton);
		float threhold =0.2f;
		
		if(horizontal < threhold && horizontal > -threhold){
			horizontal = 0f;
		}
		
		if(vertical < threhold && vertical > -threhold){
			vertical = 0f;
		}
		
		m_Input = new Vector2(-horizontal, -vertical);
		_angle = Mathf.Atan2(-horizontal, -vertical) * Mathf.Rad2Deg + Camera.main.transform.eulerAngles.y - 180;
		_player.GetComponent<Player>().Angle = _angle;
		
		if (m_Input.sqrMagnitude > 1)
		{
			m_Input.Normalize();
		}

		if( aButton == 1)
			_player.GetComponent<Player>().Ability1();

	}


	
}
