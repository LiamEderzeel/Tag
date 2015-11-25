using UnityEngine;
using System.Collections;

public class Gate : MonoBehaviour {
	private bool _open;
	private Renderer _renderers;
	[SerializeField] private Collider[] _colliders  = new Collider[5];
	[SerializeField] private Material[] _materials = new Material[2];

	private void Awake()
	{
		_renderers = gameObject.transform.GetChild(0).GetComponent<Renderer>();
		_colliders = gameObject.GetComponents<Collider>();
		_renderers.material = _materials[0];
	}

	private void OnTriggerExit(Collider collider)
	{
		StartCoroutine(Close());
	}
	
	private IEnumerator Close()
	{
		yield return new WaitForSeconds(0.1f);
		_open = false;
		GateColor();
		_colliders[3].isTrigger = false;
		yield return new WaitForSeconds(10);
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
