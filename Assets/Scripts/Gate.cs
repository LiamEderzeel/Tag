using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
	private bool _open;
	private Vector3 dir1, dir2;
	private Renderer _renderers;
	[SerializeField] private Collider[] _colliders  = new Collider[5];
	[SerializeField] private Material[] _materials = new Material[2];

	private void Awake()
	{
		_renderers = gameObject.transform.GetChild(0).GetComponent<Renderer>();
		_colliders = gameObject.GetComponents<Collider>();
		_renderers.material = _materials[0];
	}


	private void OnTriggerEnter(Collider collider)
	{
		dir1 = collider.gameObject.GetComponent<Player>().direction;
		Debug.Log (dir1);
	}
	private void OnTriggerExit(Collider collider)
	{
		dir2 = collider.gameObject.GetComponent<Player>().direction;
		Debug.Log (dir2);
		Debug.Log (Vector3.Dot(dir1, dir2));
		if(Vector3.Dot(dir1, dir2) > 0.50)
			StartCoroutine(Close());
	}
	
	private IEnumerator Close()
	{
		_colliders[3].isTrigger = false;
		_open = false;
		GateColor();
		yield return new WaitForSeconds(15);
		_open = true;
		GateColor();
		_colliders[3].isTrigger = true;
	}

	private void GateColor()
	{
		if(_open)
		{
			_renderers.material = _materials[0];

		}
		else
		{
			_renderers.material = _materials[1];

		}
	}
}
