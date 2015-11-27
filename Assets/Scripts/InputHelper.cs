using UnityEngine;
using System.Collections;

public class InputHelper : MonoBehaviour {
	
	[SerializeField] private bool _control, _aPressed;
	[SerializeField] private int _controller = 0;
	private float r_rot, _angle;
	private Vector2 m_Input;
	private Vector3 m_MoveDir = Vector3.zero;
	private string[] _horizontal  = {"Horizontal1", "Horizontal2", "Horizontal3", "Horizontal4"};
	private string[] _vertical  = {"Vertical1", "Vertical2", "Vertical3", "Vertical4"};
	private string[] _fire = {"Fire1", "Fire2", "Fire3", "Fire4"};
	//private string[] _fire = {"joystick 1", "joystick 2", "joystick 3", "joystick 4"};
	private GameObject _player;
	private float _movementSpeed = 3f;
	
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
		_aPressed = false;
		_control = true;
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
		float aButton = 0f;
		float horizontal = Input.GetAxis(_horizontal[_controller]);
		float vertical = Input.GetAxis(_vertical[_controller]);
		//if(!_aPressed)
		//	aButton = Input.GetAxis (_fire[_controller]);
		if(Input.GetButtonDown(_fire[_controller]))
		{
			_aPressed = true;
		}


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
        
        if(_aPressed)
		{
			Debug.Log ("test");
            _player.GetComponent<Player>().Ability1();
			StartCoroutine(Wait (10));
		}
        
    }

	IEnumerator Wait(int millis)
	{
		yield return new WaitForSeconds(millis/1000);
		_aPressed = !_aPressed;
	}
}
