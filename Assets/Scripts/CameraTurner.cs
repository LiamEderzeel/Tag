using UnityEngine;
using System.Collections;

public class CameraTurner : MonoBehaviour {

    [SerializeField] private float _radius, _height = 5f;
	[SerializeField] private GameObject _lookAt;
    [SerializeField] private float _turningSpeed = 0.1f;
	private float shake = 0f;
	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

    void Start ()
    {
        this.transform.position = new Vector3 (0, _height, _radius * -1);
    }

    void FixedUpdate ()
    {
        float t = Time.time * _turningSpeed;
        CameraTurn (t);
    }

    void CameraTurn(float t)
	{
		Vector3 shakeVector = Vector3.zero;
		if (shake > 0)
		{
			shakeVector = Random.insideUnitSphere * shakeAmount;
			shake -= Time.deltaTime * decreaseFactor;
		}
		else
		{
			shake = 0f;
			shakeVector = Vector3.zero;
		}

		transform.position = new Vector3(_lookAt.transform.position.x + _radius * Mathf.Cos(t) + shakeVector.x,
		                                 _height  + shakeVector.y ,
		                                 _lookAt.transform.position.z + _radius * Mathf.Sin(t));
        transform.LookAt(_lookAt.transform.position);
    }

	public void DoShake()
	{
		shake = 0.11f;
	}
}
