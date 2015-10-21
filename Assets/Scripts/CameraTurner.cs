using UnityEngine;
using System.Collections;

public class CameraTurner : MonoBehaviour {

    [SerializeField] private float _radius, _height = 5f;
    [SerializeField] private Vector3 _lookAt = new Vector3(0,0,0);
    [SerializeField] private float _turningSpeed = 0.1f;

    void Start ()
    {
        this.transform.position = new Vector3 (0, _height, _radius * -1);
    }

    void Update ()
    {
        float t = Time.time * _turningSpeed;
        CameraTurn (t);
    }

    void CameraTurn(float t){
        transform.position = new Vector3(_radius * Mathf.Cos(t), _height , _radius * Mathf.Sin(t));
        transform.LookAt(_lookAt);
    }
}
