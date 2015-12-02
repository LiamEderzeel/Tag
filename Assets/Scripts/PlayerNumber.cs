using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class PlayerNumber : MonoBehaviour {

	public Player player;
	private Vector3 _worldPos, _screenPos;
	// Use this for initialization
	void Start () {
		this.GetComponent<Text>().text = (player.Controller + 1).ToString();

	}
	
	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = (player.Controller + 1).ToString();
		_worldPos = new Vector3(player.transform.position.x , player.transform.position.y + 2, player.transform.position.z);
		_screenPos = Camera.main.WorldToScreenPoint(_worldPos);
		this.transform.position = new Vector3(_screenPos.x, _screenPos.y);
	}
}
